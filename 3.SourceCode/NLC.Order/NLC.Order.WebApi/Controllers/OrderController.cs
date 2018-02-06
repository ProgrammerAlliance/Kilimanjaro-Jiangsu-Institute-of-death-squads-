﻿using Newtonsoft.Json;
using NLC.Order.BLL;
using NLC.Order.Common;
using NLC.Order.IBLL;
using NLC.Order.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NLC.Order.WebApi.Controllers
{
    public class OrderController : ApiController
    {
        /// <summary>
        /// OrderBLL对象
        /// </summary>
        private IOrderBLL orderBLL = new OrderBLL();

        /// <summary>
        /// 订餐
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult AddOrder(string order)
        {
            OrderInfo orderInfo = JsonConvert.DeserializeObject<OrderInfo>(order);
            return orderBLL.OrderFood(orderInfo);
        }

        /// <summary>
        /// 取消订餐
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult CancelOrder(int userId)
        {
            return orderBLL.CancelOrder(userId);
        }

        /// <summary>
        /// 产生打扫人员
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult ProduceSweep()
        {
            return orderBLL.ProudceSweep();
        }

        /// <summary>
        /// 获取今日订餐人员信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetOrderPeople(int rows, int page, int deptId)
        {
            return orderBLL.GetOrderPeople(rows, page, deptId);
        }

        /// <summary>
        /// 统计今日订餐人数
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult CountOrderNumber()
        {
            return orderBLL.CountOrderNumber();
        }

        /// <summary>
        /// 今日是否产生打扫人员
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult WetherProduce()
        {
            return orderBLL.WetherProudce();
        }

        /// <summary>
        /// 用户今日是否订餐
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult UserIsOrder(int userId)
        {
            return orderBLL.UserIsOrder(userId);
        }

        /// <summary>
        /// 获取打扫人员名字
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetCleanName()
        {
            return orderBLL.GetCleanEmpName();
        }

        /// <summary>
        /// 修改订餐截止时间
        /// </summary>
        /// <param name="hour">时</param>
        /// <param name="minute">分</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult ModifyTime(int hour,int minute)
        {
            return orderBLL.ModifyTime(hour, minute);
        }
    }
}
