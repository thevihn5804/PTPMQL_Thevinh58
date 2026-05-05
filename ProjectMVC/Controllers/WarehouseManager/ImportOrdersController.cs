using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMVC.Data;

public class ImportOrdersController : Controller
{
    private readonly ApplicationDBContext _context;

    public ImportOrdersController(ApplicationDBContext context)
    {
        _context = context;
    }

    // LIST
    public async Task<IActionResult> Index()
    {
        var data = _context.ImportOrders
            .Include(i => i.Supplier);

        return View(await data.ToListAsync());
    }

    // CREATE GET
    public IActionResult Create()
    {
        ViewBag.Devices = _context.Devices.ToList();
        ViewBag.Suppliers = _context.Suppliers.ToList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ImportOrder order)
    {
    _context.ImportOrders.Add(order);
    await _context.SaveChangesAsync();

    foreach (var item in order.ImportDetails)
    {
        var device = await _context.Devices.FindAsync(item.DeviceId);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            device.Quantity += item.Quantity;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            item.TotalPrice = item.Quantity * item.UnitPrice;
        item.ImportId = order.ImportId;

        _context.ImportDetails.Add(item);
    }

    await _context.SaveChangesAsync();

    return RedirectToAction("Index");
    }
}