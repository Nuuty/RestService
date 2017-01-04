using System;
using System.Collections.Generic;
using System.Linq;

namespace WCFRestService
{
    public class Service1 : IService1
    {
        public static int Ids { get; set; }

        private static IList<Dummy> dummies = new List<Dummy>
        {
            new Dummy()

        };

        public IList<Dummy> GetData()
        {
            return dummies;
        }

        public Dummy GetDataById(string id)
        {
            return dummies.FirstOrDefault(x => x.Id.Equals(int.Parse(id)));
        }

        public void PostData(Dummy dummy)
        {
            throw new NotImplementedException();
        }

        public string PutData(Dummy dummy, string id)
        {
            throw new NotImplementedException();
        }

        public string DeleteData(string id)
        {
            throw new NotImplementedException();
        }
    }
}
