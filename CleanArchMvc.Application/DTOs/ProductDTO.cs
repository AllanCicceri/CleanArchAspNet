using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanArch.Domain.Entities;

namespace CleanArchMvc.Application.DTOs;

public class ProductDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is Required")]
    [MinLength(3)]
    [MaxLength(100)]
    [DisplayName("Name")]
    public string Name { get; private set; } = string.Empty;

    [Required(ErrorMessage = "Description is Required")]
    [MinLength(5)]
    [MaxLength(200)]
    [DisplayName("Description")]
    public string Description { get; private set; } = string.Empty;

    [Required(ErrorMessage = "Price is Required")]
    [Column(TypeName ="decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    [DisplayName("Price")]
    public decimal Price { get; private set; } = default;

    [Required(ErrorMessage = "Stock is Required")]
    [Range(1,9999)]
    [DisplayName("Stock")]
    public int Stock { get; private set; } = default;
    
    [MaxLength(250)]
    [DisplayName("Product Image")]
    public string Image { get; private set; } = string.Empty;

    [DisplayName("Categories")]
    public int CategoryId { get; set; } = default;
    public Category? Category { get; set; } = default;
}