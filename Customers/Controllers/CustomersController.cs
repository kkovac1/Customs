using Customers.API.Controllers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private static readonly List<Customer> Customers = new()
        {
            new Customer  { Id = 1, FirstName = "Marko", LastName = "Perkovic", Email = "thompson@mail.com", City= "Zagreb", BirthDate = new DateTime(1986, 2, 22) },
            new Customer  { Id = 2, FirstName = "Test", LastName = "Testic", Email = "test@mail.com", City= "Osijek", BirthDate = new DateTime(1997, 2, 22) }
        };

        private static readonly List<BasePrice> BasePrices = new()
        {
            new BasePrice  { Amount = 1000, City = "Zagreb", },
            new BasePrice  { Amount = 950, City = "Split", },
            new BasePrice  { Amount = 900, City = "Rijeka", },
            new BasePrice  { Amount = 900, City = "Osijek", },
            new BasePrice  { Amount = 800, City = "Zadar", },
            new BasePrice  { Amount = 700, City = "Other", },
        };

        private static readonly List<Discount> Discounts = new()
        {
            new Discount  { Percentage = 20, Age = "0-20", },
            new Discount  { Percentage = 10, Age = "20-30", },
            new Discount  { Percentage = 5, Age = "30-40", },
            new Discount  { Percentage = 2, Age = "40-60", },
            new Discount  { Percentage = 0, Age = "60-200", },
        };

        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ILogger<CustomersController> logger)
        {
            _logger = logger;
        }

        [HttpGet("get")]
        public ActionResult<List<Customer>> Get()
        {
            return this.Ok(Customers);
        }

        [HttpGet("get/{id}")]
        public ActionResult<Customer> GetById(int id)
        {
            var customer = Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null) return this.BadRequest("Failed to find customer by given id");

            var age = CalculateAge(customer.BirthDate);
            var basePrice = BasePrices.FirstOrDefault(x => x.City.ToLower() == customer.City.ToLower());

            if (basePrice == null) return this.BadRequest("Failed to find base price for customer city.");

            foreach (var discount in Discounts)
            {
                var rangeValues = discount.Age.Split("-");
                int lowerBound = int.Parse(rangeValues[0]);
                int upperBound = int.Parse(rangeValues[1]);

                if (age >= lowerBound && age <= upperBound)
                    customer.InsurancePrice = basePrice.Amount - (basePrice.Amount * discount.Percentage / 100);
                
            }

            return this.Ok(customer);
        }

        [HttpGet("get-cities")]
        public ActionResult<IEnumerable<string>> GetCities()
        {
            var cities = BasePrices.Select(x => x.City);
            return this.Ok(cities);
        }

        private static int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age)) age--;
            return age;
        }
    }
}
