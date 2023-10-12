using bacit_dotnet;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using bacit_dotnet.MVC.Models.WorkOrder;
using bacit_dotnet.MVC.Views.FormsMain;


namespace bacit_dotnet.MVC.Controllers
{
    public class WorkOrderController : Controller
    {
        public IActionResult WorkOrder()
        {
            var model = new WorkOrderViewModel
                {

                    BookedService = "",
                    InquiryRegRec = "",
                    CaseDone = "",
                    ReceivedDate = "",
                    ModellYear = "",
                    ScheduledDelivery = "",
                    ProductType = "",
                    RecievedDelivery = "",
                    ServiceDone = "",
                    HoursService = "",
                    OrderDescriptionFromCustomer = "",
                    CustomerInfo = "",
                    OrderNumber = "",
                    ServiceForm = "",
                }
                ;
            return View(model);
        }

        [HttpPost]
        public IActionResult Save(WorkOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var s = "ineedabreakpoint";
            }

            return View("WorkOrder", model);
        }
    }
}