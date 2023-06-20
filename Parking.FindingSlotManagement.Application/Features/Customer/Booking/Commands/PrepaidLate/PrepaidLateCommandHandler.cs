﻿using MediatR;
using Microsoft.Extensions.Configuration;
using Parking.FindingSlotManagement.Application.Contracts.Infrastructure;
using Parking.FindingSlotManagement.Application.Contracts.Persistence;
using Parking.FindingSlotManagement.Application.Models.Booking;
using Parking.FindingSlotManagement.Application.Models.PushNotification;
using Parking.FindingSlotManagement.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Parking.FindingSlotManagement.Application.Features.Customer.Booking.Commands.PrepaidLate
{
    public class PrepaidLateCommandHandler : IRequestHandler<PrepaidLateCommand, ServiceResponse<string>>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IParkingRepository _parkingRepository;
        private readonly IUserRepository _userRepository;
        private readonly IVnPayService _vnPayService;
        private readonly IConfiguration _configuration;
        private readonly IFireBaseMessageServices _fireBaseMessageServices;

        public PrepaidLateCommandHandler(IBookingRepository bookingRepository, IParkingRepository parkingRepository, IUserRepository userRepository, IVnPayService vnPayService, IConfiguration configuration, IFireBaseMessageServices fireBaseMessageServices)
        {
            _bookingRepository = bookingRepository;
            _parkingRepository = parkingRepository;
            _userRepository = userRepository;
            _vnPayService = vnPayService;
            _configuration = configuration;
            _fireBaseMessageServices = fireBaseMessageServices;
        }
        public async Task<ServiceResponse<string>> Handle(PrepaidLateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                List<Expression<Func<Domain.Entities.Booking, object>>> includes = new List<Expression<Func<Domain.Entities.Booking, object>>>
                {
                    x => x.ParkingSlot,
                    x => x.User
                };
                var booking = await _bookingRepository.GetItemWithCondition(x => x.BookingId == request.BookingId, includes, false);
                if (booking == null)
                {
                    return new ServiceResponse<string>
                    {
                        Message = "Không tìm thấy đơn đặt.",
                        Success = true,
                        StatusCode = 200
                    };
                }
                var parking = await _parkingRepository.GetById(request.ParkingId);
                if (parking == null)
                {
                    return new ServiceResponse<string>
                    {
                        Message = "Không tìm thấy bãi giữ xe.",
                        StatusCode = 200,
                        Success = true
                    };
                }
                List<Expression<Func<Domain.Entities.User, object>>> includesUser = new List<Expression<Func<Domain.Entities.User, object>>>
                {
                    x => x.VnPays
                };
                var businessAcc = await _userRepository.GetItemWithCondition(x => x.UserId == parking.ManagerId, includesUser, true);
                if (businessAcc == null)
                {
                    return new ServiceResponse<string>
                    {
                        Message = "Không tìm thấy tài khoản doanh nghiệp.",
                        StatusCode = 200,
                        Success = true
                    };
                }
                if(booking.Status.Equals(BookingStatus.Check_Out.ToString()))
                {
                    if(request.PaymentMethod.Equals(Domain.Enum.PaymentMethod.thanh_toan_tien_mat.ToString()))
                    {
                        booking.Status = BookingStatus.Payment_Successed.ToString();
                        await _bookingRepository.Save();
                        var titleCustomer = _configuration.GetSection("MessageTitle_Customer").GetSection("Payment_Success").Value;
                        var bodyCustomer = _configuration.GetSection("MessageBody_Customer").GetSection("Payment_Success").Value;

                        var pushNotificationMobile = new PushNotificationMobileModel
                        {
                            Title = titleCustomer,
                            Message = bodyCustomer,
                            TokenMobile = booking.User.Devicetoken,
                        };

                        await _fireBaseMessageServices.SendNotificationToMobileAsync(pushNotificationMobile);
                        return new ServiceResponse<string>
                        {
                            Message = "Thành công",
                            Success = true,
                            StatusCode = 201
                        };
                    }
                    else if(request.PaymentMethod.Equals(Domain.Enum.PaymentMethod.thanh_toan_online.ToString()))
                    {
                        BookingTransaction bt = new BookingTransaction
                        {
                            ParkingSlotName = booking.ParkingSlot.Name,
                            TotalPrice = (decimal)booking.ActualPrice
                        };
                        var url = _vnPayService.CreatePaymentUrl(bt, businessAcc.VnPays.FirstOrDefault().TmnCode, businessAcc.VnPays.FirstOrDefault().HashSecret, request.context);
                        return new ServiceResponse<string>
                        {
                            Data = url,
                            Message = "Thành công",
                            StatusCode = 201,
                            Success = true
                        };
                    }
                }
                return new ServiceResponse<string>
                {
                    Message = "Trạng thái của đơn không hợp lệ để thực hiện chức năng.",
                    StatusCode = 400,
                    Success = false
                };
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
