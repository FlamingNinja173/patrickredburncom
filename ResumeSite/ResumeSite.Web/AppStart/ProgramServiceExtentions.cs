using ResumeSite.Web.Services;

namespace ResumeSite.Web.AppStart
{
    public static class ProgramServiceExtentions
    {
        public static void AddDataAccessServices(this IServiceCollection services)
        {
            services.AddScoped<ICertificationService, CertificationService>();
            services.AddScoped<IWorkHistoryService, WorkHistoryService>();
        }
    }
}
