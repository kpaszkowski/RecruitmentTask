using RecruitmentTask.ViewModels;
using System.Collections.Generic;

namespace RecruitmentTask.Repository.Interfaces
{
    public interface IHomeRepository
    {
        IList<ReportViewModelResponse> GetReports(ReportViewModelRequest viewModel);
    }
}