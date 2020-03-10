﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Entities.DTO;
using WebStore.Domain.ViewModels;
using WebStore.Models.Interfaces;

namespace WebStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _ordersService;

        public CartController(ICartService cartService, IOrderService ordersService)
        {
            _cartService = cartService;
            _ordersService = ordersService;
        }

        public IActionResult Details()
        {
            var model = new DetailsViewModel()
            {
                CartViewModel = _cartService.TransformCart(),
                OrderViewModel = new OrderViewModel()
            };
            return View(model);
        }

        public IActionResult DecrementFromCart(int id)
        {
            _cartService.DecrementFromCart(id);
            return RedirectToAction("Details");
        }

        public IActionResult RemoveFromCart(int id)
        {
            _cartService.RemoveFromCart(id);
            return RedirectToAction("Details");
        }

        public IActionResult RemoveAll()
        {
            _cartService.RemoveAll();
            return RedirectToAction("Details");
        }

        public IActionResult AddToCart(int id, string returnUrl)
        {
            _cartService.AddToCart(id);
            return Json(new { id, message = "Товар добавлен в корзину" });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CheckOut(OrderViewModel model, [FromServices] IOrderService OrderService)
        {
            if (ModelState.IsValid)
            {
                var create_order_model = new CreateOrderModel
                {
                    OrderViewModel = model,
                    OrderItems = _cartService.TransformCart().Items
                       .Select(item => new OrderItemDto
                       {
                           Id = item.Key.Id,
                           Price = item.Key.Price,
                           Quantity = item.Value
                       })
                       .ToList()
                };
                var orderResult = _ordersService.CreateOrder(create_order_model, User.Identity.Name);
                _cartService.RemoveAll();
                return RedirectToAction("OrderConfirmed", new { id = orderResult.Id });
            }
            var detailsModel = new DetailsViewModel()
            {
                CartViewModel = _cartService.TransformCart(),
                OrderViewModel = model
            };
            return View("Details", detailsModel);
        }

        public IActionResult OrderConfirmed(int id)
        {
            ViewBag.OrderId = id;
            return View();
        }

        #region API

        public IActionResult GetCartView() => ViewComponent("Cart");

        public IActionResult AddToCartAPI(int id)
        {
            _cartService.AddToCart(id);
            return Json(new { id, message = $"Товар id:{id} был успешно добавлен в корзину" });
        }

        public IActionResult DecrimentFromCartAPI(int id)
        {
            _cartService.DecrementFromCart(id);
            return Json(new { id, message = $"Количество товара с id:{id} в корзине было уменьшено на 1" });
        }

        public IActionResult RemoveFromCartAPI(int id)
        {
            _cartService.RemoveFromCart(id);
            return Json(new { id, message = $"Товар id:{id} был удалён из корзины" });
        }

        public IActionResult RemoveAllAPI()
        {
            _cartService.RemoveAll();
            return Json(new { message = "Корзина была очищена" });
        }
        #endregion
    }

}