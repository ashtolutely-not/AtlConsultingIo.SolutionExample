#pragma warning disable CS8321 // Local function is declared but never used
#region Usings

using AtlConsultingIo.Generators;
using Newtonsoft.Json;

using System.Text;
using AtlConsultingIo.DevOps;
using System.IO;
using Microsoft.CodeAnalysis;
using System;



#endregion

var buildProject = BuildProject.Create( "C:\\Users\\ashto\\source\\repos\\AtlConsultingIo\\AtlConsultingIo.CompanyOperations\\CompanyName.Core" );
await BuildProjectCommands.CreateLocalNugetPackage ( buildProject , BuildProfile.Release , true );
var fileInfo = buildProject.GetNugetFile( BuildProfile.Release, "1.0.0" );

var outDirectory = new DirectoryInfo( "C:\\Users\\ashto\\source\\repos\\AtlConsultingIo\\AtlConsultingIo.CompanyOperations\\packages");
outDirectory.Create ( );

var targetPath = Path.Combine( outDirectory.FullName, fileInfo.Name );
File.WriteAllBytes ( targetPath , File.ReadAllBytes ( fileInfo.FullName ) );


static async Task BuildCommitAndPush( BuildProject project , BuildProfile profile )
{
    await BuildProjectCommands.CreateNewBuild ( project , profile , updateVersion: false , validateResult: true );
    await BuildProjectCommands.AddCommitFiles ( project );
    await BuildProjectCommands.CreateLocalCommitFromFile ( project );
    await BuildProjectCommands.PushLocalCommits ( project );
}

static async Task CreatePackageAndAddToLocalPackages( BuildProject buildProject , BuildProfile profile )
{
    string version = buildProject.GetNextVersion( );
    buildProject.UpdateProjectFile ( version );

    //Create a new nuget file
    await BuildProjectCommands.CreateLocalNugetPackage ( buildProject , profile , true );
    BuildProjectCommands.CopyNugetFileToLocalPackages ( buildProject , profile , version );

}




#pragma warning restore CS8321 // Local function is declared but never used

static class ExigoEntitiesBuild
{
    public static async Task TestBuild( )
    {
        string cmdPath = CommandParams.FilePaths.ExigoSqlEntitiesConfig;
        string cmdFile = File.ReadAllText( cmdPath );

        var buildConfig = JsonConvert.DeserializeObject<EFScaffoldConfiguration>( cmdFile ) with
        {
            ContextOutDirectory = Path.Combine( CommandParams.TestDirectoryPaths.ExigoEntitiesTests , "dbo", "Context" ) ,
            EntitiesOutDirectory = Path.Combine( CommandParams.TestDirectoryPaths.ExigoEntitiesTests , "dbo", "Entities" )
        };

        await SqlEntityGenerator.Run ( buildConfig );
        SqlEntityGenerator.AdjustNames ( buildConfig );

    }

    public static async Task ProjectBuild( )
    {
        string cmdPath = CommandParams.FilePaths.ExigoSqlEntitiesConfig;
        string cmdFile = File.ReadAllText( cmdPath );

        var buildConfig = JsonConvert.DeserializeObject<EFScaffoldConfiguration>( cmdFile );

        await SqlEntityGenerator.Run ( buildConfig );
        SqlEntityGenerator.AdjustNames ( buildConfig );

    }
}

static class UpdateNamespaces
{
    //the code here is always going to be throw away code once a project gets to a certain point
    public static void Run( )
    {
        List<string> coreUsings = UpdateCoreProject();
        UpdateOperationsProject( coreUsings );

    }

    static void UpdateOperationsProject( List<string> coreNamespaces )
    {
        var operationsNamespaces = new List<string>();

        var opsProj = BuildProject.Create("C:\\Users\\ashto\\source\\repos\\AtlConsultingIo\\AtlConsultingIo.CompanyOperations\\CompanyName.Operations");
        var opsNs = "CompanyName.Operations";

        CleanTopLevelFiles ( opsProj.ProjectDirectoryInfo , opsNs );
        operationsNamespaces.Add ( opsNs );

        var subDirectories = opsProj.ProjectDirectoryInfo.GetDirectories ( )?.ToList ( ) ?? new();
        foreach ( var dir in subDirectories )
        {
            string ns = IsDomainDirectory( dir ) ? opsNs + "." + dir.Name : opsNs;
            CleanFilesAndSubdirectoryFiles ( dir , ns );
            if ( !operationsNamespaces.Contains ( ns ) )
                operationsNamespaces.Add ( ns );
        }

        operationsNamespaces.AddRange( coreNamespaces );
        AddUsings( opsProj, operationsNamespaces );
    }

