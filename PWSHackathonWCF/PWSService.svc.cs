using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PWSHackathonDAL;

namespace PWSHackathonWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class PWSService : IAddressService
    {
        PWS_DatabaseEntities _db = new PWS_DatabaseEntities();

        public Address CreateAddress(Address address)
        {
            PWSHackathonDAL.Address dbAddress = new PWSHackathonDAL.Address();
            dbAddress.AddressLine1 = address.Line1;
            dbAddress.AddressLine2 = address.Line2;
           

            _db.Addresses.Add(dbAddress);

            _db.SaveChanges();

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
            string wcfPostcode = address.PostCode;

            PWSHackathonDAL.Address tempAddress = _db.Addresses
                .Where(a => a.Postcode == wcfPostcode)
                .FirstOrDefault();

            if(tempAddress != null)
            {
                tempAddress.AddressLine1 = address.Line1;
                tempAddress.AddressLine2 = address.Line1;
                tempAddress.AddressLine3 = address.Line3;
                tempAddress.AddressLine4 = address.Line4;
                tempAddress.Email = address.EMail;
                tempAddress.Telephone = address.TelephoneNumber;

                _db.SaveChanges();

                return tempAddress;

            }


            Address ret = new Address();

            return ret;
        }
    }
}
