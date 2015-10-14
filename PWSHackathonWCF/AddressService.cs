using PWSHackathonDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PWSHackathonWCF
{
    public class AddressService : IAddressService
    {
        PWS_DatabaseEntities _db;

        public AddressService(PWS_DatabaseEntities db)
        {
            _db = db;
        }

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

                return MappingHelper.DALAddressToWCFAddress(dbAddress);
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
                return MappingHelper.DALAddressToWCFAddress(ret);
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
                ret.Add(MappingHelper.DALAddressToWCFAddress(address));
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

            if (tempAddress != null)
            {
                tempAddress.Name = address.Name;
                tempAddress.AddressLine1 = address.Line1;
                tempAddress.AddressLine2 = address.Line1;
                tempAddress.AddressLine3 = address.Line3;
                tempAddress.AddressLine4 = address.Line4;
                tempAddress.Email = address.EMail;
                tempAddress.Telephone = address.TelephoneNumber;

                _db.SaveChanges();

                return MappingHelper.DALAddressToWCFAddress(tempAddress);
            }
            else
            {
                return null;
            }
        }

        public List<Address> GetAddressesByRiskAssessment(int riskAssessmentId)
        {
            List<Address> ret = new List<Address>();
            List<PWSHackathonDAL.Address> dalAddresses = _db.Addresses
                .Where(a => a.RiskAssessmentID == riskAssessmentId)
                .ToList();

            foreach (PWSHackathonDAL.Address add in dalAddresses)
            {
                ret.Add(MappingHelper.DALAddressToWCFAddress(add));
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
    }
}