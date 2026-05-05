public class ExportOrder
{
    public int ExportId { get; set; }
    public DateTime ExportDate { get; set; }

    public string CustomerName { get; set; }

    public List<ExportDetail> ExportDetails { get; set; }
    public int ExportOrderId { get; internal set; }
    public decimal TotalAmount { get; internal set; }
}