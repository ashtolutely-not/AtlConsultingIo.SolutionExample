
using Microsoft.AspNetCore.Builder;

namespace AtlConsultingIo.Operations.TestConsole;
public class Program
{

    public static void Main( string[] args )
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        WebApplication app = builder.Build();
        app.Run();



    }

}



