using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCFRestService
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "dummies")]
        IList<Dummy> GetDummies();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "dummies/{id}")]
        Dummy GetDummy(string id);

        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, UriTemplate = "dummies/{id}")]
        void DeleteDummy(string id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json, //determines the format of responses sent from a service operation
            RequestFormat = WebMessageFormat.Json, //determines the format of requests made to a service operation
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "dummies")] //determines which requests get dispatched to which service operations
        void PostDummy(Dummy dummy);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "dummies/{id}")]
        void PutDummy(Dummy dummy, string id);

        
    }
}
