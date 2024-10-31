namespace SmartMngShop.Customer.Domain.Models
{
    public class DateCustomerWork
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public required DateOnly DateTimeStartPrgoress { get; set; }
        public DateOnly? DateTimeStopPrgoress { get; set; } = null;

        public int Vacation { get; set; }

        private Task<List<DateCustomerWork>> CalculateVacation(int startVacation, int daysSinceStop, List<DateCustomerWork> customerWork, int minWorkingDays)
        {
            int vacationThreshold = startVacation;
            DateTime today = DateTime.UtcNow;

            var usersWithVacationLeft = customerWork
                .Select(x =>
                {
                    
                    int daysWorked = (today - x.DateTimeStartPrgoress.ToDateTime(TimeOnly.MinValue)).Days;
                    int vacationDays = daysWorked / 28 * 5;

                    return new DateCustomerWork
                    {
                        Id = x.Id,
                        Name = x.Name,
                        JobTitle = x.JobTitle,
                        DateTimeStartPrgoress = x.DateTimeStartPrgoress,
                        DateTimeStopPrgoress = x.DateTimeStopPrgoress,
                        Vacation = vacationDays
                    };
                })
                .Where(x => x.Vacation > vacationThreshold)
                .ToList();

            return Task.FromResult(usersWithVacationLeft);
        }
    }
}
