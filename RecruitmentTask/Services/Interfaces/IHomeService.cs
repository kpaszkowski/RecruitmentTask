using RecruitmentTask.ViewModels;
using System.Collections.Generic;

namespace RecruitmentTask.Services.Interfaces
{
    public interface IHomeService
    {
        IList<RaportViewModelReponse> GetRaports(RaportViewModelRequest viewModel);
    }
}