using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Owin_Account_Cao_Khanh_Linh
{
    public class AccountController : ApiController
    {
        private List<Account> list()
        {
            List<Account> l = new List<Account>();
            l.Add(new Account() { Name = "Steve Jobs", Email = "steve@apple.com", AccNo = 12345678 });
            l.Add(new Account() { Name = "Bill Gates", Email = "bill@microsoft.com", AccNo = 87654321 });
            l.Add(new Account() { Name = "Larry Ellison", Email = "larry@oracle.com", AccNo = 11223344 });
            return l;
        }

        //// GET api/values
        //public IEnumerable<Account> Get()
        //{
        //    return this.list();
        //}

        //// GET api/values/5
        //public Account Get(int id)
        //{
        //    var ml = this.list();
        //    var P = from p in ml where p.AccNo == id select p;
        //    return P.First();
        //}

        AccountModel db = new AccountModel();
        public IHttpActionResult Get()
        {
            var model = db.AccountList.ToList();
            return Ok(model);
        }

        public Account Get(int id)
        {
            var model = db.AccountList.Where(c => c.AccNo.Equals(id)).Single();
            return Ok(model);
        }

        public void Post(Account item)
        {
            db.AccountList.Add(item);
            db.SaveChanges();
            //return Ok();
        }

        public void PutCustomer(int id,Account item)
        {
            var rs = db.AccountList.Where(c => c.AccNo.Equals(id)).Single();
            if (rs != null)
            {
                rs.Name = item.Name;
                rs.AccNo = item.AccNo;
                rs.Email = item.Email;
                db.SaveChanges();
            }
            //return Ok();
        }

        public void Delete(int id)
        {
            var acc= db.AccountList.Where(c => c.AccNo.Equals(id)).Single();
            db.AccountList.remove(acc);
            db.SaveChanges();
            //return Ok();
        }
    }
}
