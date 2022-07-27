﻿using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services.Interfaces;

namespace WebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IIdentityService _identityService;

        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SigninInput signinInput)
        {
            if (!ModelState.IsValid)
                return View();

            var response = await _identityService.SignIn(signinInput);

            if (!response.IsSuccessful)
            {
                response.Errors.ForEach(error =>
                {
                    ModelState.AddModelError(String.Empty, error);
                });

                return View(response);
            }

            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
