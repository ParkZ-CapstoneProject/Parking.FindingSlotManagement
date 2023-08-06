﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.FindingSlotManagement.Application.Features.Manager.KeeperAccount.KeeperAccountManagement.Commands.CreateNewAccountForKeeper
{
    public class CreateNewAccountForKeeperCommandValidation : AbstractValidator<CreateNewAccountForKeeperCommand>
    {
        public CreateNewAccountForKeeperCommandValidation()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Vui lòng nhập {Name}.")
                .NotNull()
                .MaximumLength(30).WithMessage("{Name} không được nhập quá 30 kí tự");
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("Vui lòng nhập {Email}.")
                .EmailAddress().WithMessage("Email không đúng định dạng.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Email} không được nhập quá 50 kí tự");
            RuleFor(p => p.Phone)
                .NotEmpty().WithMessage("Vui lòng nhập {Phone}.")
                .NotNull()
                .Must(x => int.TryParse(x, out _)).WithMessage("{Phone} là chữ số.")
                .Length(10).WithMessage("{Phone} cần phải nhập 10 chữ số.");
            RuleFor(p => p.Avatar)
                .NotEmpty().WithMessage("Vui lòng nhập {Avatar}")
                .NotNull();
            RuleFor(p => p.DateOfBirth)
                .NotEmpty().WithMessage("Vui lòng nhập {DateOfBirth}.")
                .NotNull()
                .LessThanOrEqualTo(DateTime.UtcNow.AddHours(7)).WithMessage("{DateOfBirth} cần phải nhỏ hơn ngày hiện tại");
            RuleFor(p => p.Gender)
                .NotEmpty().WithMessage("Vui lòng nhập {Gender}.")
                .NotNull()
                .MaximumLength(10).WithMessage("{Gender} không được nhập quá 10 kí tự");
        }
    }
}
