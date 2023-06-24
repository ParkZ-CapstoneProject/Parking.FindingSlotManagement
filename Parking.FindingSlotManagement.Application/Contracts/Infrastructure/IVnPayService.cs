﻿using Microsoft.AspNetCore.Http;
using Parking.FindingSlotManagement.Application.Models;
using Parking.FindingSlotManagement.Application.Models.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.FindingSlotManagement.Application.Contracts.Infrastructure
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(BookingTransaction model, string tmnCode, string hashSecret, HttpContext context);
        PaymentResponseModel PaymentExecute(IQueryCollection collections);
    }
}