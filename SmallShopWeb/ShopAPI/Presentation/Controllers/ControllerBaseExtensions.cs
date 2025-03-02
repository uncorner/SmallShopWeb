using System.Net;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;

namespace SmallShopWeb.ShopAPI.Presentation.Controllers
{
    internal static class ControllerBaseExtensions
    {
        public static async Task<IActionResult> HandleErrors(this ControllerBase controller,
            ILogger logger,
            Func<Task<IActionResult>> processRequest)
        {
            try
            {
                return await processRequest();
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.NotFound)
            {
                logger.LogError(ex.Message);
                return controller.StatusCode((int)HttpStatusCode.NotFound, ex.Status.Detail);
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message);
                return controller.StatusCode((int)HttpStatusCode.InternalServerError, "Something went wrong");
            }
        }
        

    }
}
