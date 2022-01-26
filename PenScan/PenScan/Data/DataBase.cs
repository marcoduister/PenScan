using PenScan.Models;
using PenScan.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
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
            _sqlconnection.CreateTableAsync<ScanItem>();
            _sqlconnection.CreateTableAsync<Models.File>();
        }

        #region FileManagment

        public ObservableCollection<File> GetAllThreatModelingFiles(int ProjectId, int projectfaseId)
        {
            var list = new List<File>();

            try
            {
                list = _sqlconnection.Table<File>().Where(x => x.ProjectId == ProjectId && x.projectfaseId == projectfaseId).ToListAsync().Result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return new ObservableCollection<File>(list);
        }

        public ObservableCollection<File> GetAllExploitationFiles(int ProjectId, int projectfaseId)
        {
            var list = new List<File>();

            try
            {
                list = _sqlconnection.Table<File>().Where(x => x.ProjectId == ProjectId && x.projectfaseId == projectfaseId).ToListAsync().Result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return new ObservableCollection<File>(list);
        }
        public ObservableCollection<File> GetAllPostExploitationFiles(int ProjectId, int projectfaseId)
        {
            var list = new List<File>();
            
            try
            {
                list = _sqlconnection.Table<File>().Where(x=>x.ProjectId == ProjectId && x.projectfaseId == projectfaseId).ToListAsync().Result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return new ObservableCollection<File>(list); 
        }




        public Task<int> AddThreatModelingFiles(ObservableCollection<File> fileList)
        {
            try
            {
                returns = _sqlconnection.InsertAllAsync(fileList);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return returns;
        }
        public Task<int> AddExploitationFiles(ObservableCollection<File> fileList)
        {
            try
            {
                returns = _sqlconnection.InsertAllAsync(fileList);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return returns;
        }
        public Task<int> AddPostExploitationFiles(ObservableCollection<File> fileList)
        {
            try
            {
                returns = _sqlconnection.InsertAllAsync(fileList);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return returns;
        }

        #endregion

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
            try
            {
                return _sqlconnection.Table<Contract>().FirstAsync(e => e.ProjectId == ProjectId).Result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
            
        }


        public Task<int> InsertContract(Contract contract)
        {
            try
            {
                returns = _sqlconnection.InsertAsync(contract);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
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
                Debug.WriteLine(ex);
            }
            return list;
        }

        public Task<int> InsertScanitemsAsync(ObservableCollection<ScanItem> scanItems)
        {
            try
            {
                
                foreach (var item in scanItems.ToList())
                {
                    returns = _sqlconnection.InsertAsync(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
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
                Debug.WriteLine(ex);
            }
            return list;
        }
        public Project GetProjectbyIdAsync(int Id)
        {
            try
            {
                return _sqlconnection.Table<Project>().FirstAsync(e => e.Id == Id).Result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
            
        }



        public Task<int> InsertProjectAsync(Project project)
        {
            try
            {
                returns = _sqlconnection.InsertAsync(project);
            }
            catch (Exception ex )
            {
                Debug.WriteLine(ex);
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
                Debug.WriteLine(ex);
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
                Debug.WriteLine(ex);
                return null;
            }
        }

        #endregion

    }

}
