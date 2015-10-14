using PWSHackathonDAL;
using System.Collections.Generic;
using System.Linq;

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
                var riskAssessment = _db.RiskAssessments
                    //TODO .OrderByDescending(ra => ra.DateCreated)
                    .FirstOrDefault(ra => ra.SupplyReference == address.RiskAssessmentSupplyRef);

                if (riskAssessment == null) {
                    return null;
                }

                PWSHackathonDAL.Address dbAddress = new PWSHackathonDAL.Address();
                
                dbAddress.Name = address.Name;
                dbAddress.AddressLine1 = address.Line1;
                dbAddress.AddressLine2 = address.Line2;
                dbAddress.AddressLine3 = address.Line3;
                dbAddress.AddressLine4 = address.Line4;
                dbAddress.Postcode = address.PostCode;
                dbAddress.Telephone = address.TelephoneNumber;
                dbAddress.Email = address.EMail;
                dbAddress.ID = riskAssessment.ID;

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

                return DALAddressToWCFAddress(tempAddress);
            }
            else
            {
                return null;
            }
        }

        public List<Address> GetAddressesByRiskAssessment(string riskAssessmentSupplyRef)
        {
            List<Address> ret = new List<Address>();
            var riskAssessment = _db.RiskAssessments
                //TODO .OrderByDescending(ra => ra.DateCreated)
                .FirstOrDefault(ra => ra.SupplyReference == riskAssessmentSupplyRef);
            if (riskAssessment == null) {
                return ret;
            }

            List<PWSHackathonDAL.Address> dalAddresses = _db.Addresses
                .Where(a => a.RiskAssessmentID == riskAssessment.ID)
                .ToList();

            foreach (PWSHackathonDAL.Address add in dalAddresses)
            {
                ret.Add(DALAddressToWCFAddress(add));
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