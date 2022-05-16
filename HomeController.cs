using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DBContext;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using TrueATM.Models;

namespace TrueATM.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _Context;

        public HomeController(Context db)
        {
            _Context = db;
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult SignUpAdd(MVUser MU)
        {
            TblUser tu =
                new TblUser()
                {
                    Id = MU.Id,
                    HolderName = MU.HolderName,
                    cash = MU.cash,
                    PassWord = MU.PassWord,
                    NameBank = MU.NameBank,
                    CardNumber = MU.CardNumber
                };
            _Context.tblUsers.Add (tu);
            _Context.SaveChanges();
            return RedirectToAction("Register");
        }

        public IActionResult SignIn(int PassWord)
        {
            var select =
                _Context
                    .tblUsers
                    .Where(a => a.PassWord == PassWord)
                    .FirstOrDefault();

            if (select != null)
            {
                return RedirectToAction("Menu");
            }
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }

        public IActionResult ShowInventory(int PassWord)
        {
            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        public IActionResult CardToCard()
        {
            return View();
        }

        public IActionResult WithDrawal()
        {
            return View();
        }
    }
}
