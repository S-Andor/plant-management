namespace PlantCareAPI.Models
{
    public class Plant
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Species { get; set; }
        public string Location { get; set; } 
        
        public DateTime LastWatered { get; set; }
        public int WateringIntervalDays { get; set; }

        public string Notes { get; set; }
        public string ImageUrl { get; set; }
        
        public string UserId { get; set; }
    }
}