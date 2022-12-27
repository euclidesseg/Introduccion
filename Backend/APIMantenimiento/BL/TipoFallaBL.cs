

using APIMantenimiento.Models.DTOs.Client;
using APIMantenimiento.Persistance;

namespace APIMantenimiento.BL
{
    public class TipoFallaBL
    {
        TipoFallaRepository _tipoFallaRepository;
        public TipoFallaBL(TipoFallaRepository tipoFallaRepository)
        {
            _tipoFallaRepository = tipoFallaRepository;
        }

        public async Task<IReadOnlyList<TipoFallaDTO>?> GetAll()
        {
            var resulDb = await _tipoFallaRepository.GetAllAsync();
            /*entamoa a la carpeta DTOs creamos una nueva carpeta llamada cliente creamos la clase TipoFallaDTO
             poara controlar los datos que se van a enviar al cliente*/
            if (resulDb != null && resulDb.Count > 0)
                return _mapper.Map<List<ProductsDTO>>(resulDb);

            return null;
        }
    }
}
