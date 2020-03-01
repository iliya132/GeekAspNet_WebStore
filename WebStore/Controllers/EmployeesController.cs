﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;
using WebStore.Models.Interfaces;

namespace WebStore.Controllers
{
    [Route("Employees")]
    public class EmployeesController : Controller
    {
        List<Employee> _employees;
        IEmployeeDataProvider _db;

        public EmployeesController(IEmployeeDataProvider dataContext)
        {
            _db = dataContext;
        }

        [Route("index")]
        public IActionResult Index()
        {
            _employees = _db.GetAll().ToList();
            return View(_employees);
        }

        public IActionResult Details(int id)
        {
            Employee employee = _db.GetById(id);
            if (employee != null)
                return View(employee);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("edit/{id?}")]
        public IActionResult Edit(int? id)
        {
            Employee model;
            if (id.HasValue)
            {
                model = _db.GetById(id.Value);
                if (ReferenceEquals(model, null))
                    return NotFound();// возвращаем результат 404 Not Found
            }
            else
            {
                model = new Employee();
            }
            return View(model);
        }

        [HttpPost]
        [Route("Edit/{id?}")]
        public IActionResult Edit(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            if (employee.Id > -1)
            {
                Employee oldEmployee = _db.GetById(employee.Id);
                if (oldEmployee == null)
                    return NotFound();
                oldEmployee.FirstName = employee.FirstName;
                oldEmployee.LastName = employee.LastName;
                oldEmployee.Patronymic = employee.Patronymic;

            }
            else
            {
                _db.AddNew(employee);
            }
            _db.Commit();

            return RedirectToAction(nameof(Index));
        }


    }
}