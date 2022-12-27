using APIMantenimiento.Models.Entities;
using Dapper;
using System.Data.SqlClient;
using SP = APIMantenimiento.Models.Vaiables.Procedures;

namespace APIMantenimiento.Persistance
{
    public class TipoFallaRepository
    {
        private readonly string? _database;
        public TipoFallaRepository(IConfiguration configuration)
        {        /*la conecction string se agrega en el appsettings.json*/
            _database = configuration.GetConnectionString("DbConnectionSecurity");
        }

        public async Task<IReadOnlyList<TipoFalla>> GetAllAsync()
        {
            using var conn = new SqlConnection(_database);
            var result = await conn.QueryAsync<TipoFalla>($"{SP.EXEC} {SP.MAESTROS_SP_TIPOFALLA_GETALL}");
            await conn.CloseAsync();
            await conn.DisposeAsync();
            return result.ToList();
        }
    }
}
