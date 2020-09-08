using System.Collections.Generic;
using RecruitmentTask.Repository.Interfaces;
using RecruitmentTask.Services.Interfaces;
using RecruitmentTask.ViewModels;

namespace RecruitmentTask.Services
{
    public class HomeService : IHomeService
    {
        private readonly IHomeRepository _homeRepository;

        public HomeService(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public IList<ReportViewModelResponse> GetReports(ReportViewModelRequest viewModel)
        {
            var results = _homeRepository.GetReports(viewModel);
            return results;
        }
    }
}