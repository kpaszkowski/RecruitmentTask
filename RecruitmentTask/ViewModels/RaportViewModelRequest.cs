using System;
using System.ComponentModel;

namespace RecruitmentTask.ViewModels
{
    public class RaportViewModelRequest
    {
        [DisplayName("Lokal")]
        public string Premises { get; set; }

        [DisplayName("Data od")]
        public DateTime? From { get; set; }
        
        [DisplayName("Data do")]
        public DateTime? To { get; set; }
    }
}