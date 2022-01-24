using PenScan.Models;
using PenScan.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PenScan.Data
{
    public class DataBase
    {
        SQLiteAsyncConnection _sqlconnection;
        private Task<int> returns;

        public DataBase()
        {
            _sqlconnection = DependencyService.Get<IDatabase>().GetConnection();
            _sqlconnection.CreateTableAsync<User>();
            _sqlconnection.CreateTableAsync<Contract>();
            _sqlconnection.CreateTableAsync<Project>();
        }


        #region Access

        public async Task<Boolean> EmailExistAsync(string Email)
        {
            User ExistingUser = _sqlconnection.Table<User>().FirstOrDefaultAsync(e => e.Email == Email).Result;
            if (ExistingUser == null)
            {
                return true;
                
            }
            else
            {
                return false;
            }

        }
        public Task<int> InsertUserAsync(User user)
        {
            return _sqlconnection.InsertAsync(user);
        }
        public async Task<User> validateUserAsync(string Email, string Password)
        {

            try
            {
                string salt = _sqlconnection.Table<User>().FirstAsync(e => e.Email == Email).Result.Salt;
                string pwdHashed = SecurityHelper.HashPassword(Password, salt, 10101, 70);

                return  _sqlconnection.Table<User>().FirstOrDefaultAsync(e => e.Email == Email && e.Password == pwdHashed).Result;
            }
            catch (Exception)
            {

                return null;
            }

        }


        #endregion

        #region Contract

        public Contract GetContractbyIdAsync(int ProjectId)
        {
            return _sqlconnection.Table<Contract>().FirstAsync(e => e.ProjectId == ProjectId).Result;
        }


        public Task<int> InsertContract(Contract contract)
        {
            try
            {
                returns = _sqlconnection.InsertAsync(contract);
            }
            catch (Exception ex)
            {

                throw;
            }
            return returns;
        }

        #endregion

        #region scan

        public List<ScanItem> GetAllscanitemsbyIdAsync(int Id)
        {
            var list = new List<ScanItem>();
            try
            {
                list = _sqlconnection.Table<ScanItem>().Where(x=>x.projectId == Id).ToListAsync().Result;
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public Task<int> InsertScanitemsAsync(ObservableCollection<ScanItem> scanItems)
        {
            try
            {
                returns = _sqlconnection.InsertAsync(scanItems);
            }
            catch (Exception ex)
            {

                throw;
            }
            return returns;
        }
        #endregion

        #region Project

        public List<Project> GetProjectAllAsync()
        {
            var list = new List<Project>();
            try
            {
                list = _sqlconnection.Table<Project>().ToListAsync().Result;
            }
            catch (Exception ex)
            {

                throw;
            }
            return list;
        }
        public Project GetProjectbyIdAsync(int Id)
        {
            return _sqlconnection.Table<Project>().FirstAsync(e => e.Id == Id).Result;
        }



        public Task<int> InsertProjectAsync(Project project)
        {
            try
            {
                returns = _sqlconnection.InsertAsync(project);
            }
            catch (Exception ex )
            {

                throw;
            }
            return returns;
        }

        public Task<int> UpdateProjectAsync(Project project)
        {
            try
            {
                returns = _sqlconnection.UpdateAsync(project);
            }
            catch (Exception ex)
            {

                throw;
            }
            return returns;
        }

        public Task<int> DeleteProjectbyIdAsync(int Id)
        {
            
            try
            {
                Project project = _sqlconnection.Table<Project>().FirstAsync(e => e.Id == Id).Result;
                if (project != null)
                {
                    return _sqlconnection.DeleteAsync(project);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex )
            {
                throw;
            }
        }

        #endregion

    }

}
