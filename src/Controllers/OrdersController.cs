using Microsoft.AspNetCore.Mvc;
using services_order_search.Models;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrdersController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var result = await _orderService.GetAllOrdersAsync();
        return Ok(new ApiResponse<List<Orders>>("success", result, "List of orders"));
    }

    [HttpGet("{codice}")]
    public async Task<IActionResult> GetOrderByCode(string codice)
    {


        var result = await _orderService.GetOrderByCodeAsync(codice);

        if (result == null)
        {
            return Ok(new ApiResponse<Orders>("empty", result, "Order not found"));
        }

        return Ok(new ApiResponse<Orders>("success", result, "Order found"));
    }



}
