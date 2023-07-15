﻿//using FluentValidation.TestHelper;
//using Moq;
//using Parking.FindingSlotManagement.Application.Contracts.Persistence;
//using Parking.FindingSlotManagement.Application.Features.Manager.Account.RegisterCensorshipBusinessAccount.Commands.RegisterBusinessAccount;
//using Shouldly;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Parking.FindingSlotManagement.Application.UnitTests.HandlerTesting.Manager.Account.RegisterCensorshipBusinessAccount.RegisterBusinessAccount
//{
//    public class RegisterBusinessAccountCommandHandlerTests
//    {
//        private readonly Mock<IUserRepository> _userRepositoryMock;
//        private readonly Mock<IBusinessProfileRepository> _businessProfileRepositoryMock;
//        private readonly RegisterBusinessAccountValidation _validator;
//        private readonly RegisterBusinessAccountCommandHandler _handler;
//        public RegisterBusinessAccountCommandHandlerTests()
//        {
//            _userRepositoryMock = new Mock<IUserRepository>();
//            _businessProfileRepositoryMock = new Mock<IBusinessProfileRepository>();
//            _validator = new RegisterBusinessAccountValidation();
//            _handler = new RegisterBusinessAccountCommandHandler(_userRepositoryMock.Object, _businessProfileRepositoryMock.Object);
//        }
//        [Fact]
//        public async Task Handle_WhenCreatedSuccessfully_ReturnsCreated()
//        {
//            // Arrange
//            var request = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Email = "test@gmail.com", Avatar="string", Name = "test", Password = "123456", Phone = "0123456789"},
//                BusinessProfileEntity = new BusinessProfileEntity { Name = "Test347", Address = "string", BackIdentification = "string", BusinessLicense = "string", FrontIdentification = "string"}
//            };

//            // Act
//            var response = await _handler.Handle(request, CancellationToken.None);

//            // Assert
//            response.ShouldNotBeNull();
//            response.StatusCode.ShouldBe(201);
//            response.Success.ShouldBeTrue();
//            response.Count.ShouldBe(0);
//            response.Message.ShouldBe("Thành công");
//        }
//        [Fact]
//        public void Name_ShouldNotBeEmpty()
//        {
//            var command = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Email = "test@gmail.com", Avatar = "string", Name = "", Password = "123456", Phone = "0123456789" },
//                BusinessProfileEntity = new BusinessProfileEntity { Name = "Test347", Address = "string", BackIdentification = "string", BusinessLicense = "string", FrontIdentification = "string" }
//            };

//            var result = _validator.TestValidate(command);

//            result.ShouldHaveValidationErrorFor(x => x.UserEntity.Name);
//        }
//        [Fact]
//        public void Name_ShouldNotBeNull()
//        {
//            var command = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Email = "test@gmail.com", Avatar = "string", Password = "123456", Phone = "0123456789" },
//                BusinessProfileEntity = new BusinessProfileEntity { Name = "Test347", Address = "string", BackIdentification = "string", BusinessLicense = "string", FrontIdentification = "string" }
//            };

//            var result = _validator.TestValidate(command);

//            result.ShouldHaveValidationErrorFor(x => x.UserEntity.Name);
//        }
//        [Fact]
//        public void Name_ShouldNotExceedMaximumLength()
//        {
//            var command = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Email = "test@gmail.com", Avatar = "string", Name = "testtesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttest", Password = "123456", Phone = "0123456789" },
//                BusinessProfileEntity = new BusinessProfileEntity { Name = "Test347", Address = "string", BackIdentification = "string", BusinessLicense = "string", FrontIdentification = "string" }
//            };

//            var result = _validator.TestValidate(command);

//            result.ShouldHaveValidationErrorFor(x => x.UserEntity.Name);
//        }
//        [Fact]
//        public void Email_ShouldNotBeEmpty()
//        {
//            var command = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Email = "", Avatar = "string", Name = "test", Password = "123456", Phone = "0123456789" },
//                BusinessProfileEntity = new BusinessProfileEntity { Name = "Test347", Address = "string", BackIdentification = "string", BusinessLicense = "string", FrontIdentification = "string" }
//            };

//            var result = _validator.TestValidate(command);

