using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Waze_Credit.Models;
using Waze_Credit.Models.ViewModels;
using Waze_Credit.Service;

namespace Waze_Credit.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM();
            MarketForecaster forecaster = new MarketForecaster();
            MarketResult currentMarket = forecaster.GetMarketPrediction();
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
            return View(homeVM);
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
