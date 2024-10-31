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

        private List<DateCustomerWork> CalculateVacation( int startVacation, int daysSinceStop, List<DateCustomerWork> customerWork)
        {
            int vacationThreshold = startVacation;
     
            var usersWithVacationLeft = customerWork
                .Where(x => x.Vacation > vacationThreshold && x.Vacation >= daysSinceStop)
                .ToList();

            return usersWithVacationLeft;
        }
    }
}
