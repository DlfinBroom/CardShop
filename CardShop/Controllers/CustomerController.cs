using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CardShop.Models;
using Microsoft.AspNetCore.Http;

namespace CardShop.Controllers {
    public class CustomerController : Controller {
        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        public IActionResult Register() {
            return View();
        }
        [HttpPost]
        public IActionResult Register(IFormCollection data) {
            Customer cus = new Customer();
            cus.FirstName = data["FirstName"];
            cus.LastName = data["LastName"];
            cus.Password = data["Password"];
            cus.Email = data["Email"];
            cus.PhoneNum = Convert.ToInt32(data["PhoneNum"]);

            if (CustomerDB.AddCustomer(cus)) {
                ViewData["Msg"] = "Thank you " +
                    cus.FirstName + " " + cus.LastName +
                    ", your information was added to the data base.";
            }
            else {
                ViewData["Msg"] = "Sorry, there was an error with adding you, " +
                    "try again later.";
            }

            return View();
        }

        [HttpGet]
        public IActionResult SignUp() {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(Customer cus) {
            // Validate input
            if (ModelState.IsValid) {
                if (CustomerDB.AddCustomer(cus)) {
                    ViewData["Msg"] = "Thank you " +
                        cus.FirstName + " " + cus.LastName +
                        ", your information was added to the data base.";
                }
                else {
                    ViewData["Msg"] = "Sorry, there was an error with adding you, " +
                        "try again later.";
                }
            }
            return View(cus);
        }
    }
}