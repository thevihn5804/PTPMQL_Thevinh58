using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMVC.Data;
using ProjectMVC.Models;

namespace WarehouseManager.Controllers
{
    public class ExportOrdersController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ExportOrdersController(ApplicationDBContext context)
        {
            _context = context;
        }

      
        public async Task<IActionResult> Index()
        {
            var data = await _context.ExportOrders
                .Include(e => e.ExportDetails)
                    .ThenInclude(d => d.Device)
                .ToListAsync();

            return View(data);
        }

   
        public async Task<IActionResult> Details(int id)
        {
            var order = await _context.ExportOrders
                .Include(e => e.ExportDetails)
                    .ThenInclude(d => d.Device)
                .FirstOrDefaultAsync(e => e.ExportOrderId == id);

            if (order == null) return NotFound();

            return View(order);
        }


        public IActionResult Create()
        {
            ViewBag.Devices = _context.Devices.ToList();
            return View();
        }

    
        [HttpPost]
        public async Task<IActionResult> Create(ExportOrder order)
        {
            // 1. Lưu phiếu xuất trước
            _context.ExportOrders.Add(order);
            await _context.SaveChangesAsync();

            decimal total = 0;

            // 2. Xử lý từng dòng chi tiết
            foreach (var item in order.ExportDetails)
            {
                var device = await _context.Devices.FindAsync(item.DeviceId);

                //  Không tồn tại thiết bị
                if (device == null)
                {
                    return NotFound("Thiết bị không tồn tại");
                }

                //  Không đủ hàng
                if (device.Quantity < item.Quantity)
                {
                    return BadRequest($"Không đủ hàng: {device.DeviceName}");
                }

                // ➖ Trừ tồn kho
                device.Quantity -= item.Quantity;

                // Tính tiền
                item.UnitPrice = device.Price; // lấy giá hiện tại
                item.TotalPrice = item.Quantity * item.UnitPrice;

                item.ExportOrderId = order.ExportOrderId;

                total += item.TotalPrice;

                _context.ExportDetails.Add(item);
            }

            // 3. Tổng tiền phiếu
            order.TotalAmount = total;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // ================== DELETE ==================
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _context.ExportOrders
                .Include(e => e.ExportDetails)
                .FirstOrDefaultAsync(e => e.ExportOrderId == id);

            if (order == null) return NotFound();

            //  Hoàn lại kho khi xóa
            foreach (var item in order.ExportDetails)
            {
                var device = await _context.Devices.FindAsync(item.DeviceId);
                if (device != null)
                {
                    device.Quantity += item.Quantity;
                }
            }

            _context.ExportDetails.RemoveRange(order.ExportDetails);
            _context.ExportOrders.Remove(order);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}