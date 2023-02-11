namespace geekible.todo.models
{
    public class BaseModel
    {
        public string ID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDateTime { get; set; } = DateTime.Now;
    }
}