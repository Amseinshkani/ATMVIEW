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

        public static int id;

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
            var select =_Context.tblUsers.Where(a => a.PassWord == PassWord).FirstOrDefault();

            id =_Context.tblUsers.Where(a => a.PassWord == PassWord).Select(a => a.Id).FirstOrDefault();

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

        public IActionResult ShowInventory()
        {
            var Select =
                _Context.tblUsers.Where(a => a.Id == id).FirstOrDefault();
            MVUser A =new MVUser()
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

        public IActionResult ChangePassword(int Id)
        {
            var Select =_Context.tblUsers.Where(a => a.Id == Id).SingleOrDefault();

                MVUser A =new MVUser()
            {
                Id = Select.Id,
                 PassWord = Select.PassWord
            };
            return View(A);
        }

        public IActionResult EditPass(MVUser x)
        {
            var Select =
                _Context.tblUsers.Where(a => a.Id == x.Id).SingleOrDefault();

            Select.Id = x.Id;
            Select.PassWord = x.PassWord;

            _Context.tblUsers.Update (Select);
            _Context.SaveChanges();
            return RedirectToAction("Register");
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
