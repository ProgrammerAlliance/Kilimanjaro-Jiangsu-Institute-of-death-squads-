﻿using NL.Order.IBLL;
using System;
using NL.Order.Common;
using NL.Order.Model;
using NL.Order.IDAL;
using NL.Order.DALFactory;

namespace NL.Order.BLL
{
    public class UserBLL : IUserBLL
    {
        private IUserDAL userDAL = UserDALFactory.CreateUserDAL();
        private JsonResult jr = new JsonResult();

        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public JsonResult AddUser(UserInfo user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public JsonResult DelUser(string userId)
        {
            jr.Status = 200;
            jr.Result = userDAL.DeleteUser("1");
            return jr;
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAllUser()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public JsonResult Login(string name, string pwd)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="psassword"></param>
        /// <returns></returns>
        public JsonResult MotifyPassword(string userId, string psassword)
        {
            throw new NotImplementedException();
        }
    }
}
