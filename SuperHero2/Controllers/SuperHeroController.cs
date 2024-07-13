using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHero2Api.Data;

namespace SuperHero2Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
       

        private readonly DateContext _context;

        public SuperHeroController (DateContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Gethero()
        {
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Getheroid(int id)
        {
            var hero=await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                return BadRequest("Hero not found");
            }
            return Ok(hero);
        }



        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero addsuperhero)
        {
            _context.SuperHeroes.Add(addsuperhero);
            _context.SaveChanges();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPut]

        public async Task<ActionResult<List<SuperHero>>> updateHero(SuperHero updatesuperhero)
        {
            var hero = await _context.SuperHeroes.FindAsync(updatesuperhero.Id);
            if (hero == null)
            {
                return BadRequest("Hero not found");
            }

            hero.Name = updatesuperhero.Name;
            hero.FirstName = updatesuperhero.FirstName;
            hero.LastName = updatesuperhero.LastName;
            hero.Place= updatesuperhero.Place;

            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }


        [HttpDelete]
        public async Task<ActionResult<List<SuperHero>>> deleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                return BadRequest("Hero not found");
            }

            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }








        //[HttpGet]
        //public async Task<ActionResult<List<SuperHero>>> Get()
        //{
        //    var heros = new List<SuperHero>()
        //    {
        //       new SuperHero
        //       {
        //           Id= 1,
        //           Name="Spider Men",
        //           FirstName="Peter",
        //           LastName="Parker",
        //           Place="New York"
        //       }

        //    };

        //    return  Ok(heros);
        //}


    }
}
