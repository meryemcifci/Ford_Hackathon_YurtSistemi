﻿using Microsoft.AspNetCore.Mvc;

namespace Ford_Hackhathon_YurtSistemi.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
