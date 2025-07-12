using Microsoft.AspNetCore.Components;
using ResumeSite.Models;
using ResumeSite.Web.Services;

namespace ResumeSite.Web.Components
{
    public class SkillsComponentCode : ComponentBase
    {
        [Inject]
        public ISkillService Service { get; set; } = default!;

        protected List<eSkill> skills = [];

        protected override async Task OnInitializedAsync()
        {
            skills = await Service.GetSkills();
        }
    }
}