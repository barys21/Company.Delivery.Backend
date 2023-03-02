using AutoMapper;
using Company.Delivery.Api.Controllers.Waybills.Request;
using Company.Delivery.Domain.Dto;

namespace Company.Delivery.Api.Common
{
    /// <summary>
    /// AutoMapper
    /// </summary>
    public class CustomMapper : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public CustomMapper()
        {
            CreateMap<WaybillCreateRequest, WaybillCreateDto>().ReverseMap();
            CreateMap<WaybillUpdateRequest, WaybillUpdateDto>().ReverseMap();
        }
    }
}
