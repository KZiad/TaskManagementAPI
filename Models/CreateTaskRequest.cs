namespace Task_Management.Models
{
    public class CreateTaskRequest
    {
        public required string TaskDetails { get; set; }
        public required DateTime DueDate { get; set; }
    }
}
