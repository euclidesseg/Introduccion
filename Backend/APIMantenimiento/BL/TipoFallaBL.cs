

using APIMantenimiento.Models.DTOs.Client;
using APIMantenimiento.Persistance;
using AutoMapper;

namespace APIMantenimiento.BL
{
    public class TipoFallaBL
    {
        TipoFallaRepository _tipoFallaRepository;
        IMapper _mapper;
        public TipoFallaBL(TipoFallaRepository tipoFallaRepository, IMapper mapper)
            /*creamos el constructor para tipo fallas */
            /* en este constructor es donde se van a inyectar las dependencias*/
        {
            _mapper = mapper;    
            _tipoFallaRepository = tipoFallaRepository;
        }

        public async Task<IReadOnlyList<TipoFallaDTO>?> GetAll()
        {
            var resulDb = await _tipoFallaRepository.GetAllAsync();
            if (resulDb != null && resulDb.Count > 0) {
                return _mapper.Map<List<TipoFallaDTO>>(resulDb);

            } 
            return null;
        }
    }
}
