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

        private async Task<List<DateCustomerWork>> CalculateVacation(int startVacation, int daysSinceStop, List<DateCustomerWork> customerWork, int minWorkingDays)
        {
            int vacationThreshold = startVacation;
            DateTime today = DateTime.UtcNow;

            var usersWithVacationLeft = await Task.Run(() =>
            {
                return customerWork
                    .Select(x =>
                    {
                        var daysWorked = (today - x.DateTimeStartPrgoress.ToDateTime(TimeOnly.MinValue)).Days;
                        var vacationDays = daysWorked >= 28 ? (daysWorked / 28) * 5 : 0;

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
            });

            return usersWithVacationLeft;
        }
    }
}
