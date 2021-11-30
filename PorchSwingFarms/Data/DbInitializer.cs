using System;
using System.Linq;
using PorchSwingFarms.Models;

namespace PorchSwingFarms.Data
{
    public class DbInitializer
    {
        public static void Initialize(FarmContext context)
        {
            if (context.Customers.Any())
            {
                return;
            }

            var customers = new Customer[]
            {
                new Customer{
                    Address="1909 Creekwood Dr",
                    City="Conway",
                    ZipCode=72032,
                    FirstName="Delphia",
                    LastName="Shanks",
                    Email=null
                },
                new Customer
                {
                    Address="2010 Cleveland St",
                    City="Conway",
                    ZipCode=72032,
                    ApartmentNum="D-10",
                    FirstName="Adam",
                    LastName="Scheider",
                    Email=null
                },
                new Customer
                {
                    Address="114 Melville Dr",
                    City="Maumelle",
                    ZipCode=72113,
                    FirstName="Kay",
                    LastName="Smith",
                    Email=null
                },
                new Customer
                {
                    Address="4 Fairway Dr",
                    City="Maumelle",
                    ZipCode=72113,
                    FirstName="Traci",
                    LastName="Wilis",
                    Email=null
                },
                new Customer
                {
                    Address="112 Bouriese Cir",
                    City="Maumelle",
                    ZipCode=72113,
                    FirstName="Daris",
                    LastName="Bright",
                    Email=null
                },
                new Customer
                {
                    Address="15 Summerdale Ln",
                    City="Little Rock",
                    ZipCode=72223,
                    FirstName="Dawne",
                    LastName="Fox",
                    Email=null
                },
                new Customer
                {
                    Address="21 Hickory Hills Cir",
                    City="Little Rock",
                    ZipCode=72212,
                    FirstName="Debbie",
                    LastName="Goolsby",
                    Email=null
                },
                new Customer
                {
                    Address="8 Thomas Park Cir",
                    City="Little Rock",
                    ZipCode=72223,
                    FirstName="Kasey",
                    LastName="Andis",
                    Email=null
                },
                new Customer
                {
                    Address="23 Margeaux Dr",
                    City="Little Rock",
                    ZipCode=72223,
                    FirstName="Alese",
                    LastName="Stroud",
                    Email=null
                },
                new Customer
                {
                    Address="15 Solonge Cir",
                    City="Little Rock",
                    ZipCode=72223,
                    ApartmentNum="#4540",
                    FirstName="Broke",
                    LastName="Harper",
                    Email=null
                },
                new Customer
                {
                    Address="7 Calais Ct",
                    City="Little Rock",
                    ZipCode=72223,
                    FirstName="Vicki",
                    LastName="Moran",
                    Email=null
                },
                new Customer
                {
                    Address="9 Highfield Cv",
                    City="Little Rock",
                    ZipCode=72211,
                    FirstName="Jessica",
                    LastName="Myers",
                    Email=null
                },
                new Customer
                {
                    Address="14101 Saint Michael Dr",
                    City="Little Rock",
                    ZipCode=72211,
                    FirstName="Michelle",
                    LastName="Harpe",
                    Email=null
                },
                new Customer
                {
                    Address="13310 Ridgehaven Rd",
                    City="Little Rock",
                    ZipCode=72211,
                    FirstName="Gina",
                    LastName="Daily",
                    Email=null
                },
                new Customer
                {
                    Address="43 Valley Estates Dr",
                    City="Little Rock",
                    ZipCode=72212,
                    ApartmentNum="#0823",
                    FirstName="Jake",
                    LastName="Keet",
                    Email=null
                },
                new Customer
                {
                    Address="13015 Morrison Rd",
                    City="Little Rock",
                    ZipCode=72212,
                    FirstName="Giner",
                    LastName="Young",
                    Email=null
                },
                new Customer
                {
                    Address="1400 Old Forge Dr",
                    City="Little Rock",
                    ZipCode=72227,
                    ApartmentNum="#702",
                    FirstName="Mozibur",
                    LastName="Rahman",
                    Email=null
                },
                new Customer
                {
                    Address="1623 Breckenridge",
                    City="Little Rock",
                    ZipCode=72227,
                    FirstName="Brittany",
                    LastName="Keil",
                    Email=null
                },
                new Customer
                {
                    Address="248 River Ridge Pt",
                    City="Little Rock",
                    ZipCode=72223,
                    ApartmentNum="#6263",
                    FirstName="Lisa",
                    LastName="Fischer",
                    Email=null
                },
                new Customer
                {
                    Address="8 Riding Rd",
                    City="Little Rock",
                    ZipCode=72227,
                    FirstName="Linda",
                    LastName="Hicks",
                    Email=null
                },
                new Customer
                {
                    Address="21 Leslie Circle",
                    City="Little Rock",
                    ZipCode=72205,
                    FirstName="Christina",
                    LastName="Wren",
                    Email=null
                },
                new Customer
                {
                    Address="5 Tomahawk Rd",
                    City="Little Rock",
                    ZipCode=72205,
                    FirstName="Jodie",
                    LastName="Dailey",
                    Email=null
                },
                new Customer
                {
                    Address="8 Archwood Rd",
                    City="Little Rock",
                    ZipCode=72205,
                    FirstName="Jen",
                    LastName="Boulden",
                    Email=null
                },
                new Customer
                {
                    Address="6424 Evergreen Dr",
                    City="Little Rock",
                    ZipCode=72207,
                    FirstName="Polly",
                    LastName="Locket-Fox",
                    Email=null
                },
                new Customer
                {
                    Address="720 Hall Dr",
                    City="Little Rock",
                    ZipCode=72205,
                    FirstName="Stephanie",
                    LastName="Matthews",
                    Email=null
                },
                new Customer
                {
                    Address="1505 Winslow Dr",
                    City="Little Rock",
                    ZipCode=72207,
                    FirstName="JoAnne",
                    LastName="Mills",
                    Email=null
                },
                new Customer
                {
                    Address="25 Shannon Dr",
                    City="Little Rock",
                    ZipCode=72207,
                    FirstName="Sandra",
                    LastName="McGrew",
                    Email=null
                },
                new Customer
                {
                    Address="138 White Oak Ln",
                    City="Little Rock",
                    ZipCode=72207,
                    FirstName="Sarah",
                    LastName="Coleman",
                    Email=null
                },
                new Customer
                {
                    Address="1 Sunset Dr",
                    City="Little Rock",
                    ZipCode=72207,
                    FirstName="Hussman",
                    LastName="Hussman",
                    Email=null
                },
                new Customer
                {
                    Address="6717 Kenwood Rd",
                    City="Little Rock",
                    ZipCode=72207,
                    FirstName="Jason",
                    LastName="Bermingham",
                    Email=null
                },
                new Customer
                {
                    Address="2101 Durwood Rd",
                    City="Little Rock",
                    ZipCode=72207,
                    FirstName="Elizabeth",
                    LastName="Henry-McKeever",
                    Email=null
                },
                new Customer
                {
                    Address="2410 N Fillmore St",
                    City="Little Rock",
                    ZipCode=72207,
                    FirstName="Sarah",
                    LastName="Priebe",
                    Email=null
                },
                new Customer
                {
                    Address="1 Saint John Ct",
                    City="Little Rock",
                    ZipCode=72207,
                    FirstName="Jennifer",
                    LastName="de Loe",
                    Email=null
                },
                new Customer
                {
                    Address="5206 Country Club Blvd",
                    City="Little Rock",
                    ZipCode=72207,
                    FirstName="Catherine",
                    LastName="Schuhmacher",
                    Email=null
                },
                new Customer
                {
                    Address="1917 N Tyler St",
                    City="Little Rock",
                    ZipCode=72207,
                    FirstName="Ashely",
                    LastName="Baker",
                    Email=null
                },
                new Customer
                {
                    Address="5114 Sherwood Rd",
                    City="Little Rock",
                    ZipCode=72207,
                    FirstName="Mary Margaret",
                    LastName="Marks",
                    Email=null
                },
                new Customer
                {
                    Address="5120 Sherwood Rd",
                    City="Little Rock",
                    ZipCode=72207,
                    FirstName="Katheryn",
                    LastName="Huff",
                    Email=null
                },
                new Customer
                {
                    Address="5300 Sherwood Rd",
                    City="Little Rock",
                    ZipCode=72207,
                    FirstName="Lee",
                    LastName="Lee",
                    Email=null
                },
                new Customer
                {
                    Address="5400 Edgewood Rd",
                    City="Little Rock",
                    ZipCode=72207,
                    FirstName="Brandy",
                    LastName="Wood",
                    Email=null
                },
                new Customer
                {
                    Address="5618 Edgewood Rd",
                    City="Little Rock",
                    ZipCode=72207,
                    FirstName="Richard",
                    LastName="Blank Jr.",
                    Email=null
                },
                new Customer
                {
                    Address="5800 Edgewood Rd",
                    City="Little Rock",
                    ZipCode=72207,
                    FirstName="Catherine",
                    LastName="Robben",
                    Email=null
                },
                new Customer
                {
                    Address="5107 Hawthorne Rd",
                    City="Little Rock",
                    ZipCode=72207,
                    FirstName="CJ",
                    LastName="Phillips",
                    Email=null
                },
                new Customer
                {
                    Address="4817 Stonewall",
                    City="Little Rock",
                    ZipCode=72207,
                    FirstName="Tish",
                    LastName="Delozier",
                    Email=null
                },
                new Customer
                {
                    Address="1809 N Monroe St",
                    City="Little Rock",
                    ZipCode=72207,
                    FirstName="Chandler",
                    LastName="Bailey",
                    Email=null
                },
                new Customer
                {
                    Address="1923 N Jackson",
                    City="Little Rock",
                    ZipCode=72207,
                    FirstName="Kevin",
                    LastName="Walsh",
                    Email=null
                }
            };

            context.Customers.AddRange(customers);

            var testCustomer = new Customer
            {
                Address="1600 Washington Ave",
                City="Conway",
                ZipCode=72032,
                FirstName="Test",
                LastName="Test",
                Email="testte@hendrix.edu"
            };

            context.Customers.Add(testCustomer);

            var testSubscription = new Subscription
            {
                Price = 6.00M,
                Quantity = 2,
                Frequency = 2,
                StartDate = DateTime.Parse("2021-11-27"),
                Customer = testCustomer,
            };

            context.Subscriptions.Add(testSubscription);

            var testOrder = new Order 
            {
                DeliveredYN=false,
                PaidForYN=false,
                DeliveryDate = DateTime.Parse("2021-11-27"),
                Subscription=testSubscription
            };
            context.Orders.Add(testOrder);

            context.SaveChanges();
        }
    }
}
