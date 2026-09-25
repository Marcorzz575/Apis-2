using APIClaveProdServ_SAT.Dto;
using APIClaveProdServ_SAT.Repositories;

namespace APIClaveProdServ.CasosDeUso
{
    public interface IActualizaClavesProdServCasoDeUso
    {
        Task<ClaveProdServDto?> Execute(ClaveProdServDto claveProdServ);
    }

    public class ActualizaClaveProdServCasoDeUso : IActualizaClavesProdServCasoDeUso
    {
        private readonly APIClaveProdServContext _APIclaveprodservcontext;
        public ActualizaClaveProdServCasoDeUso(APIClaveProdServContext APIclaveprodservcontext)
        {
            _APIclaveprodservcontext = APIclaveprodservcontext;
        }

        public async Task<ClaveProdServDto?> Execute(ClaveProdServDto claveprodserv)
        {
            var entity = await _APIclaveprodservcontext.Get(claveprodserv.idClaveProdServ);

            if (entity == null)
            {
                return null;
            }

            entity.c_ClaveProdServ = claveprodserv.c_ClaveProdServ;
            entity.descripcion = claveprodserv.descripcion;
            entity.incluirIvaTraslado = claveprodserv.incluirIvaTraslado;
            entity.incluirIepsTraslado = claveprodserv.incluirIepsTraslado;
            entity.fechaInicioVigencia = claveprodserv.fechaInicioVigencia;
            entity.fechaFinVigencia = claveprodserv.fechaFinVigencia;
            entity.estimuloFranjaFronteriza = claveprodserv.estimuloFranjaFronteriza;
            entity.palabrasSimilares = claveprodserv.palabrasSimilares;
            entity.idStatusRegistro = claveprodserv.idStatusRegistro;

            await _APIclaveprodservcontext.Actualizar(entity);
            return entity.ToDto();
        }
    }
}