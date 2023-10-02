using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
public class CompanyController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CompanyController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        var objCompanyList = _unitOfWork.Company.GetAll().ToList();
        return View(objCompanyList);
    }
    
    public IActionResult Upsert(int? id)
    {
        var company = new Company();
        if (id == null || id == 0)
        {
            //create
            return View(company);
        }
        else
        {
            //update
            company = _unitOfWork.Company.GetValueOrDefault(u => u.Id == id);
            return View(company);
        }
    }

    [HttpPost, ActionName("Upsert")]
    public IActionResult UpsertPost(Company company, IFormFile? file)
    {
        if (ModelState.IsValid)
        {
            if (company.Id == 0)
            {
                _unitOfWork.Company.Add(company);
            }
            else
            {
                _unitOfWork.Company.Update(company);
            }

            _unitOfWork.Save();
            TempData["success"] = "Product created successfully";
            return RedirectToAction("Index");
        }
        else
        {
            return View(company);
        }
    }
    
    #region API CALLS

    [HttpGet]
    public IActionResult GetAll()
    {
        var objProductList = _unitOfWork.Company.GetAll().ToList();
        return Json(new { data = objProductList });
    }
    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        Company? obj = _unitOfWork.Company.GetValueOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return NotFound();
        }

        _unitOfWork.Company.Delete(obj);

        _unitOfWork.Save();
        TempData["success"] = "Company deleted successfully";

        return RedirectToAction("Index");
    }
    #endregion
}

