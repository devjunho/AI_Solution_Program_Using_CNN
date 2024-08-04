using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helmet.Model
{
    public class Data
    {
        public int Type { get; set; }
        public int NO { get; set; }
        public string ID { get; set; }
        public string PW { get; set; }
        public string NAME { get; set; }
    }

    public class Check
    {
        public int Type { get; set; }
        public string SAVETIME { get; set; }
        public int HELMET { get; set; }
        public string ROUTE { get; set; }
    }
    enum TYPE
    {
        // 0번
        CONNECT_FAIL = 0,

        // 10번
        SUCCEED = 10,

        // 20번
        FAIL = 20,

        // 21번
        DUPLICATE = 21,

        // 30번
        EMPTY = 30,

        // 40번
        LOGIN = 40,

        // 50번
        JOIN = 50,

        // 60번
        CHECK_HELMET = 60,

        // 70번
        HISTORY = 70
    }
}
