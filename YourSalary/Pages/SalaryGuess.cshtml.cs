using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YourSalary.Models;
using YourSalary.Services;

namespace YourSalary.Pages
{
    public class SalaryGuessModel : PageModel
    {

        private readonly AthleteService _athleteService;
        
        public SalaryGuessModel(AthleteService athleteService)
        {
            _athleteService = athleteService;
        }

        public Athlete Athlete1 { get; set; }
        public Athlete Athlete2 { get; set; }


        [BindProperty]
        public int? SelectedAthleteId { get; set; }

        public int Score { get; set; }
        public int Round {  get; set; }



        public bool IsGameOver { get; set; } /// <summary>
        /// მერე დამატებულია ეს
        /// </summary>



        public void OnGet()
        {
            var allAthletes = _athleteService.GetAthletes();
            var rnd = new Random();

            Score = HttpContext.Session.GetInt32("Score") ?? 0;
            Round = HttpContext.Session.GetInt32("Round") ?? 1;

            var athlete1Id = HttpContext.Session.GetInt32("Athlete1Id");
            

            if(athlete1Id == null)
            {
                var shuffled = allAthletes.OrderBy(a => rnd.Next()).Take(2).ToList();

                Athlete1 = shuffled[0];
                Athlete2 = shuffled[1];

                HttpContext.Session.SetInt32("Athlete1Id", Athlete1.Id);

            }
            else
            {
                Athlete1 = allAthletes.First(a => a.Id == athlete1Id.Value);

                Athlete2 = allAthletes
                    .Where(a => a.Id != Athlete1.Id)
                    .OrderBy(a => rnd.Next())
                    .First();
                    
            }
        }

        public IActionResult OnPost()
        {

            var allAthletes = _athleteService.GetAthletes();
            Score = HttpContext.Session.GetInt32("Score") ?? 0;
            Round = HttpContext.Session.GetInt32("Round") ?? 1;




            if(!int.TryParse(Request.Form["athlete1"], out int athlete1Id) ||
                !int.TryParse(Request.Form["athlete2"], out int athlete2Id))
            {
                ModelState.AddModelError("", "Something went wrong with the selected athletes.");
                OnGet(); 
                return Page();
            }

            Athlete1 = allAthletes.First(a => a.Id == int.Parse(Request.Form["athlete1"]));
            Athlete2 = allAthletes.First(a => a.Id == int.Parse(Request.Form["athlete2"]));


            if (Athlete1 == null || Athlete2 == null)
            {
                ModelState.AddModelError("", "Athlete not found.");
                OnGet();
                return Page();
            }



            if (SelectedAthleteId.HasValue)
            {
                var correctId = (Athlete1.YearlyIncome > Athlete2.YearlyIncome)
                    ? Athlete1.Id : Athlete2.Id;

                if(SelectedAthleteId.Value == correctId)
                {
                    Score++;
                    HttpContext.Session.SetInt32("Athlete1Id", correctId);
                }

                else
                {
                    //    HttpContext.Session.Clear();
                    //   // return RedirectToPage("GameOver");


                    IsGameOver = true;
                    HttpContext.Session.Clear();
                    return Page();
                }
            }


            Round++;

            if(Round > 10)
            {
                //HttpContext.Session.Clear();

                ////return RedirectToPage("GameOver");
                ///
                IsGameOver = true; // თამაში დასრულდა
                HttpContext.Session.Clear();
                return Page();
            }


            HttpContext.Session.SetInt32("Score", Score);
            HttpContext.Session.SetInt32("Round", Round);

            return RedirectToPage();

        }



    }
}
