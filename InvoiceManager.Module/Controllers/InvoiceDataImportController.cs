using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using InvoiceManager.Module.Utils;
using InvoiceManager.Module.BusinessObjects;

namespace InvoiceManager.Module.Controllers
{
    [DefaultClassOptions]
    public class InvoiceDataImportController : ObjectViewController<DetailView, Company>
    {
        public InvoiceDataImportController()
        {
            SimpleAction importInvoiceData = new SimpleAction(this, "ImportInvoiceData", PredefinedCategory.View)
            {
                Caption = "Download company data from GUS",
                ImageName = "EnableSearch"
            };

            GusApiConnection apiConnection = new GusApiConnection();

            importInvoiceData.Execute += apiConnection.Connection;
        }
    }
}
