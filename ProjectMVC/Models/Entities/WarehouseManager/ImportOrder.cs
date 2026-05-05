public class ImportOrder
{
    public int ImportId { get; set; }
    public DateTime ImportDate { get; set; }

    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; }

    public List<ImportDetail> ImportDetails { get; set; }
    public int TotalAmount { get; internal set; }
    public object ImportOrderId { get; internal set; }
}