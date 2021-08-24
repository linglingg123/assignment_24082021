using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity;
//using System.Linq;
//using System.Web;

namespace Owin_Account_Cao_Khanh_Linh
{
    public class Account
    {
        //public int AccountId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int AccNo { get; set; }
    }
    public class AccountModel : DbContext
    {
        public AccountModel() : base("") { }
        public DbSet<Account> AccountList { get; set; }
    }
}
