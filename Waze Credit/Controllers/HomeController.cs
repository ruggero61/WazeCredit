using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using Waze_Credit.Models;
using Waze_Credit.Models.ViewModels;
using Waze_Credit.Service;
using Waze_Credit.Utility.AppSettingsClasses;

namespace Waze_Credit.Controllers
{
    public class HomeController : Controller
    {
        private HomeVM homeVM;
        private readonly IMarketForecaster _marketForecaster;
        private readonly TestClass _testClassOptions;
        private readonly DatiRuggero _datiRuggeroOptions;
        public HomeController(IMarketForecaster marketForecaster, 
            IOptions<TestClass> testClassOptions,
            IOptions<DatiRuggero> datiRuggeroOptions)
        {
            homeVM = new HomeVM();
            _marketForecaster = marketForecaster;
            _testClassOptions = testClassOptions.Value;
            _datiRuggeroOptions = datiRuggeroOptions.Value;
        }

        public IActionResult Index()
        {
            MarketResult currentMarket = _marketForecaster.GetMarketPrediction();
            switch (currentMarket.Condition)
            {
                case MarketCondition.StableUp:
                    homeVM.MarketForecast = "The market is stable and going up!";
                    break;
                case MarketCondition.StableDown:
                    homeVM.MarketForecast = "The market is stable and going down!";
                    break;
                case MarketCondition.Volatile:
                    homeVM.MarketForecast = "The market is volatile!";
                    break;
                default:
                    homeVM.MarketForecast = "The market is stable!";
                    break;
            }
            homeVM.Nome = _datiRuggeroOptions.Nome;
            homeVM.Cognome = _datiRuggeroOptions.Cognome;
            homeVM.Indirizzo = _datiRuggeroOptions.Indirizzo;
            homeVM.Cap = _datiRuggeroOptions.Cap;
            homeVM.Eta = _datiRuggeroOptions.Eta;
            
            return View(homeVM);
        }

        public IActionResult AllDatiRuggero()
        { 
            List<string> list = new List<string>();
            list.Add($"Nome : {_datiRuggeroOptions.Nome}");
            list.Add($"Cognome : {_datiRuggeroOptions.Cognome}");
            list.Add($"Indirizzo : {_datiRuggeroOptions.Indirizzo}");
            list.Add($"Cap : {_datiRuggeroOptions.Cap}");
            list.Add($"Età : {_datiRuggeroOptions.Eta}");
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
