using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace InvoiceManager.Module.BusinessObjects
{
    [NavigationItem("Directories")]
    [DefaultClassOptions]
    [XafDisplayName("Position")]
    public class InvoicePosition : XPObject
    {
        public InvoicePosition(Session session) : base(session)
        { }

        Invoice invoices;
        decimal unitPrice;
        Goods goods;
        decimal grossValue;
        decimal vatValue;
        decimal netValue;
        decimal quantity;


        [ImmediatePostData]
        public Goods Goods
        {
            get => goods;
            set
            {
                SetPropertyValue(nameof(Goods), ref goods, value);
                if (Goods != null)
                {
                    UnitPrice = Goods.UnitPrice;
                }
                else
                {
                    UnitPrice = 0;
                }
            }
        }

        [ImmediatePostData]
        public decimal UnitPrice
        {
            get => unitPrice;
            set
            {
                bool modified = SetPropertyValue(nameof(UnitPrice), ref unitPrice, value);
                if (modified && !IsLoading && !IsSaving)
                {
                    RecalculateItems();
                }
            }
        }

        [ImmediatePostData]
        public decimal Quantity
        {
            get => quantity;
            set
            {
                bool modified = SetPropertyValue(nameof(Quantity), ref quantity, value);
                if (modified && !IsLoading && !IsSaving)
                {
                    RecalculateItems();
                }
            }
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

        
        [Association("object-InvoicePositions")]
        public Invoice Invoices
        {
            get => invoices;
            set => SetPropertyValue(nameof(Invoices), ref invoices, value);
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Quantity = 1;
        }

        private void RecalculateItems()
        {
            var rate = Goods?.VatRate?.Value ?? 0;
            NetValue = Quantity * UnitPrice;
            GrossValue = NetValue * (100 + rate) / 100;
            VatValue = GrossValue - NetValue;
        }
    }
}
