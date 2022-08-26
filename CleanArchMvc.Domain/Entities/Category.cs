using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;

namespace CleanArch.Domain.Entities
{
    public sealed class Category:EntityBase
    {
        public string Name {get; private set;}

        public ICollection<Product> Products {get; set;}

        public Category(string name)
        {
            ValidadeDomain(name);           
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value!");
            Id = id;
            ValidadeDomain(name);            
        }

        public void Update(string name)
        {
            ValidadeDomain(name);
        }

        private void ValidadeDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required!");
            DomainExceptionValidation.When(name.Length < 3, "Name too short. Minimun 3 characters!");
            Name = name;
        }
    }
    
}