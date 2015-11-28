using System.Linq;
using Contacts.Web.Entities;
using Contacts.Web.Models.Contact;
using Contacts.Web.Models.ContactInfo;

namespace Contacts.Web
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<Contact, ContactListModel>()
                .ForMember(dest => dest.FullName,
                           opts => opts.MapFrom(src => src.FirstName + " " + src.LastName));

            AutoMapper.Mapper.CreateMap<Contact, ContactEditModel>()
                .ForMember(dest => dest.Tags,
                           opts => opts.MapFrom(src => src.Tags.Select(x => x.Name)));

            AutoMapper.Mapper.CreateMap<ContactInfo, ContactInfoEditModel>()
                .ForMember(dest => dest.Type,
                           opts => opts.MapFrom(src => src.Type.ToString()));
        }
    }
}
