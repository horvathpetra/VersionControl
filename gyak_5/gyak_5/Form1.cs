using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using gyak_5.Entities;
using gyak_5.MnbServiceReference;


namespace gyak_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ExchangeRates();
            dataGridView1.DataSource = Rates;
            GetXML();
        }

        List<GetExchangeRatesRequestBody> ExchangeRateData = new List<GetExchangeRatesRequestBody>();

        BindingList<RateData> Rates = new BindingList<RateData>();
        

        private string ExchangeRates()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody
            {
                currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = "2022-06-30"
            };

            var response = mnbService.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;
            GetXML(result);
        }

        private void GetXML(string result)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(result);
            foreach (XmlElement x in xml.DocumentElement)
            {
                var firstchild = (XmlElement)x.ChildNodes[0];

                RateData r = new RateData
                {
                    Date = DateTime.Parse(x.GetAttribute("date")),
                    Currency = firstchild.GetAttribute("curr")
                };

                

                Rates.Add(r);
            }
        }
    }
}
