using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyProject.BLL.IServices;
using MyProject.DAL.Repositories;
using MyProject.DTOs.FromCityDTOs;
using MyProject.Models;
using System.Collections.Generic;

namespace MyProject.Controllers
{
    public class FromCityController : Controller
    {

        private readonly FromCityRepository customerRepository;

        public FromCityController(IConfiguration configuration)
        {
            customerRepository = new FromCityRepository(configuration);
        }


        public IActionResult Index()
        {
            return View(customerRepository.FindAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FromCity cust)
        {
            if (ModelState.IsValid)
            {
                customerRepository.Add(cust);
                return RedirectToAction("Index");
            }
            return View(cust);

        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            FromCity obj = customerRepository.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        [HttpPost]
        public IActionResult Edit(FromCity obj)
        {

            if (ModelState.IsValid)
            {
                customerRepository.Update(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            customerRepository.Delete(id.Value);
            return RedirectToAction("Index");
        }


        //public IFromCityService _fromCityService;

        //public FromCityController(IFromCityService fromCityService)
        //{
        //    _fromCityService = fromCityService;
        //}

        //public IActionResult Get()
        //{
        //    List<FromCityToListDTO> cities = _fromCityService.Get();
        //    return View(cities);
        //}

        //public IActionResult AddForm()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Add(FromCityToAddDTO fromCityToAddDTO)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _fromCityService.Add(fromCityToAddDTO);
        //        return RedirectToAction("Get");
        //    }
        //    return View("AddForm",fromCityToAddDTO);
        //}

        //public IActionResult UpdateForm(int fCityId)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        FromCityToListDTO fCity = _fromCityService.GetById(fCityId);
        //        return View(fCity);
        //    }
        //    return View("UpdateForm");
        //}

        //public IActionResult Update(FromCityToUpdateDTO fromCityToUpdateDTO)
        //{
        //    FromCityToListDTO fCity = _fromCityService.Update(fromCityToUpdateDTO);
        //    return RedirectToAction("Get");
        //}

        //public IActionResult Delete(int fCityId)
        //{
        //    _fromCityService.Delete(fCityId);
        //    return RedirectToAction("Get");
        //}

    }
}
