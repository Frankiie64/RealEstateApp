﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.RealEstateApp.Controllers
{
    public class AgentController : Controller
    {
        private readonly IUserService userService;
        private readonly IHttpContextAccessor context;
        AuthenticationResponse user;
        public async Task<IActionResult> Index()
        {
            ViewBag.Agents = await userService.GetAllAgentAsync();
            return View();
        }
    }
}
