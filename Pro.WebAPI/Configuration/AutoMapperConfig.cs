using AutoMapper;
using Pro.API.ViewModels;
using Pro.Business.Models;
using Pro.WebAPI.ViewModels;

namespace Pro.WebAPI.Configuration;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Cliente, ClienteViewModel>().ReverseMap();
        CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
        CreateMap<Servico, ServicoViewModel>().ReverseMap();
    }
}
