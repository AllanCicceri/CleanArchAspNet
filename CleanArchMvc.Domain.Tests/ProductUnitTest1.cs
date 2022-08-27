using CleanArch.Domain.Entities;
using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class ProductUnitTest1
{
    [Fact(DisplayName = "Create Product with Valid State")]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product(1, "Product Name", "Product Desc", 9.99m, 10, "Blablalslslslslslslsl");
        action.Should()
            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Product with InValid State")]
    public void CreateProduct_WithInValidParameters_ResultObjectInValidState()
    {
        Action action = () => new Product(1, "Pr", "Prodcut descri", 9.99m, 10, "Blablalslslslslslslsl");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Name must have at least 3 characters!");
    }

    
    [Fact(DisplayName = "Create Product with Null image")]
    public void CreateProduct_WithNullImage_NotThrowNullException()
    {
        Action action = () => new Product(1, "Pr", "Prodcut descri", 9.99m, 10, null!);
        action.Should()
            .NotThrow<NullReferenceException>();
    }

    [Theory]
    [InlineData(-5)]
    public void CreateProduct_WithInValidStock_ResultObjectInValidState(int stock)
    {
        Action action = () => new Product(1, "Product", "Prodcut descri", 9.99m, stock, "Blablalslslslslslslsl");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Stock can't be negative!");
    }

}