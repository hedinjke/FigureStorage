using System.Net.Http;
using System.Threading.Tasks;
using FigureStorage.Models;
using FigureStorage.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FigureStorage.API.Controllers
{
    [Route("api/v1/figure")]
    public class FigureController : ControllerBase
    {
        private readonly IFigureRepository _repository;

        public FigureController(IFigureRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var figure = await _repository.GetAsync(id);

            if (figure == null)
                return NotFound();
            
            return Ok(figure);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Rectangle figure)
        {

            if (figure == null)
                return BadRequest();

            if (!figure.IsValid)
                return BadRequest(new {message = "Figure is not valid."});
            await _repository.AddAsync(figure);
            
            return Ok();
        }
    }
}