using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ProductCRUD.API.Handlers
{
    public class CorsMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var isCorsRequest = request.Headers.Contains("Origin");
            var isPreflightRequest = request.Method == HttpMethod.Options;

            if (isCorsRequest)
            {
                if (isPreflightRequest)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    AddCorsHeaders(request, response);
                    return Task.FromResult(response);
                }

                return base.SendAsync(request, cancellationToken).ContinueWith(task =>
                {
                    var resp = task.Result;
                    AddCorsHeaders(request, resp);
                    return resp;
                }, cancellationToken);
            }

            return base.SendAsync(request, cancellationToken);
        }

        private static void AddCorsHeaders(HttpRequestMessage request, HttpResponseMessage response)
        {
            var origin = request.Headers.GetValues("Origin").FirstOrDefault();
            if (string.IsNullOrEmpty(origin))
            {
                origin = "*";
            }

            response.Headers.TryAddWithoutValidation("Access-Control-Allow-Origin", origin == "null" ? "*" : origin);
            response.Headers.TryAddWithoutValidation("Vary", "Origin");
            response.Headers.TryAddWithoutValidation("Access-Control-Allow-Credentials", "true");
            response.Headers.TryAddWithoutValidation("Access-Control-Allow-Headers", request.Headers.Contains("Access-Control-Request-Headers")
                ? string.Join(", ", request.Headers.GetValues("Access-Control-Request-Headers"))
                : "Content-Type, Accept, Authorization");
            response.Headers.TryAddWithoutValidation("Access-Control-Allow-Methods", request.Headers.Contains("Access-Control-Request-Method")
                ? string.Join(", ", request.Headers.GetValues("Access-Control-Request-Method"))
                : "GET, POST, PUT, DELETE, OPTIONS");
        }
    }
}
