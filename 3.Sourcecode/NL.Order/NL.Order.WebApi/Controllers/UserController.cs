﻿using NL.Order.BLL;
using NL.Order.Common;
using NL.Order.IBLL;
using NL.Order.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NL.Order.WebApi.Controllers
{
    public class UserController : ApiController
    {
        /// <summary>
        /// UserBLL对象
        /// </summary>
        private IUserBLL userBLL = new UserBLL();

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetAllUser()
        {
            return userBLL.GetAllUser();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Login(string name, string pwd)
        {
            return userBLL.Login(name, pwd);
        }

        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult AddUser(UserInfo user)
        {
            return AddUser(user);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId">员工编号</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult DelUser(string userId)
        {
            return userBLL.DelUser(userId);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userId">员工编号</param>
        /// <param name="newPassword">新密码</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult ModifyPassword(string userId, string newPassword)
        {
            return userBLL.ModifyPassword(userId,newPassword);
        }

        [HttpGet]
        public string Test(int i)
        {
            return "1101101001";
        }
    }
}
