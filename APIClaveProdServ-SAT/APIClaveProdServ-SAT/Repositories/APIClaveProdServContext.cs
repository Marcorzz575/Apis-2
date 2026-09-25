using APIClaveProdServ_SAT.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIClaveProdServ_SAT.Repositories
{
    public class APIClaveProdServContext : DbContext
    {
        public APIClaveProdServContext(DbContextOptions<APIClaveProdServContext> options) : base(options)
        {

        }
        public DbSet<ClaveProdServEntity> ClaveProdServ { get; set; }
        public async Task<ClaveProdServEntity?> Get(int id)
        {
            return await ClaveProdServ.FirstOrDefaultAsync(x => x.idClaveProdServ == id);
        }

        public async Task<ClaveProdServEntity> Add(CreaClaveProdServDto ClaveProdServDto)
        {
            ClaveProdServEntity entity = new ClaveProdServEntity()
            {
                idClaveProdServ = 0, // O default/0 si es autoincrementable (IDENTITY) en la BD
                c_ClaveProdServ = ClaveProdServDto.c_ClaveProdServ,
                descripcion = ClaveProdServDto.descripcion,
                incluirIvaTraslado = ClaveProdServDto.incluirIvaTraslado,
                incluirIepsTraslado = ClaveProdServDto.incluirIepsTraslado,
                fechaInicioVigencia = ClaveProdServDto.fechaInicioVigencia,
                fechaFinVigencia = ClaveProdServDto.fechaFinVigencia,
                estimuloFranjaFronteriza = ClaveProdServDto.estimuloFranjaFronteriza,
                palabrasSimilares = ClaveProdServDto.palabrasSimilares,
                idStatusRegistro = ClaveProdServDto.idStatusRegistro,
            };

            EntityEntry<ClaveProdServEntity> response = await ClaveProdServ.AddAsync(entity);
            await SaveChangesAsync();

            return await Get(response.Entity.idClaveProdServ) ?? throw new Exception("No se ha podido Guardar.");
        }

        public async Task<bool> Delete(int id)
        {
            ClaveProdServEntity entity = await Get(id);
            if (entity == null)
            {
                return false;
            }
            else
            {
                ClaveProdServ.Remove(entity);
                SaveChanges();
                return true;
            }
        }

        public async Task<bool> Actualizar(ClaveProdServEntity claveprodservEntity)
        {
            ClaveProdServ.Update(claveprodservEntity);
            await SaveChangesAsync();
            return true;
        }
    }
    [Table("c_ClaveProdServ_SAT")]
    public class ClaveProdServEntity
    {
        [Key]
        [Column("idClaveProdServ")]
        public int idClaveProdServ { get; set; }

        [Column("c_ClaveProdServ")]
        public string? c_ClaveProdServ { get; set; }

        [Column("Descripcion")]
        public string? descripcion { get; set; }

        [Column("Incluir_IVA_trasladado")]
        public string? incluirIvaTraslado { get; set; }

        [Column("Incluir_IEPS_trasladado")]
        public string? incluirIepsTraslado { get; set; }

        [Column("FechaInicioVigencia")]
        public DateOnly? fechaInicioVigencia { get; set; } // Anulable

        [Column("FechaFinVigencia")]
        public DateOnly? fechaFinVigencia { get; set; }     // Anulable

        [Column("Estimulo_Franja_Fronteriza")]
        public string? estimuloFranjaFronteriza { get; set; }

        [Column("Palabras_similares")]
        public string? palabrasSimilares { get; set; }

        [Column("idStatusRegistro")]
        public int? idStatusRegistro { get; set; }

        public ClaveProdServDto ToDto()
        {
            return new ClaveProdServDto
            {
                idClaveProdServ = idClaveProdServ,
                c_ClaveProdServ = c_ClaveProdServ,
                descripcion = descripcion,
                incluirIvaTraslado = incluirIvaTraslado,
                incluirIepsTraslado = incluirIepsTraslado,
                fechaInicioVigencia = fechaInicioVigencia,
                fechaFinVigencia = fechaFinVigencia,
                estimuloFranjaFronteriza = estimuloFranjaFronteriza,
                palabrasSimilares = palabrasSimilares,
                idStatusRegistro = idStatusRegistro
            };
        }
    }
}
