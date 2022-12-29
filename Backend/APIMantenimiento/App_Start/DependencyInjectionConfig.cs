
using APIMantenimiento.BL;
using APIMantenimiento.Persistance;

namespace APIMantenimiento.App_Start
{
    internal static class DependencyInjectionConfig
    {
        /// <summary>
        /// Add dependencies injection configuration
        /// </summary>
        /// <param name="services"></param>
        internal static void AddDependenciesInjectionConfig(this IServiceCollection services)
        {
            #region ApplicationBL

            services.AddScoped(typeof(TipoFallaBL), typeof(TipoFallaBL));
        
            #endregion

            #region Repository
            services.AddScoped(typeof(TipoFallaRepository),typeof(TipoFallaRepository));

            #endregion
        }
    }
}
