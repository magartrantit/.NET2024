﻿using NSubstitute;
using Application.Commands;
using Application.CommandHandlers;
using Domain.Repositories;
using AutoMapper;
using Xunit;

namespace PatientManagementUnitTests
{
    public class CreatePatientCommandValidatorTests
    {
        private readonly CreatePatientCommandValidator _validator;

        public CreatePatientCommandValidatorTests()
        {
            _validator = new CreatePatientCommandValidator();
        }

        [Fact]
        public void Validate_Should_Return_False_When_FirstName_Is_Empty()
        {
            var command = new CreatePatientCommand
            {
                FirstName = string.Empty, // Testing empty FirstName
                LastName = "Doe",
                DateOfBirth = "21-02-1990",
                Gender = "Male",
                Address = "123 Main St"
            };

            var result = ValidateCommand(command);
            Assert.False(result, "Expected validation to fail when FirstName is empty.");
        }

        [Fact]
        public void Validate_Should_Return_True_When_FirstName_Is_Valid()
        {
            var command = new CreatePatientCommand
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = "21-02-1990",
                Gender = "Male",
                Address = "123 Main St"
            };

            var result = ValidateCommand(command);
            Assert.True(result, "Expected validation to pass when FirstName is valid.");
        }

        [Fact]
        public void Validate_Should_Return_False_When_LastName_Is_Empty()
        {
            var command = new CreatePatientCommand
            {
                FirstName = "John",
                LastName = string.Empty, // Testing empty LastName
                DateOfBirth = "21-02-1990",
                Gender = "Male",
                Address = "123 Main St"
            };

            var result = ValidateCommand(command);
            Assert.False(result, "Expected validation to fail when LastName is empty.");
        }

        [Fact]
        public void Validate_Should_Return_False_When_DateOfBirth_Is_Null()
        {
            var command = new CreatePatientCommand
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = null, // Testing null DateOfBirth
                Gender = "Male",
                Address = "123 Main St"
            };

            var result = ValidateCommand(command);
            Assert.False(result, "Expected validation to fail when DateOfBirth is null.");
        }

        [Fact]
        public void Validate_Should_Return_False_When_DateOfBirth_Is_Invalid_Format()
        {
            var command = new CreatePatientCommand
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = "invalid-date", // Testing invalid DateOfBirth format
                Gender = "Male",
                Address = "123 Main St"
            };

            var result = ValidateCommand(command);
            Assert.False(result, "Expected validation to fail when DateOfBirth is in an invalid format.");
        }

        [Fact]
        public void Validate_Should_Return_True_When_DateOfBirth_Is_Valid()
        {
            var command = new CreatePatientCommand
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = "21-02-1990", // Valid DateOfBirth format
                Gender = "Male",
                Address = "123 Main St"
            };

            var result = ValidateCommand(command);
            Assert.True(result, "Expected validation to pass when DateOfBirth is valid.");
        }

        [Fact]
        public void Validate_Should_Return_False_When_Gender_Is_Empty()
        {
            var command = new CreatePatientCommand
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = "21-02-1990",
                Gender = string.Empty, // Testing empty Gender
                Address = "123 Main St"
            };

            var result = ValidateCommand(command);
            Assert.False(result, "Expected validation to fail when Gender is empty.");
        }

        [Fact]
        public void Validate_Should_Return_True_When_Gender_Is_Provided()
        {
            var command = new CreatePatientCommand
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = "21-02-1990",
                Gender = "Male", // Valid Gender
                Address = "123 Main St"
            };

            var result = ValidateCommand(command);
            Assert.True(result, "Expected validation to pass when Gender is provided.");
        }

        [Fact]
        public void Validate_Should_Return_False_When_Address_Is_Empty()
        {
            var command = new CreatePatientCommand
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = "21-02-1990",
                Gender = "Male",
                Address = string.Empty // Testing empty Address
            };

            var result = ValidateCommand(command);
            Assert.False(result, "Expected validation to fail when Address is empty.");
        }

        [Fact]
        public void Validate_Should_Return_True_When_Address_Is_Provided()
        {
            var command = new CreatePatientCommand
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = "21-02-1990",
                Gender = "Male",
                Address = "123 Main St" // Valid Address
            };

            var result = ValidateCommand(command);
            Assert.True(result, "Expected validation to pass when Address is provided.");
        }

        // Helper method to validate the command
        private bool ValidateCommand(CreatePatientCommand command)
        {
            var validationResult = _validator.Validate(command);
            return validationResult.IsValid;
        }
    }
}