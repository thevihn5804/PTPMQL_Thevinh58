public class ImportDetail
{
    public int Id { get; set; }

    public int ImportId { get; set; }
    public ImportOrder ImportOrder { get; set; }

    public int DeviceId { get; set; }
    public Device Device { get; set; }

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public object ImportOrderId { get; internal set; }
}