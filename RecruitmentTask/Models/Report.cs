using System;

namespace RecruitmentTask.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public Premises Premises { get; set; }
    }
}