﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.FindingSlotManagement.Application.Models.Booking
{
    public class BookingTransaction
    {
        public decimal? TotalPrice { get; set; }
        public string? ParkingSlotName { get; set; }
    }
}
