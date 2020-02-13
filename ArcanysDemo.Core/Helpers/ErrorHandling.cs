using ArcanysDemo.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using ArcanysDemo.Core.Utilities;

namespace ArcanysDemo.Core.Helpers
{
    public class ErrorHandling
    {
        /// <summary>
        /// Get the exception message
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetExceptionMessage(Exception ex)
        {
            if (ex.InnerException == null)
                return ex.Message;

            return GetExceptionMessage(ex.InnerException);
        }

        /// <summary>
        /// Logs the error 
        /// </summary>
        /// <param name="e">exception</param>
        /// <param name="severity">severity of the error</param>
        /// <returns>response object</returns>
        public static ResponseObject LogError(System.Exception e,Enums.Severity severity = Enums.Severity.Error)
        {
            ResponseObject response = new ResponseObject(ResponseType.Error, e.Message);
            Log.Error(severity + " : "+ e.Message);
            Log.Information(GetExceptionMessage(e));
            //email to support if error (defer for future development)
            return response;
        }

        /// <summary>
        /// Logs the error but with a custom message
        /// </summary>
        /// <param name="errorMessage">custom message</param>
        /// <param name="severity">severity of the error</param>
        /// <returns>response object</returns>
        public static ResponseObject LogCustomError(string errorMessage, Enums.Severity severity = Enums.Severity.Error)
        {
            ResponseObject response = new ResponseObject(ResponseType.Error, errorMessage);
            Log.Error(severity + " : " + errorMessage);
            return response;
        }
    }
}
