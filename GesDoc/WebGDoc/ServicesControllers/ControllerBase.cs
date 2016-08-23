using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;

using WebGdoc.BusquedaServRef;
using WebGdoc.DigitalizacionServRef;
using WebGdoc.GestionServRef;
using WebGdoc.PlanGestionServRef;

namespace WebGdoc.ServicesControllers
{
    public class ControllerBase
    {

#region Configuracion WCF

        /// <summary>
        /// Client tag provided by the service provider and stored locally. 
        /// This value must be provided with every service call.
        /// </summary>
        protected static string ClientTag { get; private set; }

        /// <summary>
        /// Static constructor
        /// </summary>
        static ControllerBase()
        {
            // Retrieve ClientTag from web config file
            ClientTag = ConfigurationManager.AppSettings.Get("ClientTag");
        }

        // The access token that was returned from the service.
        // This value must be provided in every call for the duration of the session.
        //private string _accessToken;

        /// <summary>
        /// Gets or sets access token. If no token exists a new one is retrieved from service.
        /// </summary>
        protected string AccessToken
        {
            get
            {
                if (HttpContext.Current.Session["AccessToken"] == null)
                {
                    // Request a unique accesstoken from the webservice. This token is
                    // that is valid for the duration of the session.                    
                }
                return (string)HttpContext.Current.Session["AccessToken"];
            }
        }

        /// <summary>
        /// Gets a new random GUID request id.
        /// </summary>
        protected string NewRequestId
        {
            get { return Guid.NewGuid().ToString(); }
        }


#endregion

        /// <summary>
        /// 
        /// </summary>
        protected BusquedaServiceClient BusquedaServiceClient
        {
            get
            {
                if (HttpContext.Current.Session["ServiceBusquedaClient"] == null)
                    HttpContext.Current.Session["ServiceBusquedaClient"] = new BusquedaServiceClient();

                return HttpContext.Current.Session["ServiceBusquedaClient"] as BusquedaServiceClient;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        protected DigitalizacionServiceClient DigitalizacionServiceClient
        {
            get
            {
                if (HttpContext.Current.Session["ServiceDigitalizacionClient"] == null)
                    HttpContext.Current.Session["ServiceDigitalizacionClient"] = new DigitalizacionServiceClient();

                return HttpContext.Current.Session["ServiceDigitalizacionClient"] as DigitalizacionServiceClient;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected GestionServiceClient GestionServiceClient
        {
            get
            {
                if (HttpContext.Current.Session["ServiceGestionClient"] == null)
                    HttpContext.Current.Session["ServiceGestionClient"] = new GestionServiceClient();

                return HttpContext.Current.Session["ServiceGestionClient"] as GestionServiceClient;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected PlanGestionServiceClient PlanGestionServiceClient
        {
            get
            {
                if (HttpContext.Current.Session["ServicePlanGestionClient"] == null)
                    HttpContext.Current.Session["ServicePlanGestionClient"] = new PlanGestionServiceClient();

                return HttpContext.Current.Session["ServicePlanGestionClient"] as PlanGestionServiceClient;
            }
        }
    }
}
