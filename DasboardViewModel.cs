namespace part3_mvc_consume.Models
{
    public class DashboardViewModel
    {

        public int TotalEvents { get; set; }
        public int MyRaces { get; set; }
        public int Upcoming { get; set; }
        public int Completed { get; set; }
        public string RawEvents { get; set; } = "";
        public string RawEnrolments { get; set; } = "";

    }
}
