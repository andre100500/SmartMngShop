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

        private List<DateCustomerWork> CalculateVacation( int startVacation, DateTime stop,List<DateCustomerWork> customerWork)
        {
            Vacation = startVacation;
            var currentDate = DateTime.UtcNow;
            var lastDateVacation = currentDate.Day - stop.Day;
            

            if (startVacation >= lastDateVacation)
            {
                var userId = customerWork.Where(x => x.Id == Id && x.Name == Name && x.Vacation >= 0).ToList();
                return userId.ToList();
            }
            return customerWork;
        }
    }
}
