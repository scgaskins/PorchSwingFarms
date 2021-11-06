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
                    Address="1909 Creekwood Dr Conway 72032",
                    FirstName="Delphia",
                    LastName="Shanks",
                    Email=null
                },
                new Customer
                {
                    Address="2010 Cleveland St (apt D-10) Conway 72032",
                    FirstName="Adam",
                    LastName="Scheider",
                    Email=null
                },
                new Customer
                {
                    Address="114 Melville Dr Maumelle 72113",
                    FirstName="Kay",
                    LastName="Smith",
                    Email=null
                },
                new Customer
                {
                    Address="4 Fairway Dr Maumelle 72113",
                    FirstName="Traci",
                    LastName="Wilis",
                    Email=null
                },
                new Customer
                {
                    Address="112 Bouriese Cir Maumelle 72113",
                    FirstName="Daris",
                    LastName="Bright",
                    Email=null
                },
                new Customer
                {
                    Address="15 Summerdale Ln Little Rock 72223",
                    FirstName="Dawne",
                    LastName="Fox",
                    Email=null
                },
                new Customer
                {
                    Address="21 Hickory Hills Cir Little Rock 72212",
                    FirstName="Debbie",
                    LastName="Goolsby",
                    Email=null
                },
                new Customer
                {
                    Address="8 Thomas Park Cir Little Rock 72223",
                    FirstName="Kasey",
                    LastName="Andis",
                    Email=null
                },
                new Customer
                {
                    Address="23 Margeaux Dr Little Rock 72223",
                    FirstName="Alese",
                    LastName="Stroud",
                    Email=null
                },
                new Customer
                {
                    Address="15 Solonge Cir (#4540) Little Rock 72223",
                    FirstName="Broke",
                    LastName="Harper",
                    Email=null
                },
                new Customer
                {
                    Address="7 Calais Ct Little Rock 72223",
                    FirstName="Vicki",
                    LastName="Moran",
                    Email=null
                },
                new Customer
                {
                    Address="9 Highfield Cv Little Rock 72211",
                    FirstName="Jessica",
                    LastName="Myers",
                    Email=null
                },
                new Customer
                {
                    Address="14101 Saint Michael Dr Little Rock 72211",
                    FirstName="Michelle",
                    LastName="Harpe",
                    Email=null
                },
                new Customer
                {
                    Address="13310 Ridgehaven Rd Little Rock 72211",
                    FirstName="Gina",
                    LastName="Daily",
                    Email=null
                },
                new Customer
                {
                    Address="43 Valley Estates Dr (#0823) Little Rock 72212",
                    FirstName="Jake",
                    LastName="Keet",
                    Email=null
                },
                new Customer
                {
                    Address="13015 Morrison Rd Little Rock 72212",
                    FirstName="Giner",
                    LastName="Young",
                    Email=null
                },
                new Customer
                {
                    Address="1400 Old Forge Dr (#702) Little Rock 72227",
                    FirstName="Mozibur",
                    LastName="Rahman",
                    Email=null
                },
                new Customer
                {
                    Address="1623 Breckenridge Little Rock 72227",
                    FirstName="Brittany",
                    LastName="Keil",
                    Email=null
                },
                new Customer
                {
                    Address="248 River Ridge Pt (#6263) Little Rock 72223",
                    FirstName="Lisa",
                    LastName="Fischer",
                    Email=null
                },
                new Customer
                {
                    Address="8 Riding Rd Little Rock 72227",
                    FirstName="Linda",
                    LastName="Hicks",
                    Email=null
                },
                new Customer
                {
                    Address="21 Leslie Circle Little Rock 72205",
                    FirstName="Christina",
                    LastName="Wren",
                    Email=null
                },
                new Customer
                {
                    Address="5 Tomahawk Rd Little Rock 72205",
                    FirstName="Jodie",
                    LastName="Dailey",
                    Email=null
                },
                new Customer
                {
                    Address="8 Archwood Rd Little 72205",
                    FirstName="Jen",
                    LastName="Boulden",
                    Email=null
                },
                new Customer
                {
                    Address="6424 Evergreen Dr Little Rock 72207",
                    FirstName="Polly",
                    LastName="Locket-Fox",
                    Email=null
                },
                new Customer
                {
                    Address="720 Hall Dr Little Rock 72205",
                    FirstName="Stephanie",
                    LastName="Matthews",
                    Email=null
                },
                new Customer
                {
                    Address="1505 Winslow Dr Littl Rock 72207",
                    FirstName="JoAnne",
                    LastName="Mills",
                    Email=null
                },
                new Customer
                {
                    Address="25 Shannon Dr  Little 72207",
                    FirstName="Sandra",
                    LastName="McGrew",
                    Email=null
                },
                new Customer
                {
                    Address="138 White Oak Ln Little Rock 72207",
                    FirstName="Sarah",
                    LastName="Coleman",
                    Email=null
                },
                new Customer
                {
                    Address="1 Sunset Dr Little Rock 72207",
                    FirstName="Hussman",
                    LastName="Hussman",
                    Email=null
                },
                new Customer
                {
                    Address="6717 Kenwood Rd Little 72207",
                    FirstName="Jason",
                    LastName="Bermingham",
                    Email=null
                },
                new Customer
                {
                    Address="2101 Durwood Rd Little Rock 72207",
                    FirstName="Elizabeth",
                    LastName="Henry-McKeever",
                    Email=null
                },
                new Customer
                {
                    Address="2410 N Fillmore St Little Rock 72207",
                    FirstName="Sarah",
                    LastName="Priebe",
                    Email=null
                },
                new Customer
                {
                    Address="1 Saint John Ct Little Rock 72207",
                    FirstName="Jennifer",
                    LastName="de Loe",
                    Email=null
                },
                new Customer
                {
                    Address="5206 Country Club Blvd Little Rock 72207",
                    FirstName="Catherine",
                    LastName="Schuhmacher",
                    Email=null
                },
                new Customer
                {
                    Address="1917 N Tyler St Little Rock 72207",
                    FirstName="Ashely",
                    LastName="Baker",
                    Email=null
                },
                new Customer
                {
                    Address="5114 Sherwood Rd Little Rock 72207",
                    FirstName="Mary Margaret",
                    LastName="Marks",
                    Email=null
                },
                new Customer
                {
                    Address="5120 Sherwood Rd Little Rock 72207",
                    FirstName="Katheryn",
                    LastName="Huff",
                    Email=null
                },
                new Customer
                {
                    Address="5300 Sherwood Rd Little Rock 72207",
                    FirstName="Lee",
                    LastName="Lee",
                    Email=null
                },
                new Customer
                {
                    Address="5400 Edgewood Rd Little Rock 72207",
                    FirstName="Brandy",
                    LastName="Wood",
                    Email=null
                },
                new Customer
                {
                    Address="5618 Edgewood Rd Little Rock 72207",
                    FirstName="Richard",
                    LastName="Blank Jr.",
                    Email=null
                },
                new Customer
                {
                    Address="5800 Edgewood Rd Little Rock 72207",
                    FirstName="Catherine",
                    LastName="Robben",
                    Email=null
                },
                new Customer
                {
                    Address="5107 Hawthorne Rd Little Rock 72207",
                    FirstName="CJ",
                    LastName="Phillips",
                    Email=null
                },
                new Customer
                {
                    Address="4817 Stonewall Little Rock 72207",
                    FirstName="Tish",
                    LastName="Delozier",
                    Email=null
                },
                new Customer
                {
                    Address="1809 N Monroe St Little Rock 72207",
                    FirstName="Chandler",
                    LastName="Bailey",
                    Email=null
                },
                new Customer
                {
                    Address="1923 N Jackson Little Rock 72207",
                    FirstName="Kevin",
                    LastName="Walsh",
                    Email=null
                }
            };

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }
    }
}
