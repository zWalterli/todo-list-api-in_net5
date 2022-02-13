using AutoMapper;
using VUTTR.Domain.ViewModels;
using VUTTR.Domain.Models;
using System.Collections.Generic;

namespace VUTTR.API.Configurations
{
    public class MapConfiguration : Profile
    {
        public MapConfiguration()
        {
            #region Tool
            CreateMap<ToolViewModel, Tool>()
                .ForMember(d => d.Tags, o => o.MapFrom(src => src.Tags))
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