using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using YourSalary.Models;
using YourSalary.Services;

namespace YourSalary.Pages
{
    public class BasketballModel : PageModel
    {

        private readonly SalaryComparisonService _service;
        private readonly AthleteService _athleteService;

        public BasketballModel(SalaryComparisonService service, AthleteService athleteservice)
        {
            _service = service;
            _athleteService = athleteservice;


        }

        [BindProperty]
        [Required(ErrorMessage = "Enter Salary")]
        [Range(1, double.MaxValue, ErrorMessage = "Enter a positive number")]
        public decimal MonthlySalary { get; set; }

        [BindProperty]
        public int? SelectedAthleteId { get; set; }

        public List<Athlete> Athletes { get; set; }

        public string? YearsNeeded { get; set; }

        public void OnGet()
        {
            Athletes = _athleteService.GetBasketballAthletes();

        }

        public IActionResult OnPost()
        {
            Athletes = _athleteService.GetBasketballAthletes();

            if(!ModelState.IsValid)
            {
                return Page();
            }

            var athlete = Athletes.FirstOrDefault(a => a.Id == SelectedAthleteId);

            if (athlete != null)
            {
                //YearsNeeded = _service.CalculateYearsNeeded(MonthlySalary, athlete.YearlyIncome);
                YearsNeeded = _service.CalculateTimeToEarn(MonthlySalary, athlete.YearlyIncome);
            }

            return Page();
        }
    }
}
