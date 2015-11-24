﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                BirthDate = model.BirthDate,
                Favorite = model.Favorite,
                ContactInfos = model.ContactInfos.Select(x => new Entities.ContactInfo
                {
                    Name = x.Name,
                    Type = (ContactInfoType)Enum.Parse(typeof(ContactInfoType), x.Type, true),
                    Value = x.Value
                }).ToList(),
                Tags = model.Tags.Select(x => new Entities.Tag
                {
                    Name = x
                }).ToList()
            };
        }

        public Entities.Contact Update(ContactEditModel model, Entities.Contact entity)
        {
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.BirthDate = model.BirthDate;
            entity.Favorite = model.Favorite;

            #region update contact infos

            List<Entities.ContactInfo> contactInfos = entity.ContactInfos.ToList();
            if (contactInfos.Count > 0)
            {
                contactInfos.RemoveAll(x => model.ContactInfos.All(y => y.IsDeleted));
                entity.ContactInfos = contactInfos;
            }

            foreach (var contactInfo in model.ContactInfos.Where(x => x.IsDeleted))
            {
                if (contactInfo.IsNew)
                {
                    entity.ContactInfos.Add(new Entities.ContactInfo
                    {
                        Name = contactInfo.Name,
                        Type = (ContactInfoType) Enum.Parse(typeof (ContactInfoType), contactInfo.Type, true),
                        Value = contactInfo.Value
                    });
                }
                else if (contactInfo.IsModified)
                {
                    var oldContactInfo = entity.ContactInfos.FirstOrDefault(x => x.Id == contactInfo.Id);
                    if (oldContactInfo != null)
                    {
                        oldContactInfo.Name = contactInfo.Name;
                        oldContactInfo.Type = (ContactInfoType)Enum.Parse(typeof(ContactInfoType), contactInfo.Type, true);
                        oldContactInfo.Value = contactInfo.Value;
                    }
                }
            }

            #endregion

            #region update tags

            List<Entities.Tag> tags = entity.Tags.ToList();
            if (tags.Count > 0)
            {
                tags.RemoveAll(x => model.Tags.All(y => y != x.Name));
                entity.Tags = tags;
            }

            foreach (var tag in model.Tags.Where(x => entity.Tags.All(y => y.Name != x)))
            {
                entity.Tags.Add(new Tag { Name = tag });
            }

            #endregion

            return entity;
        }
    }
}