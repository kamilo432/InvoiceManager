using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace InvoiceManager.Module.BusinessObjects
{
    [NavigationItem("Directories")]
    [DefaultClassOptions]
    [XafDefaultProperty(nameof(Symbol))]
    public class VatRate : XPObject
    {
        public VatRate(Session session) : base(session)
        { }

        decimal value;
        string symbol;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Symbol
        {
            get => symbol;
            set => SetPropertyValue(nameof(Symbol), ref symbol, value);
        }

        public decimal Value
        {
            get => value;
            set => SetPropertyValue(nameof(Value), ref this.value, value);
        }
    }
}
