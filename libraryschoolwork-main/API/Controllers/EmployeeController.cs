using Domain.Abstractions.Services;
using Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService service;

        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            var emps = await service.GetAllAsync();
            
            return View(emps);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeDto employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            try
            {
                await service.CreateAsync(employee);
                TempData["success"] = "Employee created successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var employee = await service.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await service.UpdateAsync(model);
                TempData["success"] = "Employee edited successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var employee = await service.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int id)
        {
            var employee = service.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            await service.DeleteAsync(id);
            TempData["success"] = "Employee deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
