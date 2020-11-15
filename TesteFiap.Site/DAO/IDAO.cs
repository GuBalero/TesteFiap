using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFiap.Site.Models;

namespace TesteFiap.Site.DAO
{
    interface IDAO
    {
        void Register(object obj);
        void Delete(int id);
        void Update(object obj);
        List<object> ListAll();

    }
}
