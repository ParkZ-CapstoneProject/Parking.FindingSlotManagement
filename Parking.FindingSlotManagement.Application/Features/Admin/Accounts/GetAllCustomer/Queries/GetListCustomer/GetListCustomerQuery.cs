﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.FindingSlotManagement.Application.Features.Admin.Accounts.GetAllCustomer.Queries.GetListCustomer
{
    public class GetListCustomerQuery : IRequest<ServiceResponse<IEnumerable<GetListCustomerResponse>>>
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
    }
}
