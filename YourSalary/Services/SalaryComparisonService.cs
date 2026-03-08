namespace YourSalary.Services
{
    public class SalaryComparisonService
    {

        //public decimal CalculateYearsNeeded(decimal monthlySalary, decimal athleteYearlyIncome)
        //{
        //    var yearlySalary = monthlySalary * 12;
        //    var athleteDailyIncome = athleteYearlyIncome / 365;

        //    return athleteDailyIncome / yearlySalary;
        //}

        public decimal CalculateHour(decimal monthlySalary, decimal athleteYearlyIncome)
        {
            var yearlySalary = monthlySalary * 12;
            var hourlySalary = yearlySalary / (365  * 24);

            var athleteDailyIncome = athleteYearlyIncome / 365;

            var hoursNeeded = athleteDailyIncome / hourlySalary;

            return hoursNeeded;
        }



        public string CalculateTimeToEarn(decimal monthlySalary, decimal athleteYearlyIncome)
        {
            var yearlySalary = monthlySalary * 12;

            var athleteDailyIncome = athleteYearlyIncome / 365;
                               
            var totalDays = athleteDailyIncome / (yearlySalary / 365);

            int years = (int)(totalDays / 365);
            totalDays -= years * 365;

            int months = (int)(totalDays / 30);
            totalDays -= months * 30;

            int days = (int)totalDays;
            totalDays -= days;

            int hours = (int)(totalDays * 24);

            return $"{years} year {months} month {days} day {hours} hour";
        }
    }
}
