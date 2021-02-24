using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elekse.Business.Request
{
    public class PaymentRequest
    {
        public EYVConfig Config { get; set; }
        public EYVCreditCard CreditCard { get; set; }
        public EYVCustomer Customer { get; set; }

        public PaymentRequest()
        {
            Config = new EYVConfig();
            CreditCard = new EYVCreditCard();
            Customer = new EYVCustomer();
        }

        public class EYVConfig
        {
            public EYVConfig()
            {

            }

            public string MERCHANT { get; set; }
            public string MERCHANT_KEY { get; set; }
            public string BACK_URL { get; set; }
            public string PRICES_CURRENCY { get; set; }
            public string ORDER_REF_NUMBER { get; set; }
            public string ORDER_AMOUNT { get; set; }
        }

        public class EYVCreditCard
        {
            public EYVCreditCard()
            {

            }

            public string CC_NUMBER { get; set; }
            public string EXP_MONTH { get; set; }
            public string EXP_YEAR { get; set; }
            public string CC_CVV { get; set; }
            public string CC_OWNER { get; set; }
            public string INSTALLMENT_NUMBER { get; set; }
        }

        public class EYVCustomer
        {
            public EYVCustomer()
            {

            }

            public string FIRST_NAME { get; set; }
            public string LAST_NAME { get; set; }
            public string MAIL { get; set; }
            public string PHONE { get; set; }
            public string CITY { get; set; }
            public string STATE { get; set; }
            public string ADDRESS { get; set; }
            public string CLIENT_IP { get; set; }

        }
    }
    }
