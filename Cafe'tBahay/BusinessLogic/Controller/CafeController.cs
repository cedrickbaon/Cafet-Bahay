using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Controller
{
    internal class CafeController
    {
        ICafeRepository cafeRepository;
        public CafeController(ICafeRepository repo)
        {
            cafeRepository = repo;
        }
        public void SaveUserRegistration(User user)
        {
            try
            {
                //add Validation
                if (user.username == string.Empty)
                {
                    throw new Exception("Username is Required");
                }
                //.....
                cafeRepository.SaveUserRegistration(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SaveSupplierRegistration(Supplier supplier)
        {
            try
            {
                //add Validation
                if (supplier.name == string.Empty)
                {
                    throw new Exception("Supplier Name is Required");
                }
                //.....
                cafeRepository.SaveSupplierRegistration(supplier);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SaveProductRegistration(Product product)
        {
            try
            {
                //add Validation
                if (product.name == string.Empty)
                {
                    throw new Exception("Product Name is Required");
                }
                //.....
                cafeRepository.SaveSupplierRegistration(product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateUserRegistration(UserStringHandle user)
        {
            try
            {
                //Dito ilalagay ang mga Validation
                if (user.username == string.Empty)
                {
                    throw new Exception("Username is Required");
                }
                //.....


                //kapag nakapasa sa validation, saka tawang ang method sa studentRepository
                cafeRepository.UpdateUserRegistration(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteUser(string id)
        {
            try
            {
                //Dito ilalagay ang mga Validation
                if (id == string.Empty)
                {
                    throw new Exception("Id is Required");
                }

                //kapag nakapasa sa validation, saka tawang ang method sa studentRepository
                cafeRepository.DeleteUser(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public User GetStudentById(string id)
        {
            try
            {
                //Dito ilalagay ang mga Validation
                if (id == string.Empty)
                {
                    throw new Exception("Id is Required");
                }

                //kapag nakapasa sa validation, saka tawang ang method sa studentRepository
                return cafeRepository.GetStudentById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ArrayList GetAllUsers()
        {
            try
            {
                return cafeRepository.GetAllUsers();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ArrayList GetAllPrograms()
        {
            try
            {
                return cafeRepository.GetAllPrograms();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GenerateNewStudentId()
        {
            try
            {
                return cafeRepository.GenerateNewStudentId(); //in progress
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
