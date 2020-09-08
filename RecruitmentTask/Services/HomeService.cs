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
                    var raports = context.Raports
                        .Include(x=>x.User)
                        .Include(x => x.Premises)
                        .ToList();

                    foreach (var raport in raports)
                    {
                        response.Add(new RaportViewModelReponse
                        {
                            Id = raport.Id,
                            Name = raport.Name,
                            Date = raport.Date,
                            UserName = raport.User?.Name,
                            PermisesName = raport.Premises?.Name
                        });
                    }
                    return response;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}