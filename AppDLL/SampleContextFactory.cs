using Microsoft.EntityFrameworkCore.Design;

namespace AppDLL;
class SampleContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext CreateDbContext(string[] args)
    {
        return new ApplicationContext(ApplicationContext.GetDb());
    }
}