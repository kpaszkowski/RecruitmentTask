﻿using RecruitmentTask.ViewModels;
using System.Collections.Generic;

namespace RecruitmentTask.Services.Interfaces
{
    public interface IHomeService
    {
        IList<ReportViewModelResponse> GetReports(ReportViewModelRequest viewModel);
    }
}