    static List<string> UpdateCoreProject( )
    {
        BuildProject coreProj = BuildProject.Create( "C:\\Users\\ashto\\source\\repos\\AtlConsultingIo\\AtlConsultingIo.CompanyOperations\\CompanyName.Core" );
        string baseNamespace = "CompanyName.Core";

        var coreNamespaces = new List<string>();

        CleanTopLevelFiles ( coreProj.ProjectDirectoryInfo , baseNamespace );
        coreNamespaces.Add ( baseNamespace );

        coreNamespaces.AddRange( UpdateCoreEntititesDirectory ( coreProj , baseNamespace ) );
        coreNamespaces.AddRange( UpdateCoreIntegrationsDirectory ( coreProj , baseNamespace ) );

        AddUsings( coreProj, coreNamespaces );
        return coreNamespaces;
    }
    static void AddUsings( BuildProject project , List<string> namespaces )
    {
        var projectFiles = project.ProjectDirectoryInfo.GetFiles("*.cs",SearchOption.AllDirectories);
        var usings = namespaces.Select( str => $"using {str};")?.ToList() ?? new();
        foreach ( var file in projectFiles )
        {
            var lines = File.ReadAllLines( file.FullName);

            var newLines = lines.Where( l => l.StartsWith("//"))?.ToList() ?? new();
            newLines.AddRange ( usings );

            foreach ( var line in lines )
                if ( !line.StartsWith ( "//" ) && !line.Trim ( ).StartsWith ( "using TotalLife." ) )
                    newLines.Add ( line );

            File.WriteAllLines ( file.FullName , newLines );
        }
    }
    static List<string> UpdateCoreEntititesDirectory( BuildProject coreProj , string baseNamespace )
    {
        string entitiesNamespace = string.Join(".", baseNamespace, "Entities");
        var entitiesDirectory = new DirectoryInfo(Path.Combine( coreProj.ProjectDirectoryInfo.FullName, "Entities"));
        
        CleanTopLevelFiles ( entitiesDirectory , entitiesNamespace );
        var dirNamespaces = new List<string> { entitiesNamespace };

        var subDirectories = entitiesDirectory.GetDirectories()?.ToList() ?? new();
        foreach ( var dir in subDirectories )
        {
            string ns = IsDomainDirectory( dir ) ? entitiesNamespace + "." + dir.Name : entitiesNamespace;
            CleanFilesAndSubdirectoryFiles ( dir , ns );
            if ( !dirNamespaces.Contains ( ns ) )
                dirNamespaces.Add ( ns );
        }

        return dirNamespaces;
    }
    static List<string> UpdateCoreIntegrationsDirectory( BuildProject coreProj, string baseNamespace )
    {
        var integrationsDir = new DirectoryInfo(Path.Combine( coreProj.ProjectDirectoryInfo.FullName,"Integrations"));
        var integrationsNamespace = string.Join ( "." , baseNamespace , "Integrations" );

        CleanTopLevelFiles ( integrationsDir , integrationsNamespace );
        var dirNamespaces = new List<string> { integrationsNamespace };

        var subDirectories = integrationsDir.GetDirectories ( )?.ToList ( ) ?? new();
        foreach ( var dir in subDirectories )
        {
            var dirNs = integrationsNamespace + "." + dir.Name;
            if ( !dir.Name.Equals ( "Exigo" ) )
            {
                CleanFilesAndSubdirectoryFiles ( dir , dirNs );
                if ( !dirNamespaces.Contains ( dirNs ) )
                    dirNamespaces.Add ( dirNs );
                continue;
            }
            else
            {
                var exigoDirectories = dir.GetDirectories()?.ToList() ?? new();
                foreach ( var exigoDir in exigoDirectories )
                {
                    string exigNs = exigoDir.Name switch
                    {
                        "Rest" => dirNs + "." + exigoDir.Name,
                        "Sql" => dirNs + "." + exigoDir.Name,
                        _ => dirNs
                    };

                    CleanFilesAndSubdirectoryFiles ( exigoDir , exigNs );
                    if ( !dirNamespaces.Contains ( exigNs ) )
                        dirNamespaces.Add ( exigNs );
                }
            }

        }


        return dirNamespaces;
    }
    static bool IsDomainDirectory( DirectoryInfo directory ) => !new List<string>
    {
        "_Shared",
        "Options",
        "Results"
    }.Contains ( directory.Name );
    static void CleanFilesAndSubdirectoryFiles( DirectoryInfo directory , string directoryNamespace )
    {
        var files = directory.GetFiles("*.cs", SearchOption.AllDirectories)?.ToList() ?? new List<FileInfo>();
        CleanFiles ( files , directoryNamespace );
    }
    static void CleanTopLevelFiles( DirectoryInfo directory , string directoryNamespace )
    {
        var files = directory.GetFiles("*.cs", SearchOption.TopDirectoryOnly)?.ToList() ?? new List<FileInfo>();
        CleanFiles ( files , directoryNamespace );
    }
    static void CleanFiles( List<FileInfo> files , string directoryNamespace )
    {
        foreach ( var f in files )
        {
            var lines = File.ReadAllLines( f.FullName );
            var newLines = new List<string>();
            foreach ( var line in lines )
            {
                if ( line.StartsWith ( "using CompanyName." ) )
                    continue;

                if ( !line.StartsWith ( "namespace" ) || line.Trim ( ).Equals ( $"namespace {directoryNamespace};" ) )
                    newLines.Add ( line );
                else
                    newLines.Add ( $"namespace {directoryNamespace};" );

            }

            File.WriteAllLines ( f.FullName , newLines );
        }
    }
}