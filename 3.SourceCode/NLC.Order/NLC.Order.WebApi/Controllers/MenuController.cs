﻿using Newtonsoft.Json;
using NLC.Order.BLL;
using NLC.Order.Common;
using NLC.Order.IBLL;
using NLC.Order.Model;
using System.Web.Http;

namespace NLC.Order.WebApi.Controllers
{
    public class MenuController : ApiController
    {
        private IMenuBLL menuBLL = new MenuBLL();
        private JsonResult jr = new JsonResult();

        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <param name="id">饭店ID</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetMenu(int id)
        {
            return menuBLL.GetMenu(id);
        }

        /// <summary>
        /// 添加菜
        /// </summary>
        /// <param name="dish">菜对象</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult AddDish(string dish)
        {
            MenuInfo m = JsonConvert.DeserializeObject<MenuInfo>(dish);
            return menuBLL.AddDish(m);
        }

        /// <summary>
        /// 删除菜
        /// </summary>
        /// <param name="id">菜ID</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult DelDish(int id)
        {
            return menuBLL.DelDish(id);
        }

        [HttpGet]
        public JsonResult GetAllRest()
        {
            return menuBLL.GetRestaurant();
        }


    }
}
