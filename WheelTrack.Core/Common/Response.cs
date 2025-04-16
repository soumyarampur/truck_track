using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WheelTrack.Core.Common
{
    public static class Response
    {
        public static Response<T> Ok<T>(T response_payload) => new Response<T>(response_payload, "", "", true, HttpStatusCode.OK);
        public static Response<T> NoContent<T>(T response_payload) => new Response<T>(response_payload, "", "", true, HttpStatusCode.NoContent);
        public static Response<T> Created<T>(T response_payload) => new Response<T>(response_payload, "", "", true, HttpStatusCode.Created);
        public static Response<T> ValidationError<T>(string error_code, string error_message, T response_payload = default) => new Response<T>(response_payload, error_code, error_message, false, HttpStatusCode.Unauthorized);
        public static Response<T> Fail<T>(string error_code, string error_message, HttpStatusCode http_status_code = HttpStatusCode.InternalServerError, T response_payload = default) => new Response<T>(response_payload, error_code, error_message, false, http_status_code);
        public static Response<T> NotFound<T>(string error_code, string error_message, T response_payload = default) => new Response<T>(response_payload, error_code, error_message, false, HttpStatusCode.Unauthorized);
        public static Response<T> BadRequest<T>(Error error) => new Response<T>(true, HttpStatusCode.BadRequest, error);
        public static Response<T> BadRequest<T>(List<Error> errors)
        {
            return new Response<T>(HttpStatusCode.BadRequest, errors);
        }
        public static Response<T> NoContent<T>()
        {
            return new Response<T>(HttpStatusCode.NoContent);
        }

        public static Response<T> BadRequest<T>(string error_code, string error_message, HttpStatusCode http_status_code = HttpStatusCode.BadRequest, T response_payload = default) => new Response<T>(response_payload, error_code, error_message, false, http_status_code);

    }

    public class Response<T>
    {
        public Response(T response_payload, string error_code, string error_message, bool isValid, HttpStatusCode http_status_code)
        {
            this.response_payload = response_payload;
            this.error_code = error_code;
            this.error_message = error_message;
            this.isValid = isValid;
            this.http_status_code = http_status_code;
            this.CreatedId = CreatedId;
            this.CreatedResourceUrl = CreatedResourceUrl;
        }


        public Response(HttpStatusCode statusCode)
        {
            this.http_status_code = statusCode;
        }

        public Response(bool is_valid, HttpStatusCode statusCode, Error error)
        {
            this.isValid = is_valid;
            this.http_status_code = statusCode;

            if (Errors == null)
                Errors = new List<Error>();

            Errors.Add(error);
        }

        public Response(HttpStatusCode statusCode, List<Error> errors)
        {
            this.Errors = errors;
            this.http_status_code = statusCode;
        }

        public T response_payload { get; set; }
        public string error_code { get; set; }
        public string error_message { get; set; }
        public bool isValid { get; set; }
        public HttpStatusCode http_status_code { get; set; }
        public List<Error> Errors { get; set; }
        public string CreatedId { get; set; }
        public string CreatedResourceUrl { get; set; }
        public bool isSuccessStatusCode()
        {
            return http_status_code == HttpStatusCode.OK;
        }
    }
}
