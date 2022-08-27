using CleanArch.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class CategoryUnitTest1
{
    [Fact(DisplayName = "Create Category with Valid State")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Category Name");
        action.Should()
            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Category with Invalid Id")]
    public void CreateCategory_InvalidIdValue_ResultObjectInValidState()
    {
        Action action = () => new Category(-1, "Category Name");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value!");
    }

    [Fact(DisplayName = "Create Category with Empty Name")]
    public void CreateCategory_WithNameEmpty_ResultObjectInvalidState()
    {
        Action action = () => new Category(1, "");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Name is required!");
    }

    [Fact(DisplayName = "Create Category with Too Short Name")]
    public void CreateCategory_WithNameTooShort_ResultObjectInvalidState()
    {
        Action action = () => new Category(1, "Ab");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Name too short. Minimun 3 characters!");
    }


}