using LinqKit;
using RecruitmentTask.Models;
using RecruitmentTask.Repository.Interfaces;
using RecruitmentTask.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RecruitmentTask.Repository
{
    public class HomeRepository : IHomeRepository
    {
        public IList<ReportViewModelResponse> GetReports(ReportViewModelRequest viewModel)
        {
            using (var context = new Context())
            {
                var predicate = PredicateBuilder.New<Report>(true);

                if (viewModel != null)
                {
                    if (!string.IsNullOrEmpty(viewModel.Premises))
                    {
                        predicate = predicate.And(x =>
                            x.Premises.Name.ToLower().Contains(viewModel.Premises.ToLower()));
                    }

                    if (viewModel.From != null)
                    {
                        predicate = predicate.And(x => x.Date >= viewModel.From);
                    }

                    if (viewModel.To != null)
                    {
                        predicate = predicate.And(x => x.Date <= viewModel.To);
                    }
                }

                var reports = context.Reports
                    .Include(x => x.User)
                    .Include(x => x.Premises)
                    .Where(predicate)
                    .Select(x => new ReportViewModelResponse
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Date = x.Date,
                        UserName = x.User != null ? x.User.Name : string.Empty,
                        PermisesName = x.Premises != null ? x.Premises.Name : string.Empty
                    })
                    .ToList();

                return reports;
            }
        }
    }
}