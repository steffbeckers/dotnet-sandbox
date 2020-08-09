namespace Sandbox.Dapper.Infrastructure.Data.Mappers
{
    public static class ClassMappers
    {
        public static void Initialize()
        {
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new[]
            {
                typeof(ClassMappers).Assembly
            });
        }
    }
}
