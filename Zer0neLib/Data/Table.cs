using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zer0ne.Data.Interface;

namespace Zer0ne.Data
{
    public class Table<T> where T : class //, IEntityBase
    {
        private readonly DbContext context;
        private DbSet<T> table = null;
        private string TableName;

        public Table()
        {
            context = ZDataHelper.DbContext;
            table = context.Set<T>();

            TableName = (context as IObjectContextAdapter).ObjectContext.CreateObjectSet<T>().EntitySet.Schema + "." +
            (context as IObjectContextAdapter).ObjectContext.CreateObjectSet<T>().EntitySet.Name;
        }

        private IEnumerable<T> GtByCondetion(string condition)
        {
            if (condition.ToLower().Contains(" where ") == false)
            {
                condition = " WHERE " + condition;
            }
            var qry = table.Sql + condition;
            var res = table.SqlQuery(qry).AsNoTracking().ToList();            
            return res;
        }

        public void Add(T data, bool IsNew = true)
        {
            if (IsNew)
            {
                table.Add(data);
            }
            else
            {
                var id = ZDataHelper.GtPropValue(data, "Id");
                var ex = table.Find(id);
                if (ex != null)
                {
                    context.Entry(ex).CurrentValues.SetValues(data);
                    context.Entry(ex).State = EntityState.Modified;
                }
            }
        }

        public void InsertRang(IEnumerable<T> dataList)
        {
            table.AddRange(dataList);
        }

        public void InsertAndSave(T data)
        {
            table.Add(data);
            Save();
        }

        public List<T> GtAll()
        {
            return table.AsNoTracking().ToList();
        }

        public List<T> GtAll(string cond)
        {
            return GtByCondetion(cond).ToList();
        }
          
        public async Task<List<T>> GtAllAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                return GtAll().ToList();
            });
        }

        public async Task<List<T>> GtAllAsync(string cond)
        {
            return await Task.Factory.StartNew(() =>
            {
                return GtByCondetion(cond).ToList();
            });
        }

        public T GtLastEntry()
        {
            return GtAll().Last();
        }

        public T GtByID(object id)
        {
            int i = 0;
            if (int.TryParse(id.ToString(), out i))
            {
                return table.Find(i);
            }
            else
            {
                return null;
            }
        }

        public void Delete(object Id)
        {
            T existing = GtByID(Id);
            if (existing != null)
            {
                table.Remove(existing);
            }
        }

        public void DeleteAll(string condition)
        {
            //var tbl = context.Set<T>();

            var lst = GtByCondetion(condition)?.ToList(); 
            if (lst != null)
            {
                for (int i = 0; i < lst.Count; i++)
                {
                    var id = ZDataHelper.GtPropValue(lst[i], "Id");
                    
                    Delete(id);
                }
            } 
        }
          
        public bool Save()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
         
        public void InsertMassiveData(Dictionary<string, System.Data.DataTable> detaList)
        {
            //insert to db
            using (var connection = new System.Data.SqlClient.SqlConnection(context.Database.Connection.ConnectionString))
            {
                connection.Open();
                using (System.Data.SqlClient.SqlTransaction transaction = connection.BeginTransaction())
                {
                    using (System.Data.SqlClient.SqlBulkCopy bulkCopy = new System.Data.SqlClient.SqlBulkCopy(connection, System.Data.SqlClient.SqlBulkCopyOptions.Default, transaction))
                    {
                        try
                        {
                            foreach (var tbl in detaList)
                            {
                                bulkCopy.DestinationTableName = tbl.Key;
                                bulkCopy.WriteToServer(tbl.Value);
                                transaction.Commit();
                            }
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            connection.Close();
                            throw;
                        }
                    }
                }
            }
        }

    }
}
