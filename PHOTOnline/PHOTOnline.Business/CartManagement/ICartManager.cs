using PhotoLine.Domain.Interop;
using PHOTOnline.Business.CartManagement.Input;
using System.Threading.Tasks;

namespace PHOTOnline.Business.CartManagement
{
    public interface ICartManager
    {
        Task<Result<string>> AddToCart(CreateCartInput input);
        Task<Result> DeleteItem(string cartId, string itemId);
    }
}
