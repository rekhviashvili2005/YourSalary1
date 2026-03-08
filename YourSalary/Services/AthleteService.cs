using System.Collections.Generic;
using YourSalary.Models;
using System.Linq;
using YourSalary.Data;

namespace YourSalary.Services
{
    public class AthleteService
    {
        //public List<Athlete> Athletes { get; private set; }

        private readonly AppDbContext _context;
        public AthleteService(AppDbContext context)
        {
            _context = context;
        }

        public List<Athlete> GetAthletes()
        {
            return _context.Athletes.ToList();
        }

        //}

        public List<Athlete> GetFootballAthletes()
        {
            return _context.Athletes.Where(a => a.Sport == "Football").ToList();
        }

        public List<Athlete> GetFormula1Athletes()
        {
            return _context.Athletes.Where(a => a.Sport == "Formula 1").ToList();
        }

        public List<Athlete> GetBasketballAthletes()
        {
            return _context.Athletes.Where(a => a.Sport == "Basketball").ToList();

            //return GetAthletes()
            //    .Where(a => a.Sport == "Basketball")
            //    .ToList();
        }


    }
}
