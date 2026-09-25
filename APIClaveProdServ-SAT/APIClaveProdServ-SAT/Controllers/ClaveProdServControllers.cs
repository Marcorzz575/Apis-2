using APIClaveProdServ_SAT.Dto;
using APIClaveProdServ_SAT.Repositories;
using APIClaveProdServ.CasosDeUso;
using Microsoft.AspNetCore.Mvc;

namespace APIClaveProdServ_SAT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClaveProdServControllers : Controller
    {
        private readonly APIClaveProdServContext _APIclaveprodservcontext;
        private readonly IActualizaClavesProdServCasoDeUso _actualizaClavesProdServCasoDeUso;
        public ClaveProdServControllers(APIClaveProdServContext APIclaveprodservcontext, IActualizaClavesProdServCasoDeUso actualizaClavesProdServCasoDeUso)
        {
            _APIclaveprodservcontext = APIclaveprodservcontext;
            _actualizaClavesProdServCasoDeUso = actualizaClavesProdServCasoDeUso;

        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ClaveProdServDto>))]
        public async Task<IActionResult> TraeClavesProdServ()
        {
            var result = _APIclaveprodservcontext.ClaveProdServ.Select(c => c.ToDto()).ToList();
            return new OkObjectResult(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClaveProdServDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> TraeClaveProdServ(int id)
        {
            ClaveProdServEntity result = await _APIclaveprodservcontext.Get(id);
            if (result == null)
                return new NotFoundResult();
            return new OkObjectResult(result.ToDto());
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminaClaveProdServ(int id)
        {

            var result = await _APIclaveprodservcontext.Delete(id);
            if (result == false)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ClaveProdServDto))]
        public async Task<IActionResult> CreaClaveProdServ(CreaClaveProdServDto claveprdserv)
        {
            ClaveProdServEntity result = await _APIclaveprodservcontext.Add(claveprdserv);
            return new CreatedResult($"https://localhost:5167/api/claveprodserv/{result.idClaveProdServ}", null);
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ClaveProdServDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ActualizaClaveProdServ(ClaveProdServDto claveprodserv)
        {
            ClaveProdServDto? result = await _actualizaClavesProdServCasoDeUso.Execute(claveprodserv);
            if (result == null)
                return new NotFoundResult();

            return new OkObjectResult(result);
        }
    }
}
