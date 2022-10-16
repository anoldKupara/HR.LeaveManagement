﻿using HR.LeaveManagement.Application.DTOs.LeaveAllocations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationsListRequest : IRequest<List<LeaveAllocationDto>>
    {
    }
}
