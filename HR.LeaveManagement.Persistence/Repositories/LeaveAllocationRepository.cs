﻿using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly HrLeaveManagementDbContext _dbContext;

        public LeaveAllocationRepository(HrLeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int Id)
        {
            var leaveAllocation = await _dbContext.LeaveAllocations
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == Id);  

            return leaveAllocation;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
        {
            var leaveAllocations = await _dbContext.LeaveAllocations
                .Include(q => q.LeaveType)
                .ToListAsync();

            return leaveAllocations;
        }
    }
}