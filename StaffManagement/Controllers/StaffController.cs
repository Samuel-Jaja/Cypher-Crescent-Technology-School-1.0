using System.Net;
using Microsoft.AspNetCore.Mvc;
using StaffManagement.Models;
using StaffManagement.Services;

namespace StaffManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StaffController: ControllerBase
    {

        CustomDbContext _dbContext { get; }
        ILogger<Staff> _logger;

        public StaffController(ILogger<Staff> logger, CustomDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        //http://localhost:5001/Staff/byId?id=[-]
        [HttpGet("byId")]
        public IActionResult GetStaffModel(int id)
        {
            try
            {
                var data = _dbContext.StaffList.Where(x => x.Id == id);
                _logger.LogInformation("User Fetched Succesfully");
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                _logger.LogError("An Error Occurred");
                return BadRequest(ex.Message);
            }
        }

        //http://localhost:5001/Staff
        
        [HttpGet]
        public IActionResult GetStaffModels()
        {
            try
            {
                //var data=DataRepository.GetAllCustomers();
                var data = _dbContext.StaffList.ToList();
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                _logger.LogError("An Error Occurred");
                return BadRequest(ex.Message);
            }
        }

        //http://localhost:5001/Staff
        [HttpPost]
        public IActionResult AddNewModels([FromBody] Staff staff)
        {
            try
            {
                var data = _dbContext.StaffList.Add(staff);
                _dbContext.SaveChanges();
                return Ok(staff);
            }
            catch (System.Exception ex)
            {
                _logger.LogError("An Error Occurred");
                return BadRequest(ex.Message);
            }
        }

        //http://localhost:5001/Staff
        [HttpPut]
        public IActionResult UpdateModel([FromBody] Staff staff, int id)
        {
            try
            {
                
                var updatedStaff = _dbContext.StaffList.Find(id);
                if (updatedStaff != null)
                {
                    updatedStaff.StaffName = staff.StaffName;
                    updatedStaff.StaffId = staff.StaffId;
                    updatedStaff.StaffPhoneNumber = staff.StaffPhoneNumber;
                    _dbContext.StaffList.Update(updatedStaff);
                    _dbContext.SaveChanges();
                    return Ok(updatedStaff);
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

        //http://localhost:5001/Staff
        [HttpDelete]
        public IActionResult DeleteModel(int id)
        {
            try
            {
                var data = _dbContext.StaffList.Find(id);
                if (data != null)
                {
                    _dbContext.StaffList.Remove(data);
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
