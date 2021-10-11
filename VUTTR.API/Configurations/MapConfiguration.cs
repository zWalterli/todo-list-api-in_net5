using AutoMapper;
using VUTTR.Domain.ViewModels;
using VUTTR.Domain.Models;
using System.Collections.Generic;

namespace VUTTR.API.Configurations
{
    public class MapConfiguration : Profile
    {
        private List<Tag> ConvertListStringToListTag(List<string> TagsString)
        {
            List<Tag> Tags = new List<Tag>();

            TagsString.ForEach( tag => 
                Tags.Add( new Tag { description = tag } )
            );
            
            return Tags.Count > 0 ? null : Tags;
        }

        public MapConfiguration()
        {
            #region Tool
            CreateMap<ToolViewModel, Tool>()
                .ForMember(d => d.Tags, o => o.MapFrom(src => ConvertListStringToListTag(src.Tags)))
                .ReverseMap();
            #endregion

            #region Tag
            CreateMap<TagViewModel, Tag>().ReverseMap();
            #endregion

            #region User
            CreateMap<UserViewModel, User>().ReverseMap();
            #endregion

            #region Token
            CreateMap<TokenViewModel, Token>().ReverseMap();
            #endregion
        }
    }
}