﻿using MediatR;
using NorthWind.Entities.Exceptions;
using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOEntities;
using System.Diagnostics.Metrics;

namespace NorthWind.UseCases.CreateOrder {
    public class CreateOrderInteractor : IRequestHandler<CreateOrderInputPort, int> {
        readonly IOrderRepository OrderRepository;
        readonly IOrderDetailRepository OrderDetailRepository;
        readonly IUnitOfWork UnitOfWork;
        public CreateOrderInteractor(IOrderRepository orderRepository,
                IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork) =>
            (OrderRepository, OrderDetailRepository, UnitOfWork) =
            (orderRepository, orderDetailRepository, unitOfWork);

        public async Task<int> Handle(CreateOrderInputPort request, 
            CancellationToken cancellationToken) {
            Order Order = new Order {
                CustomerId = request.CustomerId,
                OrderDate = DateTime.Now,
                ShipAddress = request.ShipAddress,
                ShipCity = request.ShipCity,
                ShipCountry = request.ShipCountry,
                ShipPostalCode = request.ShipPostalCode,
                ShippingType = Entities.Enums.ShippingType.Road,
                DiscountType = Entities.Enums.DiscountType.Percentage,
                Discount = 10
            };
            OrderRepository.Create(Order);
            foreach (var item in request.OrderDetails) {
                OrderDetailRepository.Create(
                    new OrderDetail {
                        Order = Order,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice
                    }) ;
            }
            try {
                await UnitOfWork.SaveChangesAsync();
            } catch (Exception ex) {
                throw new GeneralException("Error al crear la orden.", ex.Message);
            }
            return Order.Id;
        }
    }
}