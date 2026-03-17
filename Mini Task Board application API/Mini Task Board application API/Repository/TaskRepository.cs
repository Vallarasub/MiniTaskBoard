using System.Data;
using System.Data.SqlClient;
using Mini_Task_Board_application_API.Models;

namespace Mini_Task_Board_application_API.Repository
{
    public class TaskRepository
    {
        private readonly string _connectionString;

        public TaskRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public DataTable GetTasks()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("prc_GetTasks", con);
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                con.Open();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
        }

        public void CreateTask(TaskItem task)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("prc_CreateTask", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmployeeId", task.EmployeeId);
                    cmd.Parameters.AddWithValue("@Name", task.Name);
                    cmd.Parameters.AddWithValue("@Title", task.Title);
                    cmd.Parameters.AddWithValue("@Description", task.Description);
                    cmd.Parameters.AddWithValue("@Priority", task.Priority);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateTask(TaskItem task)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("prc_UpdateTask", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", task.Id);
                    cmd.Parameters.AddWithValue("@EmployeeId", task.EmployeeId);
                    cmd.Parameters.AddWithValue("@Name", task.Name ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Title", task.Title);
                    cmd.Parameters.AddWithValue("@Description", task.Description);
                    cmd.Parameters.AddWithValue("@Priority", task.Priority ?? "Low");

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteTask(TaskItem task)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("prc_DeleteTask", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", task.Id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void GetEmployees(TaskItem task)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetEmployees", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", task.Id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}