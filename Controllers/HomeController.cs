using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
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

        public static int id;

        public static long Money;

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

            id =
                _Context
                    .tblUsers
                    .Where(a => a.PassWord == PassWord)
                    .Select(a => a.Id)
                    .FirstOrDefault();

            if (select != null)
            {
                return RedirectToAction("Menu");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        public IActionResult Menu()
        {
            ViewBag.w = _Context.tblUsers.ToList();
            return View();
        }

        public IActionResult ShowInventory()
        {
            var Select =
                _Context.tblUsers.Where(a => a.Id == id).FirstOrDefault();
            MVUser A =
                new MVUser()
                {
                    Id = Select.Id,
                    HolderName = Select.HolderName,
                    NameBank = Select.NameBank,
                    cash = Select.cash,
                    PassWord = Select.PassWord,
                    CardNumber = Select.CardNumber
                };
            return View(A);
        }

        public IActionResult ChangePassword()
        {
            var Select =
                _Context.tblUsers.Where(a => a.Id == id).SingleOrDefault();

            MVUser A =
                new MVUser() { Id = Select.Id, PassWord = Select.PassWord };
            return View(A);
        }

        public IActionResult EditPass(MVUser x)
        {
            var Select =
                _Context.tblUsers.Where(a => a.Id == id).SingleOrDefault();

            Select.PassWord = x.PassWord;

            _Context.tblUsers.Update (Select);
            _Context.SaveChanges();
            return RedirectToAction("Register");
        }

        public IActionResult CardToCard()
        {
            var Select =
                _Context.tblUsers.Where(a => a.Id == id).SingleOrDefault();
            return View();
        }

        public IActionResult CTCPage(MVUser x)
        {
            var Select =
                _Context.tblUsers.Where(a => a.Id == id).FirstOrDefault();
                var s = _Context.tblUsers.Where(a=>a.CardNumber==x.CardNumber).FirstOrDefault();
            if (Select.CardNumber != null)
            {
                if (Select.cash >= x.cash)
                {
                    Select.cash = Select.cash - x.cash;

                    _Context.tblUsers.Update (Select);
                    _Context.SaveChanges();
                }
                if (x.CardNumber == s.CardNumber)
                {
                   s.cash=x.cash+x.cash;
                    _Context.tblUsers.Update (s);
                    _Context.SaveChanges();
                }
            }

            return RedirectToAction("ShowInventory");
        }

        public IActionResult WithDrawal()
        {
            var Select =
                _Context.tblUsers.Where(a => a.Id == id).SingleOrDefault();
            return View();
        }

        public IActionResult WithDrawalNegative(MVUser x)
        {
            var Select =
                _Context.tblUsers.Where(a => a.Id == id).SingleOrDefault();

            if (Select.cash >= x.cash)
            {
                Select.cash = Select.cash - x.cash;

                _Context.tblUsers.Update (Select);
                _Context.SaveChanges();
                return RedirectToAction("ShowInventory");
            }
            else
            {
                ViewBag.alert = "موجودی کافی نیست";
            }
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
