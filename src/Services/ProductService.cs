using Microsoft.EntityFrameworkCore;
using services_order_search.Database;
using services_order_search.Models;

public class OrderService
{
    private readonly DBContext _context;

    public OrderService(DBContext context)
    {
        _context = context;
    }

    public async Task<List<Orders>> GetAllOrdersAsync()
    {
        return await _context.Orders.Where( x => x.Status == true).ToListAsync();
    }

    public async Task<Orders> GetOrderByCodeAsync(string orderCode)
    {
        return await _context.Orders.FirstOrDefaultAsync(order => order.OrderCode == orderCode && order.Status == true);
    }
}
