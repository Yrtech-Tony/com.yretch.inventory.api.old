using com.yrtech.InventoryAPI.Common;
using com.yrtech.InventoryAPI.DTO;
using com.yrtech.InventoryAPI.DTO.Account;
using com.yrtech.InventoryDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace com.yrtech.InventoryAPI.Service
{
    public class AccountService
    {
        Inventory db = new Inventory();

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public List<ShopDto> LoginForMobile(string accountId, string password)
        {
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@AccountId", accountId),
                                                       new SqlParameter("@Password",password)};
            Type t = typeof(ShopDto);
            string sql = @"SELECT ShopCode,Password FROM Shop WHERE ShopCode = @AccountId AND Password =  @Password";
            return db.Database.SqlQuery(t, sql, para).Cast<ShopDto>().ToList();
        }
    }
}