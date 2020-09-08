using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecruitmentTask.ViewModels
{
    public class RaportViewModelRequest
    {
        public string Premises { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}