using System;
using System.Collections.Generic;
using System.Linq;
using Fixus.Data.Repositories;
using Fixus.Service.Contract;
using Address = Fixus.Service.Contract.Address;
using Contractor = Fixus.Service.Contract.Contractor;

namespace Fixus.Service
{
    public class UserService : IUserService
    {
        public User GetUserByUsername(string username)
        {
            IUserRepository userRepository = new UserRepository();

            var user = userRepository.Get(username);

            return GetUser(user);
        }

        public User GetUserById(int id)
        {
            IUserRepository userRepository = new UserRepository();

            var user = userRepository.Get(id);

            return GetUser(user);
        }

        private User GetUser(Data.Entities.User user)
        {
            User result = null;

            if (user != null)
            {
                result = new User
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Password = user.Password
                };
            }

            return result;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var result = new List<User>();
            IUserRepository userRepository = new UserRepository();

            foreach (var user in userRepository.Get())
            {
                result.Add(new User
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Password = user.Password
                });
            }

            return result;
        }

        public User AddUser(string username, string password)
        {
            IUserRepository userRepository = new UserRepository();

            userRepository.Add(username, password);

            var user = userRepository.Get(username);

            return GetUser(user);
        }
    }

    public class ContractorService : IContractorService
    {
        public Contractor GetContractorByName(string name)
        {
            IContractorRepository contractorRepository = new ContractorRepository();

            var contractor = contractorRepository.Get(name);

            return GetContractor(contractor);
        }

        public Contractor GetContractorById(int id)
        {
            IContractorRepository contractorRepository = new ContractorRepository();

            var contractor = contractorRepository.Get(id);

            return GetContractor(contractor);
        }

        private Contractor GetContractor(Data.Entities.Contractor contractor)
        {
            Contractor result = null;

            if (contractor != null)
            {
                var address = contractor.Addresses
                    .FirstOrDefault(a => a.KindOfAddresses
                        .Any(k => k.Code == Data.Entities.KindOfAddressCode.Main)
                    );

                result = new Contractor
                {
                    ContractorId = contractor.ContractorId,
                    Name = contractor.Name,
                    Nip = contractor.Nip,
                    Email = contractor.Email,
                    PhoneNo = contractor.PhoneNo
                };

                if (address != null)
                {
                    result.MainAddress = new Contract.Address()
                    {
                        AddressId = address.AddressId,
                        City = address.City,
                        Street = address.Street,
                        BuildingNo = address.BuildingNo,
                        FlatNo = address.FlatNo,
                        PostalCode = address.PostalCode,
                        Post = address.Post,
                        Community = address.Community,
                        District = address.District,
                        Province = address.Province,
                        Country = address.Country
                    };
                }
            }

            return result;
        }

        public IEnumerable<Contractor> GetAllContractors()
        {
            var result = new List<Contractor>();
            IContractorRepository contractorRepository = new ContractorRepository();

            foreach (var contractor in contractorRepository.Get())
            {
                result.Add(new Contractor
                {
                    ContractorId = contractor.ContractorId,
                    Name = contractor.Name,
                    Nip = contractor.Nip,
                    Email = contractor.Email,
                    PhoneNo = contractor.PhoneNo
                });
            }

            return result;
        }

        public IEnumerable<Address> GetAllContractorAddresses(int id)
        {
            var result = new List<Address>();
            IContractorRepository contractorRepository = new ContractorRepository();

            foreach (var address in contractorRepository.GetAllAddresses(id))
            {
                result.Add(new Address
                {
                    AddressId = address.AddressId,
                    City = address.City,
                    Street = address.Street,
                    BuildingNo = address.BuildingNo,
                    FlatNo = address.FlatNo,
                    PostalCode = address.PostalCode,
                    Post = address.Post,
                    Community = address.Community,
                    District = address.District,
                    Province = address.Province,
                    Country = address.Country
                });
            }

            return result;
        }

        public Contractor AddContractor(string name, string nip, string phoneNo, string email, string city,
            string street, string buildingNo, string postalCode, string country)
        {
            IContractorRepository contractorRepository = new ContractorRepository();

            contractorRepository.Add(name, nip, phoneNo, email, city,
                street, buildingNo, postalCode, country);

            var contractor = contractorRepository.Get(name);

            return GetContractor(contractor);
        }
    }
}
