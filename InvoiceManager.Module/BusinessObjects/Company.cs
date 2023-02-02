using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager.Module.BusinessObjects
{
    [NavigationItem("Directories")]
    [XafDisplayName("Companies")]
    [DefaultClassOptions]
    public class Company : XPObject
    {
        public Company(Session session) : base(session) { }

        string regon;
        string street;
        string city;
        string postalCode;
        string email;
        string phoneNumber;
        string nIP;
        string companyName;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CompanyName
        {
            get => companyName;
            set => SetPropertyValue(nameof(CompanyName), ref companyName, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NIP
        {
            get => nIP;
            set => SetPropertyValue(nameof(NIP), ref nIP, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Regon
        {
            get => regon;
            set => SetPropertyValue(nameof(Regon), ref regon, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string PhoneNumber
        {
            get => phoneNumber;
            set => SetPropertyValue(nameof(PhoneNumber), ref phoneNumber, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Email
        {
            get => email;
            set => SetPropertyValue(nameof(Email), ref email, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string PostalCode
        {
            get => postalCode;
            set => SetPropertyValue(nameof(PostalCode), ref postalCode, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string City
        {
            get => city;
            set => SetPropertyValue(nameof(City), ref city, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Street
        {
            get => street;
            set => SetPropertyValue(nameof(Street), ref street, value);
        }
    }
}
