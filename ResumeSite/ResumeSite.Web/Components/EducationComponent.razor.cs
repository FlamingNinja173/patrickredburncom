using Microsoft.AspNetCore.Components;
using ResumeSite.Models;
using ResumeSite.Web.Services;

namespace ResumeSite.Web.Components
{
    public class EducationComponentCode : ComponentBase
    {
        [Inject]
        public IEducationService Service { get; set; } = default!;

        protected List<eEducation> educationList = [];

        protected override async Task OnInitializedAsync()
        {
            educationList = await Service.GetEducation();
        }
    }
}