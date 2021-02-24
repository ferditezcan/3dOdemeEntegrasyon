using Elekse.Business;
using Elekse.Business.Request;
using Elekse.Business.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Elekse.NetProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EYV3DPay()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EYV3DPay(string CardNumber, string CardExpiresMonth, string CardExpiresYear, string CardCustomerName, string CardCVC)
        {
            var siteUrl = Request.Url.GetLeftPart(UriPartial.Authority);

            PaymentRequest paymentRequest = new PaymentRequest();

            paymentRequest.Config = new PaymentRequest.EYVConfig();
            paymentRequest.Config.MERCHANT = "rezerwashyon.com";   //MERCHANT
            paymentRequest.Config.MERCHANT_KEY = "psMDKIrQIa6ao7SKjWEHjYwOfhRxeRD0+RziOU8ZExZnlrWDrp9xlw==";  //MERCHANT_KEY
            paymentRequest.Config.ORDER_AMOUNT = "15";
            paymentRequest.Config.PRICES_CURRENCY = "TR";
            paymentRequest.Config.BACK_URL = siteUrl + "/Home/EYVComplete";
            paymentRequest.Config.ORDER_REF_NUMBER = DateTime.UtcNow.ToString("yyyyMMddHHmmss");


            paymentRequest.CreditCard = new PaymentRequest.EYVCreditCard();
            paymentRequest.CreditCard.CC_CVV = CardCVC;
            paymentRequest.CreditCard.CC_NUMBER = CardNumber;
            paymentRequest.CreditCard.CC_OWNER = CardCustomerName;
            paymentRequest.CreditCard.EXP_MONTH = CardExpiresMonth;
            paymentRequest.CreditCard.EXP_YEAR = CardExpiresYear;
            paymentRequest.CreditCard.INSTALLMENT_NUMBER = "1";

            paymentRequest.Customer = new PaymentRequest.EYVCustomer();
            paymentRequest.Customer.FIRST_NAME = "Ad";
            paymentRequest.Customer.LAST_NAME = "Soyad";
            paymentRequest.Customer.ADDRESS = "Adres";
            paymentRequest.Customer.MAIL = "pos@elekse.com";
            paymentRequest.Customer.PHONE = "02122356600";
            paymentRequest.Customer.CITY = "İSTANBUL";
            paymentRequest.Customer.STATE = "ŞİŞLİ";

            var json = new JavaScriptSerializer().Serialize(paymentRequest);

            var response = new JavaScriptSerializer().Deserialize<PaymentResponse>(new Helper().JsonPostData(Helper.PostUrl, json));
            if (response.RETURN_CODE == "0")
                return Redirect(response.URL_3DS);
            else
                return View(response);
        }

        [HttpPost]
        public ActionResult EYVComplete()
        {
            EYVCompleteResponse completeResponse = new EYVCompleteResponse();
            completeResponse.STATUS = Request.Form["STATUS"];
            completeResponse.RETURN_MESSAGE = Request.Form["RETURN_MESSAGE"];
            completeResponse.RETURN_CODE = Request.Form["RETURN_CODE"];
            completeResponse.REFNO = Request.Form["REFNO"];
            completeResponse.ORDER_REF_NUMBER = Request.Form["ORDER_REF_NUMBER"];
            completeResponse.HASH = Request.Form["HASH"];
            completeResponse.DATE = Request.Form["DATE"];
            return View(completeResponse);
        }
    }
}