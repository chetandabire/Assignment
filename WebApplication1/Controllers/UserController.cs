using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Module;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        #region PostToSignup
        /// <summary>
        /// create new user
        /// </summary>
       
        [HttpPost]
        [Route("signup")]
        public object PostToSignup([FromBody] UserLite user)
        {
            #region Try Block
            try
            {
                #region Functionality
                    string scopeKey = null;
                    scopeKey = UserLite.Post(user, out int statusCode);
                    return statusCode;
                #endregion Functionality
            }

            #endregion Try Block

            #region Catch Block

            catch (Exception exception)
            {
                #region Body
                    return exception;
                #endregion Body               
            }

            #endregion Catch Block
        }

        #endregion PostToSignup

        #region UpdateUser

        [HttpPut]
        [Route("update")]
        public object UpdateUser([FromBody] UserLite user)
        {
            #region Try Block
            try
            {
                #region Functionality
                string scopeKey = null;
                scopeKey = UserLite.Update(user, out int statusCode);
                return statusCode;
                #endregion Functionality
            }

            #endregion Try Block

            #region Catch Block

            catch (Exception exception)
            {
                #region Body
                return exception;
                #endregion Body               
            }

            #endregion Catch Block
        }

        #endregion UpdateUser

    }
}
