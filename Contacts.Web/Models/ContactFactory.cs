using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Contacts.Web.Entities;
using Contacts.Web.Models.Contact;

namespace Contacts.Web.Models
{
    public class ContactFactory
    {
        public Entities.Contact Create(ContactEditModel model)
        {
            return new Entities.Contact
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                BirthDate = model.BirthDate,
                Favorite = model.Favorite,
                ContactInfos = model.ContactInfos == null ? new List<Entities.ContactInfo>() : model.ContactInfos.Select(x => new Entities.ContactInfo
                {
                    Name = x.Name,
                    Type = (ContactInfoType)Enum.Parse(typeof(ContactInfoType), x.Type, true),
                    Value = x.Value
                }).ToList(),
                Tags = model.Tags == null ? new List<Entities.Tag>() : model.Tags.Select(x => new Entities.Tag
                {
                    Name = x
                }).ToList()
            };
        }

        public Entities.Contact Update(ContactEditModel model, Entities.Contact entity, IContactsDbContext dbContext)
        {
            dbContext.Entry(entity).State = EntityState.Modified;

            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Address = model.Address;
            entity.BirthDate = model.BirthDate;
            entity.Favorite = model.Favorite;

            #region update contact infos

            if (model.ContactInfos != null)
            {
                List<Entities.ContactInfo> contactInfos = entity.ContactInfos.ToList();
                if (contactInfos.Count > 0)
                {
                    foreach (var contactInfo in contactInfos.Where(x => model.ContactInfos.All(y => y.IsDeleted)))
                    {
                        dbContext.Entry(contactInfo).State = EntityState.Deleted;
                    }
                }

                foreach (var contactInfo in model.ContactInfos.Where(x => !x.IsDeleted))
                {
                    if (contactInfo.IsNew)
                    {
                        var newContactInfo = new Entities.ContactInfo
                        {
                            Name = contactInfo.Name,
                            Type = (ContactInfoType)Enum.Parse(typeof(ContactInfoType), contactInfo.Type, true),
                            Value = contactInfo.Value
                        };
                        entity.ContactInfos.Add(newContactInfo);
                        dbContext.Entry(newContactInfo).State = EntityState.Added;
                    }
                    else
                    {
                        var oldContactInfo = entity.ContactInfos.FirstOrDefault(x => x.Id == contactInfo.Id);
                        if (oldContactInfo != null)
                        {
                            oldContactInfo.Name = contactInfo.Name;
                            oldContactInfo.Type = (ContactInfoType)Enum.Parse(typeof(ContactInfoType), contactInfo.Type, true);
                            oldContactInfo.Value = contactInfo.Value;
                        }
                        dbContext.Entry(oldContactInfo).State = EntityState.Modified;
                    }
                }
            }

            #endregion

            #region update tags

            if (model.Tags != null)
            {
                List<Entities.Tag> tags = entity.Tags.ToList();
                if (tags.Count > 0)
                {
                    foreach (var tag in tags.Where(x => model.Tags.All(y => y != x.Name)))
                    {
                        dbContext.Entry(tag).State = EntityState.Deleted;
                    }
                }

                foreach (var tag in model.Tags.Where(x => entity.Tags.All(y => y.Name != x)))
                {
                    var newTag = new Tag {Name = tag};
                    entity.Tags.Add(newTag);
                    dbContext.Entry(newTag).State = EntityState.Added;
                }
            }

            #endregion

            return entity;
        }
    }
}