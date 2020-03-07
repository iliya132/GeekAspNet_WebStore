using WebStore.Domain.ViewModels;

namespace WebStore.Models.Interfaces
{
    public interface ICartService
    {
        void DecrementFromCart(int id);

        void RemoveFromCart(int id);

        void RemoveAll();

        void AddToCart(int id);

        CartViewModel TransformCart();
    }

}
