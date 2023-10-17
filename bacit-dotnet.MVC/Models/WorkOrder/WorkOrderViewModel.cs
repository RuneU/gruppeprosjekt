namespace bacit_dotnet.MVC.Models.WorkOrder;

public class WorkOrderViewModel
{
    public string BookedService { get; set; }
    public string InquiryRegRec { get; set; } //inquiry recieved and handled
    public string CaseDone { get; set; }
    public string ReceivedDate { get; set; }
    public string ScheduledDelivery { get; set; }
    public string ModellYear { get; set; }
    public string ProductType { get; set; }
    public string RecievedDelivery { get; set; }
    public string ServiceDone { get; set; }
    public string HoursService { get; set; }
    public string OrderDescriptionFromCustomer { get; set; }
    public string CustomerInfo { get; set; }
    public string OrderNumber { get; set; }
    public string ServiceForm { get; set; }
}