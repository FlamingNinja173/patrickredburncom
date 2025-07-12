using Microsoft.AspNetCore.Components;
using ResumeSite.Models;
using ResumeSite.Web.Services;

namespace ResumeSite.Web.Components
{
    public class CertificationComponentCode : ComponentBase
    {
        [Inject]
        public ICertificationService Service { get; set; } = default!;

        protected List<eCertification> certifications = [];

        protected override async Task OnInitializedAsync()
        {
            certifications = await Service.GetCertifications();
        }
    }
}
