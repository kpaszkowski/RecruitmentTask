using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RecruitmentTask.Models
{
    public class ReportsDbInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            IList<User> users = new List<User>();

            users.Add(new User {Name = "Jan"});
            users.Add(new User {Name = "Adam"});
            users.Add(new User {Name = "Tomasz"});

            IList<Premises> premises = new List<Premises>();

            premises.Add(new Premises {Name = "Magazyn"});
            premises.Add(new Premises {Name = "Dział sprzedaży"});
            premises.Add(new Premises {Name = "Hala produkcyjna"});

            IList<Report> raports = new List<Report>();

            raports.Add(new Report
            {
                Name = "Sprzątanie",
                Date = DateTime.Now.AddDays(-1).AddHours(-1),
                User = users.FirstOrDefault(x => x.Name.Equals("Jan")),
                Premises = premises.FirstOrDefault(x => x.Name.Equals("Magazyn"))
            });
            raports.Add(new Report
            {
                Name = "Wysłanie emaili",
                Date = DateTime.Now.AddDays(-3).AddHours(-3),
                User = users.FirstOrDefault(x => x.Name.Equals("Adam")),
                Premises = premises.FirstOrDefault(x => x.Name.Equals("Dział sprzedaży"))
            });
            raports.Add(new Report
            {
                Name = "Produkcja 1 przedmiotu",
                Date = DateTime.Now.AddDays(-6).AddHours(-6),
                User = users.FirstOrDefault(x => x.Name.Equals("Tomasz")),
                Premises = premises.FirstOrDefault(x => x.Name.Equals("Hala produkcyjna"))
            });
            raports.Add(new Report
            {
                Name = "Pakowanie i wysyłka",
                Date = DateTime.Now.AddDays(-2).AddHours(-2),
                User = users.FirstOrDefault(x => x.Name.Equals("Jan")),
                Premises = premises.FirstOrDefault(x => x.Name.Equals("Magazyn"))
            });
            raports.Add(new Report
            {
                Name = "Konstrukcja",
                Date = DateTime.Now.AddDays(-4).AddHours(-4),
                User = users.FirstOrDefault(x => x.Name.Equals("Adam")),
                Premises = premises.FirstOrDefault(x => x.Name.Equals("Hala produkcyjna"))
            });

            context.Users.AddRange(users);
            context.Premises.AddRange(premises);
            context.Reports.AddRange(raports);

            base.Seed(context);
        }
    }
}