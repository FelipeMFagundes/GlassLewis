using AutoMapper;
using CompanyRecords.API.Models.DTO;
using CompanyRecords.API.Models.Entity;

namespace CompanyRecords.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add your mapping configurations here
            // For example:
            // CreateMap<SourceModel, DestinationModel>();
            CreateMap<CompanyDto, Company>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Exchange, opt => opt.MapFrom(src => src.Exchange))
                .ForMember(dest => dest.Ticker, opt => opt.MapFrom(src => src.Ticker))
                .ForMember(dest => dest.Isin, opt => opt.MapFrom(src => src.Isin))
                .ForMember(dest => dest.WebsiteUrl, opt => opt.MapFrom(src => src.WebsiteUrl));
           
        }
    }
}
