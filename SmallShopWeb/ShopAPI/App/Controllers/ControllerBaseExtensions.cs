using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SmallShopWeb.ShopAPI.App.Controllers
{
    internal static class ControllerBaseExtensions
    {
        public static Task<IActionResult> HandleErrors(this ControllerBase controller,
            ILogger logger,
            Func<Task<IActionResult>> processRequest)
        {
            try
            {
                return processRequest();
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.NotFound)
            {
                logger.LogError(ex.Message);
                IActionResult result = controller.StatusCode((int)HttpStatusCode.NotFound, ex.Status.Detail);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message);
                IActionResult result = controller.StatusCode((int)HttpStatusCode.InternalServerError, "Something went wrong");
                return Task.FromResult(result);
            }
        }

    }
}
