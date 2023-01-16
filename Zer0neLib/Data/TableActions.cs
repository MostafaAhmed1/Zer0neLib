using System;
using System.Data;
using System.Collections.Generic;

namespace Zer0ne.Data
{
    public class TableActions //<T> where T : class
    {
        public string TableName { get; set; }
        private DatabaseController Controller;
        private DataTable Table;

        public TableActions(string tblName )
        {
            TableName = tblName;
            Controller = ZDataHelper.DbController;

            switch (Controller.DbType)
            {
                case ConnectionType.sqlServer:
                case ConnectionType.access:
                    Table = Controller.Read("SELECT * FROM [" + TableName.Replace(".", "].[") + "] WHERE 5 < 1 ");
                    DataColumn isNew = new DataColumn("isNew", typeof(bool));
                    Table.Columns.Add(isNew);
                    break;
                case ConnectionType.mySql:
                    break;
                default:
                    break;
            }
        }

        public TableActions(string tblName, DatabaseController controller)
        {
            TableName = tblName;
            Controller = controller;

            switch (Controller.DbType)
            {
                case ConnectionType.sqlServer:
                case ConnectionType.access:
                    Table = Controller.Read("SELECT * FROM [" + TableName.Replace(".", "].[") + "] WHERE 5 < 1 ");
                    DataColumn isNew = new DataColumn("isNew", typeof(bool));
                    Table.Columns.Add(isNew);
                    break;
                case ConnectionType.mySql:
                    break;
                default:
                    break;
            }
        }

        public DataRow GtNewDataRow()
        {
            return Table.NewRow();
        }

        public void AddRow<T>(T obj, bool isNew = true) where T : class
        {
            var pList = obj.GetType().GetProperties();
            var rw = Table.NewRow();
            for (int p = 0; p < pList.Length; p++)
            {
                rw[pList[p].Name] = pList[p].GetValue(obj);
            }
            rw["isNew"] = isNew;
            Table.Rows.Add(rw);
        }

        public void AddRow(DataRow rw)
        {
            Table.Rows.Add(rw);
        }

        public DataTable FreeQuery(string query)
        {
            return Controller.Read(query);
        }

        public List<T> FreeQuery<T>(string query) where T : class
        {
            var lst = Controller.Read(query);
            return ZDataHelper.TableToList2<T>(lst);
        }

        public DataTable SelectAll()
        { 
            return Controller.Read("SELECT * FROM [" + TableName.Replace(".", "].[") + "]");
        }

        public List<T> SelectAll<T>() where T : class
        {
            var lst = SelectAll();
            return ZDataHelper.TableToList2<T>(lst);
        }

        public DataTable SelectAll(string Condition = "")
        {
            if (string.IsNullOrWhiteSpace(Condition) == false && Condition.ToLower().Contains("where ") == false)
            {
                Condition = " WHERE " + Condition;
            }
            else
            {
                Condition = " " + Condition;
            }
            return Controller.Read("SELECT * FROM [" + TableName.Replace(".", "].[") + "]" + Condition);
        }

        public List<T> SelectAll<T>(string Condition = "") where T : class
        { 
            var lst = SelectAll(Condition);
            return ZDataHelper.TableToList2<T>(lst);
        }

        private bool Insert(DataRow rw)
        {
            string query = "";
            string DeclarePart, AssignPart;

            switch (Controller.DbType)
            {
                case ConnectionType.sqlServer:
                                         
                    DeclarePart = $"INSERT INTO [{ TableName.Replace(".", "].[") }] (";
                    AssignPart = $" Values (";
                    for (int i = 0; i < Table.Columns.Count; i++)
                    {
                        if (Table.Columns[i].ColumnName.ToLower() == "isnew")
                        {
                            continue;
                        }
                        if (Table.Columns[i].ColumnName.ToLower() == "id" && Table.Columns[i].DataType == typeof(int))
                        {
                            continue;
                        }
                        DeclarePart += "[" + Table.Columns[i].ColumnName + "], ";
                        AssignPart += "@" + Table.Columns[i].ColumnName + ", ";
                        Controller.AddParametersValue("@" + Table.Columns[i].ColumnName, rw[Table.Columns[i].ColumnName]);
                    }

                    DeclarePart = DeclarePart.Substring(0, DeclarePart.Length - 2) + ") ";
                    AssignPart = AssignPart.Substring(0, AssignPart.Length - 2) + ")";

                    query = DeclarePart + AssignPart;

                    return Controller.Execute(query);

                case ConnectionType.access:
                    
                    DeclarePart = $"INSERT INTO [{ TableName }] (";
                    AssignPart = $" Values (";
                    for (int i = 0; i < Table.Columns.Count; i++)
                    {
                        if (Table.Columns[i].ColumnName.ToLower() == "isnew")
                        {
                            continue;
                        }
                        if (Table.Columns[i].ColumnName.ToLower() == "id" && Table.Columns[i].DataType == typeof(int))
                        {
                            continue;
                        }
                        DeclarePart += "[" + Table.Columns[i].ColumnName + "], ";
                        AssignPart += "@" + Table.Columns[i].ColumnName + ", ";
                        Controller.AddParametersValue("@" + Table.Columns[i].ColumnName, rw[Table.Columns[i].ColumnName]);
                    }

                    DeclarePart = DeclarePart.Substring(0, DeclarePart.Length - 2) + ") ";
                    AssignPart = AssignPart.Substring(0, AssignPart.Length - 2) + ");";

                    query = DeclarePart + AssignPart;

                    return Controller.Execute(query);

                case ConnectionType.mySql:
                    return false;
                default:
                    return false;
            }
        }