//            result.ShouldHaveValidationErrorFor(x => x.UserEntity.Email);
//        }
//        [Fact]
//        public void Email_ShouldNotBeNull()
//        {
//            var command = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Avatar = "string", Name = "test", Password = "123456", Phone = "0123456789" },
//                BusinessProfileEntity = new BusinessProfileEntity { Name = "Test347", Address = "string", BackIdentification = "string", BusinessLicense = "string", FrontIdentification = "string" }
//            };

//            var result = _validator.TestValidate(command);

//            result.ShouldHaveValidationErrorFor(x => x.UserEntity.Email);
//        }
//        [Fact]
//        public void Email_ShouldNotExceedMaximumLength()
//        {
//            var command = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Email = "testestestestestestestestesttestestestestestestestestesttestestestestestestestestesttestestestestestestestestesttestestestestestestestestesttestestestestestestestestesttestestestestestestestestesttestestestestestestestestest@gmail.com", Avatar = "string", Name = "test", Password = "123456", Phone = "0123456789" },
//                BusinessProfileEntity = new BusinessProfileEntity { Name = "Test347", Address = "string", BackIdentification = "string", BusinessLicense = "string", FrontIdentification = "string" }
//            };

//            var result = _validator.TestValidate(command);

//            result.ShouldHaveValidationErrorFor(x => x.UserEntity.Email);
//        }
//        [Fact]
//        public void Email_DoestNotMatchFormat()
//        {
//            var command = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Email = "test", Avatar = "string", Name = "test", Password = "123456", Phone = "0123456789" },
//                BusinessProfileEntity = new BusinessProfileEntity { Name = "Test347", Address = "string", BackIdentification = "string", BusinessLicense = "string", FrontIdentification = "string" }
//            };

//            var result = _validator.TestValidate(command);

//            result.ShouldHaveValidationErrorFor(x => x.UserEntity.Email);
//        }
//        [Fact]
//        public void Password_ShouldNotBeEmpty()
//        {
//            var command = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Email = "test@gmail.com", Avatar = "string", Name = "test", Password = "", Phone = "0123456789" },
//                BusinessProfileEntity = new BusinessProfileEntity { Name = "Test347", Address = "string", BackIdentification = "string", BusinessLicense = "string", FrontIdentification = "string" }
//            };

//            var result = _validator.TestValidate(command);

//            result.ShouldHaveValidationErrorFor(x => x.UserEntity.Password);
//        }
//        [Fact]
//        public void Password_ShouldNotBeNull()
//        {
//            var command = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Email = "test@gmail.com", Avatar = "string", Name = "test", Phone = "0123456789" },
//                BusinessProfileEntity = new BusinessProfileEntity { Name = "Test347", Address = "string", BackIdentification = "string", BusinessLicense = "string", FrontIdentification = "string" }
//            };

//            var result = _validator.TestValidate(command);

//            result.ShouldHaveValidationErrorFor(x => x.UserEntity.Password);
//        }
//        [Fact]
//        public void Phone_ShouldNotBeNull()
//        {
//            var command = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Email = "test@gmail.com", Avatar = "string", Name = "test", Password = "123456"},
//                BusinessProfileEntity = new BusinessProfileEntity { Name = "Test347", Address = "string", BackIdentification = "string", BusinessLicense = "string", FrontIdentification = "string" }
//            };

//            var result = _validator.TestValidate(command);

//            result.ShouldHaveValidationErrorFor(x => x.UserEntity.Phone);
//        }
//        [Fact]
//        public void Phone_ShouldBeNumbers()
//        {
//            var command = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Email = "test@gmail.com", Avatar = "string", Name = "test", Password = "123456", Phone = "adsfasd" },
//                BusinessProfileEntity = new BusinessProfileEntity { Name = "Test347", Address = "string", BackIdentification = "string", BusinessLicense = "string", FrontIdentification = "string" }
//            };

//            var result = _validator.TestValidate(command);

//            result.ShouldHaveValidationErrorFor(x => x.UserEntity.Phone);
//        }
//        [Fact]
//        public void Phone_ShouldNotExceedMaximumLength()
//        {
//            var command = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Email = "test@gmail.com", Avatar = "string", Name = "test", Password = "123456", Phone = "01234567891111" },
//                BusinessProfileEntity = new BusinessProfileEntity { Name = "Test347", Address = "string", BackIdentification = "string", BusinessLicense = "string", FrontIdentification = "string" }
//            };

