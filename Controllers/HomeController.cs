using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Eskoy.Models;
using Eskoy.Models.InputViewModels;
using Eskoy.Services;

namespace Eskoy.Controllers
{
    public class HomeController : Controller
    {
        private HomeService _hs = new HomeService();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Historie()
        {
            return View();
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
