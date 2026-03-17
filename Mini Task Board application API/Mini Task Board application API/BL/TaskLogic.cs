using System.Data;
using Mini_Task_Board_application_API.Models;
using Mini_Task_Board_application_API.Repository;

namespace Mini_Task_Board_application_API.BL
{
    public class TaskLogic
    {
        private readonly TaskRepository _repo;

        public TaskLogic(TaskRepository repo)
        {
            _repo = repo;
        }

        public DataTable GetTasks()
        {
            return _repo.GetTasks();
        }

        public void CreateTask(TaskItem task)
        {
            _repo.CreateTask(task);
        }
        public void UpdateTask(TaskItem task)
        {
            _repo.UpdateTask(task);
        }
        public void DeleteTask(TaskItem task)
        {
            _repo.DeleteTask(task);
        }
        public void GetEmployees(TaskItem task)
        {
            _repo.GetEmployees(task);
        }
    }
}