//            var result = _validator.TestValidate(command);

//            result.ShouldHaveValidationErrorFor(x => x.UserEntity.Phone);
//        }
//        [Fact]
//        public void Avatar_ShouldNotBeEmpty()
//        {
//            var command = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Email = "test@gmail.com", Avatar = "", Name = "test", Password = "123456", Phone = "0123456789" },
//                BusinessProfileEntity = new BusinessProfileEntity { Name = "Test347", Address = "string", BackIdentification = "string", BusinessLicense = "string", FrontIdentification = "string" }
//            };

//            var result = _validator.TestValidate(command);

//            result.ShouldHaveValidationErrorFor(x => x.UserEntity.Avatar);
//        }

//        [Fact]
//        public void Avatar_ShouldNotBeNull()
//        {
//            var command = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Email = "test@gmail.com", Name = "test", Password = "123456", Phone = "0123456789" },
//                BusinessProfileEntity = new BusinessProfileEntity { Name = "Test347", Address = "string", BackIdentification = "string", BusinessLicense = "string", FrontIdentification = "string" }
//            };

//            var result = _validator.TestValidate(command);

//            result.ShouldHaveValidationErrorFor(x => x.UserEntity.Avatar);
//        }
//        [Fact]
//        public void BusinessProfileEntity_Name_ShouldNotBeEmpty()
//        {
//            var command = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Email = "test@gmail.com", Avatar = "string", Name = "test", Password = "123456", Phone = "0123456789" },
//                BusinessProfileEntity = new BusinessProfileEntity { Name = "", Address = "string", BackIdentification = "string", BusinessLicense = "string", FrontIdentification = "string" }
//            };

//            var result = _validator.TestValidate(command);

//            result.ShouldHaveValidationErrorFor(x => x.BusinessProfileEntity.Name);
//        }
//        [Fact]
//        public void BusinessProfileEntity_Name_ShouldNotBeNull()
//        {
//            var command = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Email = "test@gmail.com", Avatar = "string", Name = "test", Password = "123456", Phone = "0123456789" },
//                BusinessProfileEntity = new BusinessProfileEntity { Address = "string", BackIdentification = "string", BusinessLicense = "string", FrontIdentification = "string" }
//            };

//            var result = _validator.TestValidate(command);

//            result.ShouldHaveValidationErrorFor(x => x.BusinessProfileEntity.Name);
//        }
//        [Fact]
//        public void BusinessProfileEntity_Name_ShouldNotExceedMaximumLength()
//        {
//            var command = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Email = "test@gmail.com", Avatar = "string", Name = "test", Password = "123456", Phone = "0123456789" },
//                BusinessProfileEntity = new BusinessProfileEntity { Name = "Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347Test347", Address = "string", BackIdentification = "string", BusinessLicense = "string", FrontIdentification = "string" }
//            };

//            var result = _validator.TestValidate(command);

//            result.ShouldHaveValidationErrorFor(x => x.BusinessProfileEntity.Name);
//        }
//        [Fact]
//        public void BusinessProfileEntity_Address_ShouldNotBeEmpty()
//        {
//            var command = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Email = "test@gmail.com", Avatar = "string", Name = "test", Password = "123456", Phone = "0123456789" },
//                BusinessProfileEntity = new BusinessProfileEntity { Name = "Test347", Address = "", BackIdentification = "string", BusinessLicense = "string", FrontIdentification = "string" }
//            };

//            var result = _validator.TestValidate(command);

//            result.ShouldHaveValidationErrorFor(x => x.BusinessProfileEntity.Address);
//        }
//        [Fact]
//        public void BusinessProfileEntity_Address_ShouldNotBeNull()
//        {
//            var command = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Email = "test@gmail.com", Avatar = "string", Name = "test", Password = "123456", Phone = "0123456789" },
//                BusinessProfileEntity = new BusinessProfileEntity { Name = "Test347", BackIdentification = "string", BusinessLicense = "string", FrontIdentification = "string" }
//            };

//            var result = _validator.TestValidate(command);

