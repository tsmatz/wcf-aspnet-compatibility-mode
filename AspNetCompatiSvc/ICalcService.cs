using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AspNetCompatiSvc
{
    [ServiceContract]
    public interface ICalcService
    {
        [OperationContract]
        void SetValue(int value);

        [OperationContract]
        void AddValue(int value);

        [OperationContract]
        int GetValue();
    }

}
