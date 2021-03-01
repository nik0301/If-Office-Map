using System.Collections.Generic;
using IfOfficeMap.DataAccess;

namespace IfOfficeMap.Business
{
    public class PersonRepository
    {
        public List<Person> GetPersons(int limit = 15)
        {
            var gateway = new LyncGateway();
            return gateway.GetContacts(150);
        }

        public List<Person> Lookup(string searchkey)
        {
            var gateway = new LyncGateway();
            return gateway.Lookup(searchkey);
        }

        public List<Person> SearchPersons(string searchkey, int limit = 15)
        {
            var gateway = new LyncGateway();
            var dataResult = gateway.SearchContacts(searchkey, (uint)limit);

            //if (dataresult != null && dataresult.count > 0)
            //{
            //    for (int i = 0; i < dataresult.count; i++)
            //    {
            //        if (
            //           result.all(x => x.email != dataresult[i].getcontactinformation(contactinformationtype.primaryemailaddress).tostring()))
            //        {
            //            result.add(new person(dataresult[i]));
            //        }
            //    }
            //}

            return dataResult;
        } 
    }
}
