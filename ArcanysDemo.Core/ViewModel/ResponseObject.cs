using System;
using System.Collections.Generic;
using System.Text;

namespace ArcanysDemo.Core.ViewModel
{
    public class ResponseObject
    {
        public ResponseObject()
        {
            StatusId = (int)ResponseType.Undefined;

            Message = String.Empty;
        }

        public ResponseObject(ResponseType statusCode, string message)
        {
            StatusId = (int)statusCode;

            Message = message;
        }

        public ResponseObject(ResponseType statusCode, string message, dynamic data)
        {
            StatusId = (int)statusCode;

            Message = message;

            Data = data;
        }

        public int StatusId { get; set; }

        public string Message { get; set; }

        public bool IsSuccess
        {
            get
            {
                return ((ResponseType)StatusId) == ResponseType.Success;
            }
        }

        public bool IsWarning
        {
            get
            {
                return ((ResponseType)StatusId) == ResponseType.Warning;
            }
        }

        public bool IsCached
        {
            get
            {
                return ((ResponseType)StatusId) == ResponseType.IsCached;
            }
        }

        public dynamic Data { get; set; }
    }

    public enum ResponseType
    {
        Undefined = 0,

        Error = 1,

        Information = 2,

        Warning = 3,

        Success = 4,

        Critical = 5,

        IsCached = 6
    }

}
