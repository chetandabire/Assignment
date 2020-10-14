using System;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Module;

namespace WebApplication1.Controllers
{
    public class VehicleController : Controller
    {
        #region GetVehicleList

        /// <summary>
        /// Get List Of Published Pages and promote values in (200,250)
        /// </summary>
        /// <param name="prms"></param>
        /// <returns></returns>
        [HttpGet("vehiclelist")]
        public dynamic Feeds([FromQuery] string prms)
        {
            #region Try Block
            try
            {

                #region Body              

                #region Functionality

                int SetStatusCode = 400;                
                if (string.IsNullOrEmpty(prms))
                    return SetStatusCode;               
                dynamic list = PagesLite.GetVehiclsList(prms);
                return list;

                #endregion Functionality

                #endregion Body
            }

            #endregion Try Block

            #region Catch Block

            catch (Exception exception)
            {
                return exception;                
            }

            #endregion Catch Block
        }

        #endregion GetVehicleList
    }
}
