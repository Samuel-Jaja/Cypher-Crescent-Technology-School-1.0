
using System.Net;
using Microsoft.AspNetCore.Mvc;
using StaffManagement.Models;
using StaffManagement.Services;

namespace StaffManagement.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DepartmentController:ControllerBase
    {
        CustomDbContext _dbContext { get; }
        ILogger<Staff> _logger;

        public DepartmentController(ILogger<Staff> logger, CustomDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }


        //http://localhost:5001/Department/bydepartmentId?bydepartmenid=[-]

        [HttpGet("bydepartmenId")]
        public IActionResult GetDepartmentModels(int departmentid)
        {
            try
            {

                var data = _dbContext.Departments.Where(x => x.DepartmentId == departmentid);
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                _logger.LogError("An Error Occurred");
                return BadRequest(ex.Message);
            }
        }


        //http://localhost:5001/Department/bydepartmentName?departmentname=[-]

        [HttpGet("bydepartmentName")]
        public IActionResult GetDepartmentModels(string departmentname)
        {
            try
            {

                var data = _dbContext.Departments.Where(x => x.DepartmentName == departmentname);
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                _logger.LogError("An Error Occurred");
                return BadRequest(ex.Message);
            }
        }

        //http://localhost:5001/Department

        [HttpGet]
        public IActionResult GetDepartmentModels()
        {
            try
            {
               
                var data = _dbContext.Departments.ToList();
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                _logger.LogError("An Error Occurred");
                return BadRequest(ex.Message);
            }
        }

        //http://localhost:5001/Department
        [HttpPost]
        public IActionResult AddNewModels([FromBody] Department department )
        {
            try
            {
                var data = _dbContext.Departments.Add(department);
                _dbContext.SaveChanges();
                return Ok(department);
            }
            catch (System.Exception ex)
            {
                _logger.LogError("An Error Occurred");
                return BadRequest(ex.Message);
            }
        }

        //http://localhost:5001/Depatment
        [HttpPut]
        public IActionResult UpdateDeparmentModel([FromBody] string departmentId)
        {
            try
            {

                var updatedDepartment = _dbContext.Departments.Find(departmentId);
                if (updatedDepartment != null)
                {
                    updatedDepartment.DepartmentName = updatedDepartment.DepartmentName;
                    updatedDepartment.DepartmentId = updatedDepartment.DepartmentId;
                    //updatedDepartment.Staff.StaffName = updatedDepartment.Staff.StaffName;
                    _dbContext.Departments.Update(updatedDepartment);
                    _dbContext.SaveChanges();
                    return Ok(updatedDepartment);
                }
                else
                {
                    return BadRequest("Failed Process");
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //http://localhost:5001/Department
        [HttpDelete]
        public IActionResult DeleteDepartmentModel(int departmentId)
        {
            try
            {
                var data = _dbContext.Departments.Find(departmentId);
                if (data != null)
                {
                    _dbContext.Departments.Remove(data);
                    _dbContext.SaveChanges();
                    return Ok(data);
                }
                return BadRequest("Failed Process");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
