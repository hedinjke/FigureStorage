using System.Threading.Tasks;
using AutoMapper;
using FigureStorage.API.Models;
using FigureStorage.DTO;
using FigureStorage.Models;
using FigureStorage.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FigureStorage.API.Controllers
{
    [Route("[controller]")]
    public class FigureController : ControllerBase
    {
        private readonly IFigureRepository _repository;
        private readonly IMapper _mapper;

        public FigureController(IFigureRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var figure = await _repository.GetAsync(id);

            if (figure == null)
                return NotFound();

            var figureDTO = _mapper.Map<FigureDTO>(figure);
            
            return Ok(figureDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Figure figure)
        {
            if (figure == null)
                return BadRequest(new BadRequestMsgResponse("Bad request. Can't create any figure from that."));
            if (!figure.IsValid)
                return BadRequest(new BadRequestMsgResponse("Figure is not valid."));

            figure.Id = default;
            
            await _repository.AddAsync(figure);
            
            return Ok(new FigurePostResponse(figure));
        }
    }
}