// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetWarehousesResponse : ApiResponse
{
    public WarehouseResponse[] Warehouses { get; init; }

    public GetWarehousesResponse( ) : base ( ) => Warehouses = new WarehouseResponse[ 0 ];
}
