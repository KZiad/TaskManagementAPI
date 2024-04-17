namespace Task_Management.Models
{
    public class UpdateTaskRequest
    {
        public string? TaskDetails { get; set; }

        public StatusEnum? Status { get; set; }

        public DateTime? DueDate { get; set; }  
    }
}
