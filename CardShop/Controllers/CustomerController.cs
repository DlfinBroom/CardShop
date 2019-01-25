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
            Customer customer = new Customer();
            customer.FirstName = data["FirstName"];
            customer.LastName = data["LastName"];
            customer.Password = data["Password"];
            customer.Email = data["Email"];
            customer.PhoneNum = Convert.ToInt32(data["PhoneNum"]);

            // Add to DB

            ViewData["Msg"] = "Thank you " + data["FirstName"] + " " 
                                           + data["LastName"] + " for registering.";

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
                ViewData["Msg"] = "Thank you " + cus.FirstName + " " +
                    cus.LastName + " for registering.";

                // Add to DB
            }
            return View(cus);
        }
    }
}