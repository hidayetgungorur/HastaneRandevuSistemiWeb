using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace BHRSWebService.Error
{
    public class GlobalErrorHandler : IErrorHandler
    {

        #region IErrorHandler

        public void ProvideFault(Exception ex, MessageVersion version, ref Message fault)
        {
            return;
        }

        public bool HandleError(Exception ex)
        {


            return true;
        }

        #endregion

        #region IContractBehavior

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {

        }

        #endregion
    }
}