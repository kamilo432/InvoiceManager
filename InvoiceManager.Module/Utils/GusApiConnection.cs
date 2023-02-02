using DevExpress.ExpressApp.Actions;
using InvoiceManager.Module.BusinessObjects;
using Newtonsoft.Json.Linq;
using JObject = Newtonsoft.Json.Linq.JObject;

namespace InvoiceManager.Module.Utils
{
    public class GusApiConnection
    {
        public void Connection(object s, SimpleActionExecuteEventArgs e)
        {
            try
            {
                foreach (Company task in e.SelectedObjects)
                {
                    var Date = DateTime.Now.ToString("yyyy-MM-dd");
                    string Url = $"https://wl-api.mf.gov.pl/api/search/nip/{task.NIP}?date={Date}";

                    var Client = new HttpClient();

                    var Response = Client.GetStringAsync(Url).Result;

                    var FormattedResponse = JObject.Parse(Response);

                    var CustomerName = FormattedResponse["result"]["subject"]["name"];
                    var regon = FormattedResponse["result"]["subject"]["regon"];

                    var Address = FormattedResponse["result"]["subject"]["workingAddress"];
                    var ResAddress = FormattedResponse["result"]["subject"]["residenceAddress"];

                    var address = Address.ToString();
                    var resAddress = ResAddress.ToString();

                    var Index1 = address.IndexOf(",");
                    var Index2 = resAddress.IndexOf(",");

                    if (Address.Type == JTokenType.Null)
                    {
                        var Street2 = resAddress.Substring(0, Index2);
                        var City2 = resAddress.Substring(Index2 + 8).Trim();
                        var PostalCode2 = resAddress.Substring(Index2 + 2, 6);
                        task.PostalCode = PostalCode2;
                        task.City = City2;
                        task.Street = Street2;
                    }
                    else if (ResAddress.Type == JTokenType.Null)
                    {
                        var Street = address.Substring(0, Index1);
                        var City = address.Substring(Index1 + 8).Trim();
                        var PostalCode = address.Substring(Index1 + 2, 6);
                        task.PostalCode = PostalCode;
                        task.City = City;
                        task.Street = Street;
                    }

                    task.CompanyName = CustomerName.ToString();
                    task.Regon = regon.ToString();
                }
            }
            catch (NullReferenceException) { }
            catch (HttpRequestException) { }
            catch (AggregateException) { }
        }
    }
}