//            result.ShouldHaveValidationErrorFor(x => x.BusinessProfileEntity.Address);
//        }
//        [Fact]
//        public void BusinessProfileEntity_Address_ShouldNotExceedMaximumLength()
//        {
//            var command = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Email = "test@gmail.com", Avatar = "string", Name = "test", Password = "123456", Phone = "0123456789" },
//                BusinessProfileEntity = new BusinessProfileEntity { Name = "Test347", Address = "stringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstring", BackIdentification = "string", BusinessLicense = "string", FrontIdentification = "string" }
//            };

//            var result = _validator.TestValidate(command);

//            result.ShouldHaveValidationErrorFor(x => x.BusinessProfileEntity.Address);
//        }
//        [Fact]
//        public void BusinessProfileEntity_FrontIdentification_ShouldNotBeEmpty()
//        {
//            var command = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Email = "test@gmail.com", Avatar = "string", Name = "test", Password = "123456", Phone = "0123456789" },
//                BusinessProfileEntity = new BusinessProfileEntity { Name = "Test347", Address = "string", BackIdentification = "string", BusinessLicense = "string", FrontIdentification = "" }
//            };

//            var result = _validator.TestValidate(command);

//            result.ShouldHaveValidationErrorFor(x => x.BusinessProfileEntity.FrontIdentification);
//        }
//        [Fact]
//        public void BusinessProfileEntity_FrontIdentification_ShouldNotBeNull()
//        {
//            var command = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Email = "test@gmail.com", Avatar = "string", Name = "test", Password = "123456", Phone = "0123456789" },
//                BusinessProfileEntity = new BusinessProfileEntity { Name = "Test347", Address = "string", BackIdentification = "string", BusinessLicense = "string" }
//            };

//            var result = _validator.TestValidate(command);

//            result.ShouldHaveValidationErrorFor(x => x.BusinessProfileEntity.FrontIdentification);
//        }
//        [Fact]
//        public void BusinessProfileEntity_BackIdentification_ShouldNotBeEmpty()
//        {
//            var command = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Email = "test@gmail.com", Avatar = "string", Name = "test", Password = "123456", Phone = "0123456789" },
//                BusinessProfileEntity = new BusinessProfileEntity { Name = "Test347", Address = "string", BackIdentification = "", BusinessLicense = "string", FrontIdentification = "string" }
//            };

//            var result = _validator.TestValidate(command);

//            result.ShouldHaveValidationErrorFor(x => x.BusinessProfileEntity.BackIdentification);
//        }
//        [Fact]
//        public void BusinessProfileEntity_BackIdentification_ShouldNotBeNull()
//        {
//            var command = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Email = "test@gmail.com", Avatar = "string", Name = "test", Password = "123456", Phone = "0123456789" },
//                BusinessProfileEntity = new BusinessProfileEntity { Name = "Test347", Address = "string", BusinessLicense = "string", FrontIdentification = "string" }
//            };

//            var result = _validator.TestValidate(command);

//            result.ShouldHaveValidationErrorFor(x => x.BusinessProfileEntity.BackIdentification);
//        }
//        [Fact]
//        public void BusinessProfileEntity_BusinessLicense_ShouldNotBeEmpty()
//        {
//            var command = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Email = "test@gmail.com", Avatar = "string", Name = "test", Password = "123456", Phone = "0123456789" },
//                BusinessProfileEntity = new BusinessProfileEntity { Name = "Test347", Address = "string", BackIdentification = "string", BusinessLicense = "", FrontIdentification = "string" }
//            };

//            var result = _validator.TestValidate(command);

//            result.ShouldHaveValidationErrorFor(x => x.BusinessProfileEntity.BusinessLicense);
//        }
//        [Fact]
//        public void BusinessProfileEntity_BusinessLicense_ShouldNotBeNull()
//        {
//            var command = new RegisterBusinessAccountCommand
//            {
//                UserEntity = new UserEntity { Email = "test@gmail.com", Avatar = "string", Name = "test", Password = "123456", Phone = "0123456789" },
//                BusinessProfileEntity = new BusinessProfileEntity { Name = "Test347", Address = "string", BackIdentification = "string", FrontIdentification = "string" }
//            };

//            var result = _validator.TestValidate(command);

//            result.ShouldHaveValidationErrorFor(x => x.BusinessProfileEntity.BusinessLicense);
//        }
//    }
//}
