using System.Threading;
using System.Web.Mvc;
using System.Threading.Tasks;
using AsyncControllerMVC4.Models;

namespace AsyncControllerMVC4.Controllers
{
    public class MyAsyncController : Controller
    {
        public async Task<ActionResult> GetData()
        {
            ViewBag.IISThreadId = Thread.CurrentThread.ManagedThreadId;
            ViewBag.МоеСвойство = "Hello";
            using (var remoteService = new RemoteService())
            {
              ViewBag.Message = await remoteService.GetRemoteDataAsync();
            }

            return View("GetData");
        }
    }
}
