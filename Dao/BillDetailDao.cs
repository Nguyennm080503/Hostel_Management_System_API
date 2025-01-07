using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Dao
{
    public class BillDetailDao : BaseDAO<BillInformation>
    {
        private static BillDetailDao instance = null;
        private static readonly object instacelock = new object();

        private BillDetailDao()
        {

        }

        public static BillDetailDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillDetailDao();
                }
                return instance;
            }
        }
    }
}
