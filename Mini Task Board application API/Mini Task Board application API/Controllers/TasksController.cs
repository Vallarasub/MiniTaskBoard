using System.Data;
using Microsoft.AspNetCore.Mvc;
using Mini_Task_Board_application_API.BL;
using Mini_Task_Board_application_API.Models;

namespace Mini_Task_Board_application_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskLogic _logic;

        public TasksController(TaskLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [Route("GetTasks")]
        public IActionResult GetTasks()
        {
            try
            {
                DataTable dt = _logic.GetTasks();

                var result = new List<Dictionary<string, object>>();

                foreach (DataRow row in dt.Rows)
                {
                    var rowData = new Dictionary<string, object>();

                    foreach (DataColumn col in dt.Columns)
                    {
                        rowData[col.ColumnName] = row[col];
                    }

                    result.Add(rowData);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("CreateTask")]
        public IActionResult CreateTask([FromBody] TaskItem task)
        {
            try
            {
                _logic.CreateTask(task);
                return Ok(new { message = "Task created successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("UpdateTask")]
        public IActionResult UpdateTask([FromBody] TaskItem task)
        {
            try
            {
                _logic.UpdateTask(task);
                return Ok(new { message = "Task Updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("DeleteTask")]
        public IActionResult DeleteTask([FromBody] TaskItem task)
        {
            try
            {
                _logic.DeleteTask(task);
                return Ok(new { message = "Task Deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        //[HttpGet]
        //[Route("GetEmployees")]
        //public IActionResult GetEmployees()
        //{
        //    DataTable dt = _logic.GetEmployees();

        //    var result = new List<Dictionary<string, object>>();

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        var rowData = new Dictionary<string, object>();

        //        foreach (DataColumn col in dt.Columns)
        //        {
        //            rowData[col.ColumnName] = row[col];
        //        }

        //        result.Add(rowData);
        //    }

        //    return Ok(result);
        //}
    }
}