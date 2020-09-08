using LinqKit;
using RecruitmentTask.Models;
using RecruitmentTask.Services.Interfaces;
using RecruitmentTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RecruitmentTask.Services
{
    public class HomeService : IHomeService
    {
        public IList<RaportViewModelReponse> GetRaports(RaportViewModelRequest viewModel)
        {
            try
            {
                using (var context = new Context())
                {
                    var response = new List<RaportViewModelReponse>();
                    var predicate = PredicateBuilder.New<Raport>(true);

                    if (viewModel != null)
                    {
                        if (!string.IsNullOrEmpty(viewModel.Premises))
                        {
                            predicate = predicate.And(x => x.Premises.Name.ToLower().Contains(viewModel.Premises.ToLower()));
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

                    var raports = context.Raports
                        .Include(x => x.User)
                        .Include(x => x.Premises)
                        .Where(predicate)
                        .Select(x => new RaportViewModelReponse
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Date = x.Date,
                            UserName = x.User != null ? x.User.Name : string.Empty,
                            PermisesName = x.Premises != null ? x.Premises.Name : string.Empty
                        })
                        .ToList();

                    return raports;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}