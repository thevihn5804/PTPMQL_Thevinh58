public class ExportDetail
{
    public int Id { get; set; }

    public int ExportId { get; set; }
    public ExportOrder ExportOrder { get; set; }

    public int DeviceId { get; set; }
    public Device Device { get; set; }

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public int ExportOrderId { get; internal set; }
}