using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Eskoy.Models;
using Eskoy.Models.InputViewModels;
using Eskoy.Models.ViewModels;
using Eskoy.Services;
using Microsoft.AspNetCore.Http;

namespace Eskoy.Controllers
{
    public class HomeController : Controller
    {

        private string GetLaungaugeByCookie(){

            string laungauge = Request.Cookies["laungauge"].ToString();
            if (laungauge == ""){
                return "norwegian";
            }
            else {
                return laungauge;
            }
        }
        public IActionResult SetLaungaugeCookie( string lang ){
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Append("laungauge", lang);

            return Ok();
        }

        private HomeService _hs = new HomeService();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Historie()
        {
            var cards = new List<CardViewModel>();
            cards.Add( new CardViewModel{
                Title = "Capter 1",
                Body =  "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Earum assumenda sapiente, provident ducimus eius unde vitae repellat, dicta nesciunt maxime culpa doloremque expedita fugit repudiandae incidunt laborum consequatur necessitatibus? Iusto!",
                Image = "/images/history4.jpg",
                ReadMore = "Read More"
            });
            cards.Add( new CardViewModel{
                Title = "Capter 2",
                Body =  "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Earum assumenda sapiente, provident ducimus eius unde vitae repellat, dicta nesciunt maxime culpa doloremque expedita fugit repudiandae incidunt laborum consequatur necessitatibus? Iusto!",
                Image = "/images/history2.jpg",
                ReadMore = "Read More"
            });
            HistoryViewModel englishTranslation = new HistoryViewModel{
                CaroselTitle = "History",
                Cards = cards
            };
            
            HistoryViewModel norweganTranslation = new HistoryViewModel{
                CaroselTitle = "Historie",
                Cards = cards
            };
            if( GetLaungaugeByCookie() == "english"){
                return View( englishTranslation );
            }
            else {
                return View( norweganTranslation );
            }
        }
        public IActionResult Vareskip()
        {
            return View();
        }
        public IActionResult Jobbsokander()
        {
            return View();
        }
        public IActionResult Tilskudd()
        {
            return View();
        }
        public IActionResult Fisketjeneste()
        {
            return View();
        }
        public IActionResult kontaktinformasjon(){
            return View();
        }
        public IActionResult JobApplication(ResumeInputmodel input){
            if( _hs.ValitadeSentFile( input.attachment )){
                
                string subject = "Atvinnu umsókn frá " + input.name;
                string body = "Nafn : " + input.name + " \n ";
                body += "Email : " + input.email + " \n ";
                body += "Simanumer : " + input.phoneNumber + " \n";
                body += "\n \n";
                body += "Um mig \n";
                body += input.aboutYourSelf;

                _hs.SendEmail( input.attachment, subject, body);
                return RedirectToAction("Jobbsokander");
            }
            return Error();
        }
        public IActionResult GrantApplication( GrantInputmodel input ){

            string subject = "Styrktar umsókn frá " + input.name;
            string body = "Nafn : " + input.name + " \n ";
            body += "Email : " + input.email + " \n ";
            body += "Simanumer : " + input.phoneNumber + " \n";
            body += "umbeðinn upphæð : " + input.ammount + " \n";
            body += "\n \n";
            body += "Hversvegna er beðið um styrk : \n";
            body += input.aboutYourSelf;

            _hs.SendEmail( null, subject, body);
            return RedirectToAction("Tilskudd");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
