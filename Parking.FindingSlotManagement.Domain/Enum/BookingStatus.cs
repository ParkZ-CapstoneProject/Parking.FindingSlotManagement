﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.FindingSlotManagement.Domain.Enum
{
    public enum BookingStatus
    {
        Initial,
        Success,
        Check_In,
        Check_Out,
        Waiting_For_Payment,
        Payment_Successed,
        Done,
        Cancel

    }
}