        private bool Update(DataRow rw)
        {
            string query = "";
            string whr = "";

            switch (Controller.DbType)
            {
                case ConnectionType.sqlServer:

                    query = "UPDATE [" + TableName.Replace(".", "].[") + "] SET ";
                    whr = " WHERE [id] = ";

                    for (int i = 0; i < Table.Columns.Count; i++)
                    {
                        if (Table.Columns[i].ColumnName.ToLower() == "id" && Table.Columns[i].DataType == typeof(int))
                        {
                            whr += rw[Table.Columns[i].ColumnName].ToString() + ";";
                            continue;
                        }
                        else if (Table.Columns[i].ColumnName.ToLower() == "id" && Table.Columns[i].DataType == typeof(Guid))
                        {
                            whr += "@" + Table.Columns[i].ColumnName;
                            goto skp;
                        }
                        else if (Table.Columns[i].ColumnName.ToLower() == "isnew")
                        {
                            continue;
                        }
                        query += "[" + Table.Columns[i].ColumnName + "] = ";
                        query += "@" + Table.Columns[i].ColumnName + ", ";
                        skp:;
                        Controller.AddParametersValue("@" + Table.Columns[i].ColumnName.ToLower(), rw[Table.Columns[i].ColumnName]);
                    }
                    query = query.Substring(0, query.Length - 2);
                    query += whr;
                    return Controller.Execute(query);

                case ConnectionType.access:

                    query = "UPDATE [" + TableName + "] SET ";
                    whr = " WHERE [id] = ";

                    for (int i = 0; i < Table.Columns.Count; i++)
                    {
                        if (Table.Columns[i].ColumnName.ToLower() == "id" && Table.Columns[i].DataType == typeof(int))
                        {
                            whr += rw[Table.Columns[i].ColumnName].ToString() + ";";
                            continue;
                        }
                        query += "[" + Table.Columns[i].ColumnName + "] = ";
                        query += "@" + Table.Columns[i].ColumnName + ", ";
                        Controller.AddParametersValue("@" + Table.Columns[i].ColumnName, rw[Table.Columns[i].ColumnName]);
                    }
                    query = query.Substring(0, query.Length - 2);
                    query += whr;
                    return Controller.Execute(query);

                case ConnectionType.mySql:
                    return false;
                default:
                    return false;
            }
        }

        public bool DeleteRow(int id)
        {
            string qry = "";
            switch (Controller.DbType)
            {
                case ConnectionType.sqlServer:
                    qry = "DELETE [" + TableName.Replace(".", "].[") + "] WHERE [Id]=" + id.ToString();
                    break;
                case ConnectionType.access:
                    qry = "DELETE FROM [" + TableName + "] WHERE [Id]=" + id.ToString();
                    break;
                case ConnectionType.mySql:
                    break;
                default:
                    break;
            }
            return Controller.Execute(qry);
        }

        public bool DeleteRow(string colName, object val)
        {
            string qry = "";
            switch (Controller.DbType)
            {
                case ConnectionType.sqlServer:
                    qry = "DELETE [" + TableName.Replace(".", "].[") + "] WHERE [" + colName + "] = " + val.ToString();
                    break;
                case ConnectionType.access:
                    qry = "DELETE FROM [" + TableName + "] WHERE [" + colName + "] = " + val.ToString();
                    break;
                case ConnectionType.mySql:
                    break;
                default:
                    break;
            }
            return Controller.Execute(qry);
        }

        public bool Save()
        {
            bool success = false;
            for (int i = 0; i < Table.Rows.Count; i++)
            {
                if (Table.Rows[i]["isNew"] != DBNull.Value && Convert.ToBoolean(Table.Rows[i]["isNew"]) == false)
                {
                    success = Update(Table.Rows[i]);
                }
                else
                {
                    success = Insert(Table.Rows[i]);
                }
            }
            Clear();
            return success;
        }
        
        public void Clear()
        {
            Table.Clear();
        }

        public DataRow GtLastEntry()
        {
            var tbl = Controller.Read("SELECT TOP 1 * FROM [" + TableName.Replace(".", "].[") + "] ORDER BY id DESC");
            if (tbl.Rows.Count > 0)
            {
                return tbl.Rows[0];
            }
            else
            {
                return null;
            }
        }

        public object GtLastEntry<T>() where T : class
        {
            var tbl = Controller.Read("SELECT TOP 1 * FROM [" + TableName.Replace(".", "].[") + "] ORDER BY id DESC");
            var lst = ZDataHelper.TableToList<T>(tbl);
            if (lst.Count > 0)
            {
                return lst[0];
            }
            else
            {
                return null;
            }
        }

        public object GtMaxValue(string colName = "id")
        {
            var tbl = Controller.Read("SELECT MAX([" + colName + "]) FROM [" + TableName.Replace(".", "].[") + "]");
            if (tbl.Rows.Count > 0)
            {
                if (tbl.Rows[0][0] != null && tbl.Rows[0][0] != DBNull.Value)
                {
                    return tbl.Rows[0][0];
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        } 

        public object GtMinValue(string colName = "id")
        {
            var tbl = Controller.Read("SELECT MIN([" + colName + "]) FROM [" + TableName.Replace(".", "].[") + "]");
            if (tbl.Rows.Count > 0)
            {
                if (tbl.Rows[0][0] != null && tbl.Rows[0][0] != DBNull.Value)
                {
                    return tbl.Rows[0][0];
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
