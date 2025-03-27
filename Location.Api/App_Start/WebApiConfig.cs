using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Location.Api.Controllers.Country;
using Location.Api.Controllers.Login;
using Unity.Lifetime;
using Unity.WebApi;
using Unity;
using Location.Api.Utilities;
using Location.Api.Controllers.State;
using Location.Api.Utilities.Interfaces;
using static Location.Api.Utilities.Interfaces.StateService;
using Location.Api.Controllers.City;

namespace Location.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración de rutas y servicios de API
            config.MapHttpAttributeRoutes();

            config.MessageHandlers.Add(new TokenValidationHandler());

            var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            config.EnableCors(cors);

            #region Interfaces Unity
            // Configuración de Unity
            var container = new UnityContainer();
          
            container.RegisterType<ICountryService, CountryService>(new HierarchicalLifetimeManager());
            container.RegisterType<IValidationCountryService, ValidationCountryService>(new HierarchicalLifetimeManager())
                ;
            container.RegisterType<IStateService, StateService>(new HierarchicalLifetimeManager());
            container.RegisterType<IValidationStateService, ValidationStateService>(new HierarchicalLifetimeManager());

            container.RegisterType<ICityService, CityService>(new HierarchicalLifetimeManager());
            container.RegisterType<IValidationCityService, ValidationCityService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityDependencyResolver(container);
            #endregion
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            #region Login
            config.Routes.MapHttpRoute(
            name: "AuthenticateLogin",
            routeTemplate: "Login/AuthenticateToken",
            defaults: new { controller = "Login", action = "Authenticate" }
            );
            #endregion
            #region Country
            config.Routes.MapHttpRoute(
            name: "GetAllCountries",
            routeTemplate: "Country/GetAllCountries",
            defaults: new { controller = "Country", action = "GetAllCountries" }
            );
            config.Routes.MapHttpRoute(
            name: "AddCountry",
            routeTemplate: "Country/AddCountry",
            defaults: new { controller = "Country", action = "AddCountry" }
            );
            config.Routes.MapHttpRoute(
            name: "UpdateCountry",
            routeTemplate: "Country/UpdateCountry",
            defaults: new { controller = "Country", action = "UpdateCountry" }
            );
            config.Routes.MapHttpRoute(
            name: "DeleteCountry",
            routeTemplate: "Country/DeleteCountry/{CountryID}",
            defaults: new { controller = "Country", action = "DeleteCountry" }
            );
            #endregion
            #region State
            config.Routes.MapHttpRoute(
            name: "GetAllStates",
            routeTemplate: "State/GetAllStates",
            defaults: new { controller = "State", action = "GetAllStates" }
            );
            config.Routes.MapHttpRoute(
            name: "AddState",
            routeTemplate: "State/AddState",
            defaults: new { controller = "State", action = "AddState" }
            );
            config.Routes.MapHttpRoute(
            name: "UpdateState",
            routeTemplate: "State/UpdateState",
            defaults: new { controller = "State", action = "UpdateState" }
            );
            config.Routes.MapHttpRoute(
            name: "DeleteState",
            routeTemplate: "State/DeleteState/{StateID}",
            defaults: new { controller = "State", action = "DeleteState" }
            );
            #endregion
            #region City
            config.Routes.MapHttpRoute(
            name: "GetAllCities",
            routeTemplate: "City/GetAllCities",
            defaults: new { controller = "City", action = "GetAllCities" }
            );
            config.Routes.MapHttpRoute(
            name: "AddCity",
            routeTemplate: "City/AddCity",
            defaults: new { controller = "City", action = "AddCity" }
            );
            config.Routes.MapHttpRoute(
            name: "UpdateCity",
            routeTemplate: "City/UpdateCity",
            defaults: new { controller = "City", action = "UpdateCity" }
            );
            config.Routes.MapHttpRoute(
            name: "DeleteCity",
            routeTemplate: "City/DeleteCity/{CityID}",
            defaults: new { controller = "City", action = "DeleteCity" }
            );
            #endregion
        }
    }
}
