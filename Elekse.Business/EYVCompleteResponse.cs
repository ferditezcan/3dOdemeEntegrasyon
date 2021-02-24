using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elekse.Business
{
    public class EYVCompleteResponse
    {
        public string STATUS { get; set; }
        public string RETURN_MESSAGE { get; set; }
        public string RETURN_CODE { get; set; }
        public string REFNO { get; set; }
        public string ORDER_REF_NUMBER { get; set; }
        public string HASH { get; set; }
        public string DATE { get; set; }
    }
}
