using AutoMapper;

using CompanyName.Core.Integrations.Exigo;



namespace CompanyName.Core.Entities;

public class ExigoEntityMapper : Profile
{
    protected ExigoConfiguration ExigoConfiguration { get; }
    public ExigoEntityMapper( ) => ExigoConfiguration = new ( );
}
