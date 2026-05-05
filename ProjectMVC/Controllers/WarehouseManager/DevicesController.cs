using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMVC.Data;
using ProjectMVC.Models;

public class DevicesController : Controller
{
    private readonly ApplicationDBContext _context;

    public DevicesController(ApplicationDBContext context)
    {
        _context = context;
    }

    // LIST + SEARCH
    public async Task<IActionResult> Index(string keyword)
    {
        var devices = _context.Devices
            .Include(d => d.Category)
            .Include(d => d.Supplier)
            .AsQueryable();

        if (!string.IsNullOrEmpty(keyword))
        {
            devices = devices.Where(d => d.DeviceName.Contains(keyword));
        }

        return View(await devices.ToListAsync());
    }

    // CREATE
    public IActionResult Create()
    {
        ViewBag.Categories = _context.Categories.ToList();
        ViewBag.Suppliers = _context.Suppliers.ToList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Device device)
    {
        _context.Add(device);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // EDIT
    public async Task<IActionResult> Edit(int id)
    {
        var device = await _context.Devices.FindAsync(id);
        ViewBag.Categories = _context.Categories.ToList();
        ViewBag.Suppliers = _context.Suppliers.ToList();
        return View(device);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Device device)
    {
        _context.Update(device);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // DELETE
    public async Task<IActionResult> Delete(int id)
    {
        var device = await _context.Devices.FindAsync(id);
        _context.Devices.Remove(device);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}