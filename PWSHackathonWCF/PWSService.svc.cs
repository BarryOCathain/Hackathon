using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PWSHackathonWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class PWSService : IAddressService
    {
        public Address CreateAddress(Address address)
        {
            Address ret = new Address();


            return ret;
        }

        public Address DeleteAddress(Address address)
        {
            Address ret = new Address();


            return ret;
        }

        public Address GetAddress(string postcode)
        {
            Address ret = new Address();

            ret.PostCode = postcode;

            return ret;
        }

        public List<Address> GetAllAddresses()
        {
            List<Address> ret = new List<Address>();

            return ret;
        }

        public Address UpdateAddress(Address address)
        {
            Address ret = new Address();

            return ret;
        }
    }
}
