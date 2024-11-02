namespace SmartMngShop.Customer.Domain.Models
{
    public class DateCustomerWork
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public required DateOnly DateTimeStartProgress { get; set; }
        public DateOnly? DateTimeStopProgress { get; set; }

        public int Vacation { get; set; }

        public async Task<List<DateCustomerWork>> CalculateVacation(int startVacation, List<DateCustomerWork> customerWork)
        {
            int minimumVacationDays = startVacation;
            DateTime today = DateTime.UtcNow;

            var usersWithVacationLeft = customerWork
                .Select(x =>
                {

                    DateTime endDate = x.DateTimeStopProgress?.ToDateTime(TimeOnly.MinValue) ?? today;
                    int daysWorked = (endDate - x.DateTimeStartProgress.ToDateTime(TimeOnly.MinValue)).Days;
                    int vacationDays = daysWorked / 28 * 5;
                    return new DateCustomerWork
                    {
                        Id = x.Id,
                        Name = x.Name,
                        JobTitle = x.JobTitle,
                        DateTimeStartProgress = x.DateTimeStartProgress,
                        DateTimeStopProgress = x.DateTimeStopProgress,
                        Vacation = vacationDays
                    };
                })
                .Where(x => x.Vacation > minimumVacationDays)
                .ToList();

            return await Task.FromResult(usersWithVacationLeft);
        }
    }
}
