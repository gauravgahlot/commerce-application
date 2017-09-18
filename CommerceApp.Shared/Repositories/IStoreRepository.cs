using CommerceApp.Shared.Models;

namespace CommerceApp.Shared.Repositories
{
    public interface IStoreRepository
    {
        void UpdateInventoryForProduct(Product lineItem);
    }
}
