﻿using AutoMapper;
using MediatR;
using Parking.FindingSlotManagement.Application.Contracts.Infrastructure;
using Parking.FindingSlotManagement.Application.Contracts.Persistence;
using Parking.FindingSlotManagement.Application.Mapping;
using Parking.FindingSlotManagement.Application.Models;
using Parking.FindingSlotManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.FindingSlotManagement.Application.Features.Admin.Accounts.CensorshipManagerAccount.Commands.CreateNewCensorshipManagerAccount
{
    public class CreateNewCensorshipManagerAccountCommandHandler : IRequestHandler<CreateNewCensorshipManagerAccountCommand, ServiceResponse<int>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEmailService _emailService;
        MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfile());
        });

        public CreateNewCensorshipManagerAccountCommandHandler(IAccountRepository accountRepository, IEmailService emailService)
        {
            _accountRepository = accountRepository;
            _emailService = emailService;
        }
        public async Task<ServiceResponse<int>> Handle(CreateNewCensorshipManagerAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var checkExist = await _accountRepository.GetItemWithCondition(x => x.Email.Equals(request.Email));
                if (checkExist != null)
                {
                    return new ServiceResponse<int>
                    {
                        StatusCode = 400,
                        Success = false,
                        Count = 0,
                        Message = "Email đã tồn tại. Vui lòng nhập lại email!!!"
                    };
                }
                var _mapper = config.CreateMapper();
                var managerEntity = _mapper.Map<User>(request);
                await _accountRepository.Insert(managerEntity);
                EmailModel emailModel = new EmailModel();
                emailModel.To = managerEntity.Email;
                emailModel.Subject = "Tài khoản đã được doanh nghiêp ParkZ thông qua.";
                emailModel.Body = "Chào bạn, Doanh nghiệp ParkZ của chúng tôi vô cùng hân hạnh khi được liên kết và làm việc với bạn. Dưới đây là thông tin đăng nhập vào trang web quản lý bãi xe dành cho doanh nghiệp của bạn. Chúng tôi vô cùng hân hạnh được phục vụ bạn.";
                emailModel.Body +="\n Email: "+managerEntity.Email;
                emailModel.Body += "\n Password: " + managerEntity.Password;
                await _emailService.SendMail(emailModel);
                return new ServiceResponse<int>
                {
                    Data = managerEntity.UserId,
                    StatusCode = 201,
                    Success = true,
                    Count = 0,
                    Message = "Thành công"
                };
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
