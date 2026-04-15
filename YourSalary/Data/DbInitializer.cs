using YourSalary.Models;
using System.Linq;

namespace YourSalary.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {

            context.Database.EnsureCreated();

            //if (context.Athletes.Any())
            //    return;
         



            var athletes = new Athlete[]
            {
                new Athlete{ FirstName="Cristiano", LastName="Ronaldo", Team="Al Nassr", Sport="Football", YearlyIncome=120_000_000 },
                new Athlete{ FirstName="Lionel", LastName="Messi", Team="Inter Miami", Sport="Football", YearlyIncome=110_000_000 },
                new Athlete{ FirstName="LeBron", LastName="James", Team="Lakers", Sport="Basketball", YearlyIncome=60_000_000 },
                new Athlete{ FirstName="Novak", LastName="Djokovic", Team="Team Serbia", Sport="Tennis", YearlyIncome=5_000_000 },
                new Athlete{ FirstName="Luka", LastName="Modric", Team="AC Milan", Sport="Football", YearlyIncome=7_000_000 },
                new Athlete{ FirstName="Charles", LastName="Leclerc", Team="Ferrari", Sport="Formula 1", YearlyIncome=34_000_000 },
                new Athlete{ FirstName="Lewis", LastName="Hamilton", Team="Ferrari", Sport="Formula 1", YearlyIncome=60_000_000 },
                new Athlete{ FirstName="Max", LastName="Verstappen", Team="Red Bull", Sport="Formula 1", YearlyIncome=76_000_000 },
                new Athlete{ FirstName="Stephen", LastName="Curry", Team="Goleden State", Sport="Basketball", YearlyIncome=60_000_000 },
                new Athlete{ FirstName="Luka", LastName="Doncic", Team="Los Angeles Lakers", Sport="Basketball", YearlyIncome=46_000_000 },

                //new athletes
                new Athlete{ FirstName = "Giorgi", LastName = "Guliashvili", Team = "Racing Santander", Sport="Football", YearlyIncome = 2_000_000},
                new Athlete{ FirstName="Kylian", LastName="Mbappe", Team="Paris Saint-Germain", Sport="Football", YearlyIncome=33_000_000 },
                new Athlete{ FirstName="Erling", LastName="Haaland", Team="Manchester City", Sport="Football", YearlyIncome=28_000_000 },
                new Athlete{ FirstName="Kevin", LastName="De Bruyne", Team="Manchester City", Sport="Football", YearlyIncome=7_000_000 },
                new Athlete{ FirstName="Mohamed", LastName="Salah", Team="Liverpool", Sport="Football", YearlyIncome=20_000_000 },
                new Athlete{ FirstName="Sadio", LastName="Mane", Team="Al Nassr", Sport="Football", YearlyIncome=45_000_000 },

                new Athlete{ FirstName="Giannis", LastName="Antetokounmpo", Team="Milwaukee Bucks", Sport="Basketball", YearlyIncome=50_000_000 },
                new Athlete{ FirstName="James", LastName="Harden", Team="Philadelphia 76ers", Sport="Basketball", YearlyIncome=39_000_000 },
                new Athlete{ FirstName="Anthony", LastName="Davis", Team="Los Angeles Lakers", Sport="Basketball", YearlyIncome=51_000_000 },
                new Athlete{ FirstName="Kawhi", LastName="Leonard", Team="Los Angeles Clippers", Sport="Basketball", YearlyIncome=48_000_000 },
                new Athlete{ FirstName="Joel", LastName="Embiid", Team="Philadelphia 76ers", Sport="Basketball", YearlyIncome=35_000_000 },
                new Athlete{ FirstName = "Shota", LastName = "Shotadze", Team = "Golden State", Sport= "Basketball", YearlyIncome = 100_000_000},

                new Athlete{ FirstName="Fernando", LastName="Alonso", Team="Aston Martin", Sport="Formula 1", YearlyIncome=30_000_000 },
                new Athlete{ FirstName="George", LastName="Russell", Team="Mercedes", Sport="Formula 1", YearlyIncome=19_000_000 },
                new Athlete{ FirstName="Lando", LastName="Norris", Team="McLaren", Sport="Formula 1", YearlyIncome=57_000_000 },
                new Athlete{ FirstName="Carlos", LastName="Sainz", Team="Wiliams", Sport="Formula 1", YearlyIncome=13_000_000 },
                new Athlete{ FirstName="Valtteri", LastName="Bottas", Team="Cadilac", Sport="Formula 1", YearlyIncome=12_000_000 },
            };


            foreach (var a in athletes)
            {
               
                var existing = context.Athletes
                    .FirstOrDefault(x => x.FirstName == a.FirstName && x.LastName == a.LastName);

                if (existing != null)
                {                    
                    existing.Team = a.Team;
                    existing.YearlyIncome = a.YearlyIncome;
                    existing.Sport = a.Sport;
                }
                else
                {
                    
                    context.Athletes.Add(a);
                }
            }
            //foreach (var a in athletes)
            //{
            //    if (!context.Athletes.Any(x =>
            //        x.FirstName == a.FirstName &&
            //        x.LastName == a.LastName))
            //    {
            //        context.Athletes.Add(a);
            //    }
            //}

            //context.SaveChanges();
            //foreach (var a in athletes)
            //    context.Athletes.Add(a);

            context.SaveChanges();
        }
       

    }
}
