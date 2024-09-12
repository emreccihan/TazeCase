using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



            CreateMap<Core.Entities.FormField, DTOs.FormFieldDto.FormFieldOutputDto>()
                .ReverseMap();
            CreateMap<Core.Entities.FormField, DTOs.FormFieldDto.FormFieldInputDto>()
                .ReverseMap();

        }
    }
}
