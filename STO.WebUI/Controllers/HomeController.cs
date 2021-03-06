﻿using Newtonsoft.Json;
using PagedList;
using STO.Domain.Concrete;
using STO.Domain.DAL;
using STO.Domain.Entities;
using STO.Domain.Interfaces;
using STO.WebUI.Models;
using STO.WebUI.Service;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace STO.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult GetCarViewModel()
        {
            return PartialView("Forms/CarFormView");
        }

        public ActionResult GetBusViewModel()
        {
            return PartialView("Forms/BusFormView");
        }

        public ActionResult GetTruckViewModel()
        {
            return PartialView("Forms/TruckFormView");
        }

        public ActionResult Index()
        {
            var service = new Service<TypeCarViewModel, TypeCar>(_unitOfWork);            
            return View(service.GetLists());
        }
        public ActionResult ShowResult(int? page)
        {
            int pageSize = 2;// винести в файли налаштування
            int pageNumber = (page ?? 1);
            var result = new Service<CarResultViewModel, CarResult>(_unitOfWork);
            return View(result.GetLists().OrderByDescending(c=>c.CreatedDate).ToPagedList(pageNumber, pageSize));
        }       
    }
}
