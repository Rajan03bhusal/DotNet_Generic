using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenericProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>()
        {
            new SuperHero
            {
                Id = 1,
                Name="Spider Man",
                FirstName="Peter",
                LastName="Parker",
                Place="New York City",
                DateAdded=new DateTime(2024,03,10),
                DateUpdated=null
            },
           new SuperHero
           {
                Id = 2,
                Name="Iron",
                FirstName="Tony",
                LastName="Stark",
                Place="Malibu",
                DateAdded=new DateTime(2024,04,05),
                DateUpdated=null
           },
           new SuperHero
           {
                Id = 3,
                Name="Hari",
                FirstName="Hari",
                LastName="Neupane",
                Place="Butwal",
                DateAdded=new DateTime(2024,03,28),
                DateUpdated=null
           },
            new SuperHero
           {
                Id = 4,
                Name="Atal",
                FirstName="Atal",
                LastName="Thapa",
                Place="Butwal",
                DateAdded=new DateTime(2024,04,01),
                DateUpdated=null
           },
           new SuperHero
           {
                Id = 5,
                Name="Aliz",
                FirstName="Aliz",
                LastName="Nepal",
                Place="Kathmandu",
                DateAdded=new DateTime(2024,04,04),
                DateUpdated=null
           }
        };

        private readonly IMapper _Mapper;
        public SuperHeroController(IMapper Mapper)
        {
            _Mapper = Mapper;
        }
        [HttpGet]
        public ActionResult <List<SuperHero>> GetHeroes()
        {
            return Ok(heroes.Select(hero => _Mapper.Map<SuperHeroDto>(hero)));
        }

        [HttpPost]
        public ActionResult<List<SuperHero>> AddHero(SuperHeroDto newHero)
        {

            var hero=_Mapper.Map<SuperHero>(newHero);
            heroes.Add(hero);
            return Ok(heroes.Select(hero=>_Mapper.Map<SuperHeroDto>(hero)));
        }
       
    }
}
