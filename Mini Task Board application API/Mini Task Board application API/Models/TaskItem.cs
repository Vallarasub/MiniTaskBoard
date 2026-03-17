namespace Mini_Task_Board_application_API.Models
{
    public class TaskItem
    {
        public int Id { get; set; }      
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; } = "Low";
    }
}
