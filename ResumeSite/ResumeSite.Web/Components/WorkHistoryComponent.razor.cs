using Microsoft.AspNetCore.Components;
using ResumeSite.Models;
using ResumeSite.Web.Services;

namespace ResumeSite.Web.Components
{
    public class WorkHistoryCode : ComponentBase
    {
        [Inject]
        public IWorkHistoryService Service { get; set; } = default!;

        protected List<eWorkHistory> workHistory = [];

        protected override async Task OnInitializedAsync()
        {
            workHistory = await Service.GetWorkHistory();
        }
    }
}
