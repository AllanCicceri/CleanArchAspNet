using System.Linq.Expressions;
using CleanArch.Domain.Entities;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product:EntityBase
    {
        public string Name {get; private set;}
        public string Description {get; private set;}
        public decimal Price {get; private set;}
        public int Stock {get; private set;}
        public string Image {get; private set;}

        public int CategoryId {get; set;}
        public Category Category {get; set;}

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidadeDomain(name, description, price, stock, image);
        }
        
        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value!");
            Id = id;
            ValidadeDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidadeDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }


        private void ValidadeDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name required!");
            DomainExceptionValidation.When(name.Length < 3, "Name must have at least 3 characters!");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description required!");
            DomainExceptionValidation.When(description.Length < 5, "Description must have at least 5 characters!");
            DomainExceptionValidation.When(price < 0, "Price can't be negative!");
            DomainExceptionValidation.When(stock < 0, "Stock can't be negative!");
            DomainExceptionValidation.When(image.Length > 250, "Image length too large! Maximun 250 chars.");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
    }
    
}