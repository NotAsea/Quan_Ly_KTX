using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan_Ly_KTX.Models;
namespace Quan_Ly_KTX.Controller
{
    public sealed class SQLConnection
    {
        private SQLConnection() { }
      
        private static KTX_KMAContext instance = null;
        public static KTX_KMAContext Instance
        {
            get
            {
                if (instance == null)
                {
                     instance = new();
                }
                return instance;
            }
        }

    }
}
