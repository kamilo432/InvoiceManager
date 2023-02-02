using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace InvoiceManager.Module.BusinessObjects
{
    [NavigationItem("Directories")]
    [DefaultClassOptions]
    [XafDefaultProperty(nameof(Name))]
    public class Goods : XPObject
    {
        public Goods(Session session) : base(session)
        { }

        VatRate vatRate;
        decimal unitPrice;
        string eAN;
        string name;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string EAN
        {
            get => eAN;
            set => SetPropertyValue(nameof(EAN), ref eAN, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        public decimal UnitPrice
        {
            get => unitPrice;
            set => SetPropertyValue(nameof(UnitPrice), ref unitPrice, value);
        }

        public VatRate VatRate
        {
            get => vatRate;
            set => SetPropertyValue(nameof(VatRate), ref vatRate, value);
        }
    }
}
