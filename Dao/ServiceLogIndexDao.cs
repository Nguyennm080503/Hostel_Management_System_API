using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Dao
{
    public class ServiceLogIndexDao : BaseDAO<ServiceLogIndex>
    {
        private static ServiceLogIndexDao instance = null;
        private static readonly object instacelock = new object();

        private ServiceLogIndexDao()
        {

        }

        public static ServiceLogIndexDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServiceLogIndexDao();
                }
                return instance;
            }
        }
    }
}
