using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using Newtonsoft.Json;
using Quartz;
using Service;
using HtmlAgilityPack;
using AspMain.Web.Models;

namespace AspMain.Web.Scheduler
{
    public class AutoUpdate : IJob
    {
        private IConfigServices _configServices = new ConfigServices();

        public void Execute(IJobExecutionContext context)
        {
            Set();
        }

        public void Set()
        {
            try
            {
                var data = new PriceAll();
                var client = new WebClient();
                var content = client.DownloadString("https://api.coinmarketcap.com/v1/ticker/raiblocks");
                var jsonXRB = JsonConvert.DeserializeObject<List<PriceXRB>>(content);
                if (jsonXRB != null)
                {
                    data.PriceXRB = (float)Math.Round(float.Parse(jsonXRB[0].price_usd) * 20000, 0);
                }
                content = client.DownloadString("https://api.coinmarketcap.com/v1/ticker/bitcoin/");
                var jsonBTC = JsonConvert.DeserializeObject<List<PriceBTC>>(content);
                if (jsonBTC != null)
                {
                    data.PriceBTC = (float)Math.Round(float.Parse(jsonBTC[0].price_usd) * 22000, 0);
                }
                data.PriceUSD = 20000;
                //luu gia vao database
                var config = _configServices.GetConfig();
                if(config.GiaXRB != data.PriceXRB || config.GiaBTC != data.PriceBTC)
                {
                    config.GiaXRB = data.PriceXRB - 100;
                    config.GiaBTC = data.PriceBTC;
                    _configServices.UpdateConfig(config);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}