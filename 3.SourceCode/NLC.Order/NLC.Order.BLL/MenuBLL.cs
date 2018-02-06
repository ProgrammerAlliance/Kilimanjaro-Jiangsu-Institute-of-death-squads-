﻿using NLC.Order.Common;
using NLC.Order.DALFactory;
using NLC.Order.IBLL;
using NLC.Order.IDAL;
using NLC.Order.Model;
using System;

namespace NLC.Order.BLL
{
    public class MbenuBLL : IMenuBLL
    {
        private IMenuDAL MenuDAL = Factory.CreateMenuDAL();
        private JsonResult jr = new JsonResult();

        /// <summary>
        /// 增加菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public JsonResult AddDishes(MenuInfo menu)
        {
            try
            {

            }
            catch (Exception)
            {

                jr.Result = "系统繁忙";
                jr.Status = 500;
            }
            return jr;
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="DishesId"></param>
        /// <returns></returns>
        public JsonResult DelDishes(int DishesId)
        {
            try
            {

            }
            catch (Exception)
            {
                jr.Result = "系统繁忙";
                jr.Status = 500;
            }
            return jr;
        }

        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAllMenu()
        {
            try
            {

            }
            catch (Exception)
            {
                jr.Result = "系统繁忙";
                jr.Status = 500;
            }
            return jr;
        }

       
    }
}
