﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SiqnalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;

        public MenuTablesController(IMenuTableService menuTableService)
        {
            _menuTableService = menuTableService;
        }

        [HttpGet("MenuTableCount")]
        public ActionResult MenuTableCount() 
        {
            return Ok(_menuTableService.MenuTableCount());
        }
    }
}
