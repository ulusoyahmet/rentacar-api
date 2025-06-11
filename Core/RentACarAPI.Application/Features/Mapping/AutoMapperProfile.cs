using AutoMapper;
using RentACarAPI.Application.Features.Mediator.Results.CarPricingResults;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.Mapping
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Car, GetCarPricingWithCarQueryResult>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand!.Name))
                .ForMember(dest => dest.CarPricings, opt => opt.MapFrom(src => src.CarPricings));

            CreateMap<CarPricing, CarPricingDto>()
                .ForMember(dest => dest.PricingName, opt => opt.MapFrom(src => src.Pricing!.Name));
        }
    }
}
