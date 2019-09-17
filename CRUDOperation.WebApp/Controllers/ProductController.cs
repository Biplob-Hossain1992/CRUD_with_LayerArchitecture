using System.Linq;
using CRUDOperation.Models;
using CRUDOperation.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CRUDOperation.Abstractions.BLL;
using CRUDOperation.Models.RazorViewModels.Product;
using System;
using AutoMapper;

namespace CRUDOperation.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private IProductManager _productManager;
        private CategoryRepository _categoryRepository;

        private IMapper _mapper;
        public ProductController(IProductManager productManager,IMapper mapper)
        {
            _productManager = productManager;
            _categoryRepository = new CategoryRepository(); //Dropdown List

            _mapper = mapper;

        }
        public IActionResult Index()
        {
            var products =_productManager.GetAll();
            return RedirectToAction(nameof(Create));
        }

        public IActionResult Create()
        {
            var products = _productManager.GetAll();
            var model = new ProductCreateViewModel();
            model.ProductList = products.ToList();
            PopulateDropdownList(); /*Dropdown List Binding*/
            return View(model);
        }

        [HttpPost]

        public IActionResult Create(ProductCreateViewModel model,IFormFile ImageUrl)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(model); //AutoMapper

                bool isAdded = _productManager.Add(product);
                if (isAdded)
                {
                    ViewBag.SuccessMessage = "Saved Successfully!";
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Operation Failed!";
            }

            model.ProductList = _productManager.GetAll().ToList();
            PopulateDropdownList(model.CategoryId); /*Dropdown List Binding*/
            return View(model);
        }

        //public PartialViewResult ProductListPartial()
        //{
        //    var products = _productRepository.GetAll();
        //    return PartialView("Product/_ProductList", products);
        //}

        private void PopulateDropdownList(object selectList=null) /*Dropdown List Binding*/
        {
            var category = _categoryRepository.GetAll();
            ViewBag.SelectList = new SelectList(category, "Id", "Name", selectList);
        }
        public IActionResult Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var product = _productManager.GetById((Int64)id);
            if (product == null)
            {
                return NotFound();
            }

            PopulateDropdownList(product.CategoryId);

            var productCreateViewModel = new ProductCreateViewModel();

            productCreateViewModel.ProductList = _productManager.GetAll().ToList();

            productCreateViewModel.Name = product.Name;
            productCreateViewModel.Price = product.Price;
            productCreateViewModel.ExpireDate = product.ExpireDate;
            productCreateViewModel.IsActive = product.IsActive;
            productCreateViewModel.Category = product.Category;
            productCreateViewModel.CategoryId = Convert.ToInt32(product.CategoryId);
            return View("Create", productCreateViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Price,ExpireDate,IsActive,CategoryId,CategoryName")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            PopulateDropdownList(product.CategoryId);

            if (ModelState.IsValid)
            {
                bool isUpdated = _productManager.Update(product);
                if (isUpdated)
                {
                    var products = _productManager.GetAll();
                    ViewBag.SuccessMessage = "Updated Successfully!";
                    return View("Index", products);
                }
            }
            return View(product);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productManager.GetById((Int64)id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteConfirmed(int id)
        {
            var product = _productManager.GetById(id);
            if (ModelState.IsValid)
            {
                bool isDeleted = _productManager.Delete(product);
                if (isDeleted)
                {
                    var products = _productManager.GetAll();
                    ViewBag.SuccessMessage = "Data Deleted Successfully.!";
                    return View("Index", products);
                }

            }
            return RedirectToAction(nameof(Index));
        }

        //private bool CustomerExists(int id)
        //{
        //    return _productManager.ProductExists(id);
        //}

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productManager.GetById((Int64)id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}