using AutoMapper;
using UpdateODGovernmentFees.DTOs;
using UpdateODGovernmentFees.Models;

namespace UpdateODGovernmentFees.Profiles
{
    public class GovernmentFeesProfile : Profile
    {
        public GovernmentFeesProfile()
        {
            CreateMap<GovernmentFee, GovernmentFeeReadDTO>();
            CreateMap<GovernmentFee, GovernmentFeeDTO>();
            CreateMap<GovernmentFeeDTO, GovernmentFee>();
        }
    }
}