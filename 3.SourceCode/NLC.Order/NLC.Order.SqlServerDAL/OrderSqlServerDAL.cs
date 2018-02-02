﻿using NLC.Order.IDAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NLC.Order.Model;
using System.Data.SqlClient;
using NLC.Order.DBUtility;
using System.Data;

namespace NLC.Order.SqlServerDAL
{
    public class OrderSqlServerDAL : IOrderDAL
    {
        /// <summary>
        /// 增加订餐
        /// </summary>
        /// <param name="order">订餐信息</param>
        /// <returns></returns>
        public bool AddOrder(OrderInfo order)
        {
            string sql = "";
            throw new NotImplementedException();
        }

        /// <summary>
        /// 取消订餐
        /// </summary>
        /// <param name="UserId">用户工号</param>
        /// <returns></returns>
        public bool SubOrder(int UserId)
        {
            string sql = "delete from ordertable where DateDiff(dd,createtime,getdate())=0 and UserId=@UserId";
            SqlParameter[] parameters =
            {
                new SqlParameter("UserId",UserId)
            };
            int result = DBHelper.NonQuery(sql, parameters);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 产生打扫人员
        /// </summary>
        /// <returns></returns>
        public List<OrderInfo> Cleaner()
        {
            string sql = "select * from OrderTable where DateDiff(dd,createtime,getdate())=0";
            DataSet ds = DBHelper.Query(sql, null);
            return DBHelper.GetListbyDataSet<OrderInfo>(ds);
        }

        /// <summary>
        /// 获取打扫人员姓名
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public string GetName(int UserId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改打扫人员状态
        /// </summary>
        /// <param name="UserId">用户工号</param>
        /// <returns></returns>
        public bool ModifyCleanState(int UserId)
        {
            throw new NotImplementedException();
        }

    }
}