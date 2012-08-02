using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using System.Web;

namespace AspNetCompatiSvc
{
    [ServiceBehavior]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class CalcService : ICalcService
    {
        public void SetValue(int value)
        {
            HttpContext.Current.Session["calcValue"] = value;
        }

        public void AddValue(int value)
        {
            if (HttpContext.Current.Session["calcValue"] == null)
                throw new FaultException("SetValue が呼ばれてません");

            int calcValue = (int) HttpContext.Current.Session["calcValue"];
            calcValue += value;
            HttpContext.Current.Session["calcValue"] = calcValue;
        }

        public int GetValue()
        {
            if (HttpContext.Current.Session["calcValue"] == null)
                throw new FaultException("SetValue が呼ばれてません");

            return (int)HttpContext.Current.Session["calcValue"];
        }
    }
}
