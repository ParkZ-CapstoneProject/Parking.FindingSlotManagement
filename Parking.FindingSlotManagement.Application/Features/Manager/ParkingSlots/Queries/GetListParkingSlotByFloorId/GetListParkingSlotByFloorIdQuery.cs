﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.FindingSlotManagement.Application.Features.Manager.ParkingSlots.Queries.GetListParkingSlotByFloorId
{
    public class GetListParkingSlotByFloorIdQuery : IRequest<ServiceResponse<IEnumerable<GetListParkingSlotByFloorIdResponse>>>
    {
        public int FloorId { get; set; }
    }
}
