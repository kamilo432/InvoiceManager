using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using AggregatedAttribute = DevExpress.Xpo.AggregatedAttribute;

namespace InvoiceManager.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Directories")]
    [XafDefaultProperty(nameof(InvoiceNumber))]
    public class Invoice : XPObject
    {
        public Invoice(Session session) : base(session)
        { }

        decimal vatValue;
        decimal netValue;
        decimal grossValue;
        string invoiceNumber;
        DateTime saleDate;
        DateTime paymentTerm;
        DateTime invoiceDate;
        Company company;


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string InvoiceNumber
        {
            get => invoiceNumber;
            set => SetPropertyValue(nameof(InvoiceNumber), ref invoiceNumber, value);
        }

        public Company Company
        {
            get => company;
            set => SetPropertyValue(nameof(Company), ref company, value);
        }
        public DateTime InvoiceDate
        {
            get => invoiceDate;
            set => SetPropertyValue(nameof(InvoiceDate), ref invoiceDate, value);
        }

        public DateTime SaleDate
        {
            get => saleDate;
            set => SetPropertyValue(nameof(SaleDate), ref saleDate, value);
        }

        public DateTime PaymentTerm
        {
            get => paymentTerm;
            set => SetPropertyValue(nameof(PaymentTerm), ref paymentTerm, value);
        }

        public decimal GrossValue
        {
            get => grossValue;
            set => SetPropertyValue(nameof(GrossValue), ref grossValue, value);
        }

        public decimal NetValue
        {
            get => netValue;
            set => SetPropertyValue(nameof(NetValue), ref netValue, value);
        }

        public decimal VatValue
        {
            get => vatValue;
            set => SetPropertyValue(nameof(VatValue), ref vatValue, value);
        }

        [Association("object-InvoicePositions"), Aggregated]
        public XPCollection<InvoicePosition> InvoicePositions
        {
            get
            {
                return GetCollection<InvoicePosition>(nameof(InvoicePositions));
            }
        }

        public void RecalculateTotals(bool forceChange = true)
        {
            decimal oldNetValue = NetValue;
            decimal oldVatValue = VatValue;
            decimal oldGrossValue = GrossValue;

            decimal tmpNetValue = 0m;
            decimal tmpVatValue = 0m;
            decimal tmpGrossValue = 0m;

            foreach (var position in InvoicePositions)
            {
                tmpNetValue += position.NetValue;
                tmpVatValue += position.VatValue;
                tmpGrossValue += position.GrossValue;
            }

            netValue = tmpNetValue;
            vatValue = tmpVatValue;
            grossValue = tmpGrossValue;

            if (forceChange)
            {
                OnChanged(nameof(NetValue), oldNetValue, netValue);
                OnChanged(nameof(VatValue), oldVatValue, vatValue);
                OnChanged(nameof(GrossValue), oldGrossValue, grossValue);
            }
        }

        [Action(Caption = "Recalculate", ImageName = "CalculateNow")]
        public void RecalculateInvoice()
        {
            RecalculateTotals();
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            SaleDate = DateTime.Now;
            InvoiceDate = DateTime.Now;
            PaymentTerm = InvoiceDate.AddDays(30);
        }
    }
}
