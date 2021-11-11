using GrupoAEducacaoChallenge.Domain.Validation;
using System;
using Xunit;
using FluentAssertions;


namespace GrupoAEducacaoChallenge.Domain.Tests
{
    public class AlunoDomainUnitTest
    {
        [Fact(DisplayName = "Create Aluno With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Aluno(1, "lucas.lima.pinheiro@hotmail.com", "lucas lima", 123, "010.486.3145-51");

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Aluno With Negative Id")]
        public void CreateCategory_WithNegativeId_ResultObjectValidState()
        {
            Action action = () => new Aluno(-1, "lucas.lima.pinheiro@hotmail.com", "lucas lima", 123, "010.486.3145-51");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value.");
        }

        [Theory(DisplayName = "Create Aluno With null or empty Email value")]
        [InlineData("")]
        [InlineData(null)]
        public void CreateProduct_WitNullOrEmptyEmail_DomainExceptionValidation(string email)
        {
            Action action = () => new Aluno(1, email, "lucas lima", 123, "010.486.3145-51");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid email. Email is required.");
        }       
        
        [Theory(DisplayName = "Create Aluno With null or empty Name value")]
        [InlineData("")]
        [InlineData(null)]
        public void CreateProduct_WitNullOrEmptyName_DomainExceptionValidation(string name)
        {
            Action action = () => new Aluno(1, "lucas.lima.pinheiro@hotmail.com", name, 123, "010.486.3145-51");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required.");
        }   
        
        [Theory(DisplayName = "Create Aluno With Ra equals or below zero")]
        [InlineData(0)]
        [InlineData(-1)]
        public void CreateProduct_WitNegativeOrZeroRAValue_DomainExceptionValidation(int ra)
        {
            Action action = () => new Aluno(1, "lucas.lima.pinheiro@hotmail.com", "lucas lima", ra, "010.486.3145-51");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid Ra. Ra can not be 0.");
        }
        
        [Theory(DisplayName = "Create Aluno With Ra equals or below zero")]
        [InlineData("")]
        [InlineData(null)]
        public void CreateProduct_WitNullOrEmptyCPF_DomainExceptionValidation(string cpf)
        {
            Action action = () => new Aluno(1, "lucas.lima.pinheiro@hotmail.com", "lucas lima", 123, cpf);
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid CPF. CPF is required.");
        }
    }
}