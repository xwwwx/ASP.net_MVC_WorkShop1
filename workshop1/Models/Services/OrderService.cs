using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using workshop1.Daos;

namespace workshop1.Models.Services
{
    public class OrderService
    {
        /// <summary>
        /// 取得 Order by 訂單編號
        /// </summary>
        /// <param name="orderID">訂單編號</param>
        /// <returns></returns>
        public Order GetOrder(int orderID)
        {
            OrdersDao dao = new OrdersDao();
            return dao.GetOrderById(orderID);
        }

        /// <summary>
        /// 取得 Orders by 條件
        /// </summary>
        /// <returns></returns>
        public IList<Order> GetOrders(OrderQueryArg arg)
        {
            CustomerService customerService = new CustomerService();

            OrdersDao orderDao = new OrdersDao();
            // 取得所有訂單後進行篩選  (注意: 此處應將查詢條件串入SQL中為較好之寫法)
            IEnumerable<Order> currentOrders = orderDao.GetOrdersByArg(arg);
            return currentOrders.OrderBy(m => m.OrderID).ToList();
        }

        /// <summary>
        /// 新增 Order
        /// </summary>
        /// <param name="order">欲新增的訂單資料</param>
        public void InsOrder(Order order)
        {
            OrdersDao orderDao = new OrdersDao();
            orderDao.AddNewOrderReturnNewOrderId(order);
        }

        /// <summary>
        /// 更新 Order
        /// </summary>
        /// <param name="order">欲更新的訂單資料</param>
        public void UpdOrder(Order order)
        {
            OrdersDao orderDao = new OrdersDao();
            orderDao.UpdateOrder(order);
        }

        /// <summary>
        /// 刪除 Order
        /// </summary>
        /// <param name="orderID">訂單編號</param>
        public void DelOrder(int orderID)
        {
            OrdersDao orderDao = new OrdersDao();
            orderDao.DeleteOrder(orderID);
        }
    }
}