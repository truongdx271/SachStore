using SachApp.Service.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SachApp.Service.Dao
{
    public class NhaXuatBanDao : dbContext
    {
        public DataTable GetNXB()
        {
            return base.GetData("NXB_GETALL", null);
        }
    }
}
