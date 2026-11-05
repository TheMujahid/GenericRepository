using Application.BusinessDomain.IService;
using Application.Common;
using Application.IRepository;
using Domain;

namespace Application.BusinessDomain.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenericRepository<Customer> _repo;

        public CustomerService(IGenericRepository<Customer> repo)
        {
            _repo = repo;
        }

        public async Task<Response<Customer>> CreateCustomer(Customer customer)
        {
            Response<Customer> response = null;
            var isCreated = await _repo.Create(customer);

            if (isCreated)
            {
                response = new Response<Customer>()
                {
                    Status = new Status
                    {
                        Success = true,
                        Message = "Customer Created Successfully!!"
                    },
                    Data = customer
                };
            }
            else
            {
                response = new Response<Customer>()
                {
                    Status = new Status
                    {
                        Success = false,
                        Message = "Sorry!!, Please try again after sometime."
                    },
                    Data = null
                };
            }
            return response;

        }

        public async Task<Response<IQueryable<Customer>>> GetAllCustomers()
        {
            Response<IQueryable<Customer>> response = null;
            var data = _repo.GetAll();
            if (data == null)
            {
                response = new Response<IQueryable<Customer>>()
                {
                    Status = new Status
                    {
                        Success = false,
                        Message = "Sorry!!, Please try again after sometime."
                    },
                    Data = null
                };
            }
            else
            {
                response = new Response<IQueryable<Customer>>()
                {
                    Status = new Status
                    {
                        Success = true,
                        Message = "Customer details retrieved successfully"
                    },
                    Data = data
                };
            }
            return response;
        }

        public async Task<Response<Customer>> GetCustomerById(int id)
        {
            Response<Customer> response = null;

            if (id == 0)
            {
                response = new Response<Customer>
                {
                    Status = new Status
                    {
                        Success = false,
                        Message = "Customer Id can not be empty"
                    },
                    Data = null
                };
                return response;
            }

            var result = await _repo.GetById(id);
            if (result == null)
            {
                response = new Response<Customer>
                {
                    Status = new Status
                    {
                        Success = false,
                        Message = "Customer record not found for the given id"
                    },
                    Data = null
                };

                return response;
            }

            response = new Response<Customer>
            {
                Status = new Status
                {
                    Success = true,
                    Message = "Customer detail retrieved successfully"
                },
                Data = result
            };

            return response;
        }

        public async Task<Response<Customer>> UpdateCustomer(Customer customer)
        {
            Response<Customer> response = null;

            if (customer == null)
            {
                response = new Response<Customer>
                {
                    Status = new Status
                    {
                        Success = false,
                        Message = "Entity can not be empty"
                    },
                    Data = null
                };
                return response;
            }

            var isUpdated = await _repo.Update(customer);

            if (!isUpdated)
            {
                response = new Response<Customer>
                {
                    Status = new Status
                    {
                        Success = false,
                        Message = "Details not to be updated please try again"
                    },
                    Data = null
                };
                return response;
            }

            response = new Response<Customer>
            {
                Status = new Status
                {
                    Success = true,
                    Message = "Details updated successfully"
                },
                Data = customer
            };
            return response;
        }
    }
}
