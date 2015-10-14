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
            if (address != null)
            {
                PWSHackathonDAL.Address dbAddress = new PWSHackathonDAL.Address();

                dbAddress.Name = address.Name;
                dbAddress.AddressLine1 = address.Line1;
                dbAddress.AddressLine2 = address.Line2;
                dbAddress.AddressLine3 = address.Line3;
                dbAddress.AddressLine4 = address.Line4;
                dbAddress.Postcode = address.PostCode;
                dbAddress.Telephone = address.TelephoneNumber;
                dbAddress.Email = address.EMail;

                _db.Addresses.Add(dbAddress);
                _db.SaveChanges();

                return DALAddressToWCFAddress(dbAddress); 
            }
            else
            {
                return null;
            }
        }

        public Address DeleteAddress(Address address)
        {
            return null;
        }

        public Address GetAddress(string postcode)
        {
            PWSHackathonDAL.Address ret = _db.Addresses
                .Where(a => a.Postcode == postcode)
                .FirstOrDefault();

            if (ret != null)
            {
                return DALAddressToWCFAddress(ret); 
            }
            else
            {
                return null;
            }
        }

        public List<Address> GetAllAddresses()
        {
            List<PWSHackathonDAL.Address> dalAdd = _db.Addresses.ToList();
            List<Address> ret = new List<Address>();

            foreach (PWSHackathonDAL.Address address in dalAdd)
            {
                ret.Add(DALAddressToWCFAddress(address));
            }

            if (ret != null)
            {
                return ret;
            }
            else
            {
                return null;
            }
        }

        public Address UpdateAddress(Address address)
        {
            string wcfPostcode = address.PostCode;

            PWSHackathonDAL.Address tempAddress = _db.Addresses
                .Where(a => a.Postcode == wcfPostcode)
                .FirstOrDefault();

            if(tempAddress != null)
            {
                tempAddress.Name = address.Name;
                tempAddress.AddressLine1 = address.Line1;
                tempAddress.AddressLine2 = address.Line1;
                tempAddress.AddressLine3 = address.Line3;
                tempAddress.AddressLine4 = address.Line4;
                tempAddress.Email = address.EMail;
                tempAddress.Telephone = address.TelephoneNumber;

                _db.SaveChanges();

                return DALAddressToWCFAddress(tempAddress);
            }
            else
            {
                return null;
            }
        }

        private PWSHackathonDAL.Address WCFAddressToDALAddress(Address address)
        {
            if (address != null)
            {
                PWSHackathonDAL.Address output = new PWSHackathonDAL.Address();

                output.Name = address.Name;
                output.AddressLine1 = address.Line1;
                output.AddressLine2 = address.Line2;
                output.AddressLine3 = address.Line3;
                output.AddressLine4 = address.Line4;
                output.Email = address.EMail;
                output.Postcode = address.PostCode;
                output.Telephone = address.TelephoneNumber;

                return output;
            }
            else
            {
                return null;
            }
        }

        private Address DALAddressToWCFAddress(PWSHackathonDAL.Address address)
        {
            if (address != null)
            {
                Address output = new Address();

                output.Name = address.Name;
                output.Line1 = address.AddressLine1;
                output.Line2 = address.AddressLine2;
                output.Line3 = address.AddressLine3;
                output.Line4 = address.AddressLine4;
                output.PostCode = address.Postcode;
                output.TelephoneNumber = address.Telephone;
                output.EMail = address.Email;

                return output;
            }
            else
            {
                return null;
            }
        }
    }
}
