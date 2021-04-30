using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DBTest
{
    public class OrmUtil<T>
    {
        /// <summary>
        /// T的类型实例
        /// </summary>
        private Type dType;
        /// <summary>
        /// T的属性表
        /// </summary>
        private PropertyInfo[] properties;
        public OrmUtil()
        {
            dType = typeof(T);
            properties = dType.GetProperties();
        }

        public SqlConnection Connection { get; set; }

        /// <summary>
        /// 检查连接是否可用
        /// </summary>
        /// <returns></returns>
        private bool CheckConnection()
        {
            return Connection?.State == ConnectionState.Open;
        }

        public int Insert(T entity)
        {
            if (!CheckConnection()) return -1;// 检查状态
            var insert = $"insert into {dType.Name}({string.Join(",", properties.Select(t => t.Name))})";
            var values = properties.Select(p => p.GetValue(entity));
            var commandText = $"{insert} values('{string.Join("','", values)}')";

            var command = Connection.CreateCommand();
            command.CommandText = commandText;
            var result = command.ExecuteNonQuery();
            return result;
        }

        public int Update(T entity, string keyName, object keyValue)
        {
            if (!CheckConnection()) return -1;
            var setValues = properties.ToDictionary(p => p.Name, p => $"'{p.GetValue(entity)}'");
            var setSql = string.Join(",", setValues.Select(pair => $"{pair.Key}='{pair.Value}'"));
            var sql = $"update {dType.Name} set {setSql} where {keyName} = '{keyValue}'";
            var command = Connection.CreateCommand();
            command.CommandText = sql;
            return command.ExecuteNonQuery();
        }

        public int Delete(T entity)
        {
            if (!CheckConnection()) return -1;
            var querySet = properties.Select(p => $"{p.Name} = '{p.GetValue(entity)}'");
            var sql = $"delete from {dType.Name} where {string.Join(" and ", querySet)}";
            var command = Connection.CreateCommand();
            command.CommandText = sql;
            return command.ExecuteNonQuery();
        }

        private List<T> Convert(DataTable table)
        {
            var list = new List<T>(table.Rows.Count);//事先声明一下容量
            foreach (DataRow row in table.Rows)
            {
                T entity = Activator.CreateInstance<T>();
                foreach (var p in properties)
                {
                    if (!table.Columns.Contains(p.Name)) continue;// 如果属性名不在表格中，则忽略
                    p.SetValue(entity, row[p.Name]);
                }
                list.Add(entity);
            }
            return list;
        }

        public List<T> SearchAll()
        {
            var adapter = new SqlDataAdapter($"select * from {dType.Name}", Connection);
            var set = new DataSet();
            adapter.Fill(set);
            return Convert(set.Tables[0]);
        }
    }
}
