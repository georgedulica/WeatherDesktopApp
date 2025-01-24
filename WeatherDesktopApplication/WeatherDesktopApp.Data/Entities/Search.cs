namespace WeatherDesktopApp.Data.Entities
{
    public class Search
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public DateTimeOffset LastSearch { get; set; }
    }
}