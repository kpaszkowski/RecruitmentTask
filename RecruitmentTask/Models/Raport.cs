using System;

namespace RecruitmentTask.Models
{
    public class Raport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public Premises Premises { get; set; }
    }
}