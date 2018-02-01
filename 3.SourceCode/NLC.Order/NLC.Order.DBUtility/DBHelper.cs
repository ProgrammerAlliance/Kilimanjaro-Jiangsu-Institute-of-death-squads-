﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NLC.Order.DBUtility
{
    public class DBHelper
    {
        static string connString = "Data Source=DESKTOP-52NF0RS;Initial Catalog=Order;Persist Security Info=True;User ID=sa;Password=123";


        // 执行对数据表中数据的增加、删除、修改操作  
        public static int NonQuery(string sql, SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connString);
            int result = -1;
            try
            {
                conn.Open();  //打开数据库  
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (parameters != null && parameters.Length > 0)
                {
                    foreach (SqlParameter parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                }
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception msg)
            {
                throw new Exception(msg.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();    //关闭数据库  
                }
            }
            return result;

        }
        // 执行对数据表中数据的查询操作  
        public static DataSet Query(string sql, SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connString);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();      //打开数据库  
                SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
                if (parameters != null && parameters.Length > 0)
                {
                    foreach (SqlParameter parameter in parameters)
                    {
                        adp.SelectCommand.Parameters.Add(parameter);
                    }
                }
                adp.Fill(ds);
            }
            catch (Exception msg)
            {
                throw new Exception(msg.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();      //关闭数据库  
            }
            return ds;
        }

        /// <summary>
        ///  Dataset 集合根据传入的 类型。自动转换List集合"
        /// </summary>
        /// <typeparam name="T">类（属性类 modle）</typeparam>
        /// <param name="ds">数据集合</param>
        /// <returns>List集合</returns>
        public static List<T> GetListbyDataSet<T>(DataSet ds) where T : new()
        {
            List<T> li = new List<T>(); //声明要返回的集合
            var s = typeof(T);          // 获取传入类型
            var str = s.GetProperties(); // 获取传入类型的属性集合
            if (ds.Tables[0] == null || ds.Tables[0].Rows.Count < 0) //判断ds的null和是否包含数据
            {
                return li;
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++) //循环集合准备获取数据
            {
                T t1 = new T();       // 声明类
                foreach (var item in str)  // 循环类的属性
                {
                    string itemstr = item.Name; //类属性名称
                    var itemtype = item.PropertyType; // 类属性的类型（int string datetime）
                    object value = GetvalbyDataSet(itemstr, itemtype, ds.Tables[0].Rows[i]); //获取值
                    item.SetValue(t1, value, null);

                }
                li.Add(t1);
            }
            return li;
        }

        /// <summary>
        ///  在DataRow中 获取 对应列的值
        /// </summary>
        /// <param name="colname">列名称</param>
        /// <param name="colname">列的类型</param>
        /// <param name="dr">DataRow 集合</param>
        /// <returns>列值</returns>
        private static object GetvalbyDataSet(string colname, Type coltype, DataRow dr)
        {
            if (dr.Table.Columns.Contains(colname))
            {
                if (typeof(int) == coltype)
                {
                    return dr[colname] == null ? 0 : int.Parse(dr[colname].ToString());
                }
                if (typeof(DateTime) == coltype)
                {
                    return dr[colname] == null ? DateTime.Parse("2016/9/22") : DateTime.Parse(dr[colname].ToString());
                }
                if (typeof(decimal) == coltype)
                {
                    return dr[colname] == null ? decimal.Parse("0") : decimal.Parse(dr[colname].ToString());
                }
                string str = dr[colname] == null ? "" : dr[colname].ToString();
                return str;
            }
            else
            {
                if (typeof(int) == coltype)
                {
                    return 0;
                }
                if (typeof(DateTime) == coltype)
                {
                    return null;
                }
                return "";
            }
        }
    }
}
