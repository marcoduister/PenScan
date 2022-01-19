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
