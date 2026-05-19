// Entities/Order.cs
using tienda.Domain.ValueObjects;
using tienda.Domain.Enums;
using tienda.Domain.Exceptions;

namespace tienda.Domain.Entities;

public class Order : BaseEntity
{
    public Guid UserId { get; private set; }
    public DateTime OrderDate { get; private set; }
    public Money TotalAmount { get; private set; } = null!;
    public OrderStatus Status { get; private set; }
    
    // Relación: Una orden tiene muchos ítems (simplificado para el ejemplo)
    private readonly List<Product> _products = new();
    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

    private Order() { }

    public static Order Create(Guid userId, Money initialAmount)
    {
        return new Order
        {
            UserId = userId,
            OrderDate = DateTime.UtcNow,
            TotalAmount = initialAmount,
            Status = OrderStatus.Pending
        };
    }

    public void CompleteOrder()
    {
        if (Status != OrderStatus.Pending)
            throw new DomainException("Solo se pueden completar órdenes pendientes.");

        Status = OrderStatus.Confirmed;
    }

    public void CancelOrder()
    {
        Status = OrderStatus.Cancelled;
    }
}