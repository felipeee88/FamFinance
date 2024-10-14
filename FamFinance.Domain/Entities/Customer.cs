namespace FamFinance.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }

        public bool IsSpecialCustomer(Customer customer)
        {
            return customer.IsActive && DateTime.Now.Year - customer.RegistrationDate.Year >= 5;
        }
    }
}
