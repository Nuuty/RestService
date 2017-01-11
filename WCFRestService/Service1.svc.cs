using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace WCFRestService
{
    //Eftersom InstanceContextMode.PerCall er default så er servicen stateless.
    //En workaround er at lave listen static ellers er den optimale metode at ændre InstanceContextMode til Single.
    //Dermed genbruges det samme server objekt til hvert kald istedet for at lave et nyt.
    //Der laves kun et nyt service objekt hvis der ikke allerede eksisterer et i forvejen.
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        public static int Ids { get; set; }

        //WCF will create a new instance of Service1 for each new client connecting to your service
        //That is why the List needs to be static otherwise it will not be able to keep data between instances
        private static readonly IList<Dummy> Dummies = new List<Dummy>
        {
            new Dummy
            {
                Id = ++Ids,
                Name = "First Dummy"
            }

        };    
        public IList<Dummy> GetDummies()
        {
            return Dummies;
        }

        public Dummy GetDummy(string id)
        {
            return Dummies.FirstOrDefault(dummy => dummy.Id.Equals(int.Parse(id)));
        }

        public void DeleteDummy(string id)
        {
            Dummy dummy = GetDummy(id);
            Dummies.Remove(dummy);
        }

        public void PostDummy(Dummy dummy)
        {
            dummy.Id = ++Ids;
            Dummies.Add(dummy);
        }

        public void PutDummy(Dummy dummy, string id)
        {
            Dummy d = GetDummy(id);
            d.Name = dummy.Name;
        }
    }
}
