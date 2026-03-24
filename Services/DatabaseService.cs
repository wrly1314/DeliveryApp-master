using DeliveryApp.Models;
using System.Collections.Generic;

namespace DeliveryApp.Services;

public class DatabaseService
{
    public void InitTestData()
    {
        // 测试数据初始化逻辑（如需实现可补充）
    }

    public List<DeliveryOrder> GetOrders()
    {
        // 返回模拟订单数据
        return new List<DeliveryOrder>
        {
            new DeliveryOrder
            {
                OrderId = "ORDER001",
                Type = "Food",
                Receiver = "Zhang San",
                Address = "XX Community 1-2-301",
                Status = "Delivering",
                Time = DateTime.Now
            },
            new DeliveryOrder
            {
                OrderId = "ORDER002",
                Type = "Package",
                Receiver = "Li Si",
                Address = "YY Building 5F",
                Status = "Delivering",
                Time = DateTime.Now
            },
            new DeliveryOrder
            {
                OrderId = "ORDER003",
                Type = "Food",
                Receiver = "Wang Wu",
                Address = "ZZ Street 78",
                Status = "Delivering",
                Time = DateTime.Now
            }
        };
    }
}