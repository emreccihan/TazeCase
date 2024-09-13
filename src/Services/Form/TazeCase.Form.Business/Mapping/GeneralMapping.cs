using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Form.Business.DTOs.FormDataDto;
using TazeCase.Form.Business.DTOs.FormFieldDto;
using TazeCase.Form.Core.Entities;

namespace TazeCase.Form.Business.Mapper
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Core.Entities.Form, DTOs.FormDto.FormBaseOutputDto>()
                .ReverseMap();
            CreateMap<Core.Entities.Form, DTOs.FormDto.FormOutputDto>()
                .ForMember(dest => dest.FormDataCount, opt => opt.MapFrom(src => src.FormData.Count))
                .ReverseMap();
            CreateMap<Core.Entities.Form, DTOs.FormDto.FormInputDto>()
                .ReverseMap();
            CreateMap<Core.Entities.Form, DTOs.FormDto.FormInputActiveStatusDto>()
                .ReverseMap();


            CreateMap<Core.Entities.FormField, DTOs.FormFieldDto.FormFieldBaseOutputDto>()
                .ReverseMap();
            CreateMap<Core.Entities.FormField, DTOs.FormFieldDto.FormFieldOutputDto>()
                .ReverseMap();
            CreateMap<Core.Entities.FormField, DTOs.FormFieldDto.FormFieldInputDto>()
                .ReverseMap();

            CreateMap<IGrouping<Guid, FormField>, FormFieldGroupByFormDto>()
               .ForMember(dest => dest.FormId, opt => opt.MapFrom(src => src.Key))  
               .ForMember(dest => dest.Form, opt => opt.MapFrom(src => src.FirstOrDefault().Form != null
                   ? src.First().Form
                   : null)) 
               .ForMember(dest => dest.FormFields, opt => opt.MapFrom(src => src.ToList()));


            CreateMap<Core.Entities.FormDataValue, DTOs.FormDataDto.FormDataBaseOutputModel>()
                .ReverseMap();
            CreateMap<Core.Entities.FormDataValue, DTOs.FormDataDto.FormDataInputDto>()
                .ReverseMap();
            CreateMap<Core.Entities.FormDataValue, DTOs.FormDataDto.FormDataOutputDto>()
                .ReverseMap();
            CreateMap<IGrouping<Guid, FormDataValue>, FormDataGroupByFrom>()
               .ForMember(dest => dest.FormId, opt => opt.MapFrom(src => src.Key))
               .ForMember(dest => dest.Form, opt => opt.MapFrom(src => src.FirstOrDefault().Form != null
                   ? src.First().Form
                   : null)) 
               .ForMember(dest => dest.FormData, opt => opt.MapFrom(src => src.ToList()));
            //CreateMap<Core.Entities.FormDataValue, DTOs.FormFieldDto.FormFieldInputDto>()
            //    .ReverseMap();
        }
    }
}
