using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Form.Business.DTOs.FormFieldDto;
using TazeCase.Form.Core.Entities;

namespace TazeCase.Form.Business.Mapper
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Core.Entities.Form, DTOs.FormDto.FormOutputDto>()
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
            //CreateMap<IGrouping<Guid, FormField>, FormFieldGroupByFormDto>()
            //    .ForMember(dest => dest.FormId, opt => opt.MapFrom(src => src.Key))  // FormId'yi grup anahtarından alıyoruz
            //    .ForMember(dest => dest.FormFields, opt => opt.MapFrom(src => src.ToList())); // Grup içindeki verileri liste olarak haritalıyoruz
            CreateMap<IGrouping<Guid, FormField>, FormFieldGroupByFormDto>()
               .ForMember(dest => dest.FormId, opt => opt.MapFrom(src => src.Key))  // FormId'yi grup anahtarından alıyoruz
               .ForMember(dest => dest.Form, opt => opt.MapFrom(src => src.FirstOrDefault().Form != null
                   ? src.First().Form
                   : null))  // İlk Form'u kontrol ederek eşliyoruz
               .ForMember(dest => dest.FormFields, opt => opt.MapFrom(src => src.ToList()));  // Grup içindeki verileri liste olarak haritalıyoruz
        }
    }
}
