using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PenScan.Services
{
    public interface IDatabase
    {
        SQLiteAsyncConnection GetConnection();
    }
}
