using Application.Common;
using Domain;

namespace Application.BusinessDomain.IService
{
    public interface ICustomerService
    {
        Task<Response<Customer>> CreateCustomer(Customer customer);
        Task<Response<Customer>> GetCustomerById(int id);
        Task<Response<IQueryable<Customer>>> GetAllCustomers();
        Task<Response<Customer>> UpdateCustomer(Customer customer);
    }
}
