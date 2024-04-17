namespace Task_Management.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public required string TaskDetails { get; set; }

        public  StatusEnum Status { get; set; } = StatusEnum.NotStarted;

        public required DateTime DueDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime LastUpdatedAt { get; set; } = DateTime.Now;



    }
}