using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.LeaveManagement.MVC.Services
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeVM>> GetLeaveTypes();
        Task<LeaveTypeVM> GetLeaveTypeDetails();
        Task<Response<int>>CreateLeaveType(CreateLeaveTypeVM leaveType);
        Task UpdateLeaveType(LeaveTypeVM leaveType);
        Task DeleteLeaveType(LeaveTypeVM leaveType);
    }
}
