using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TUChairDAC
{
   public static  class Helper
    {
        public static List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            try
            {
                List<T> list = new List<T>();
                T obj = default(T);
                while (dr.Read())
                {
                    obj = Activator.CreateInstance<T>();
                    foreach (PropertyInfo prop in obj.GetType().GetProperties())
                    {
                        if (!object.Equals(dr[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(obj, dr[prop.Name], null);
                        }
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception err)
            {
                string msg = err.Message;

                return null;
            }
        }
        // list를 데이타 테이블로
        public static DataTable ConvertToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }

            return table;
        }
        public static List<T> MeilingDataReaderMapToList<T>(IDataReader dr)
        {
            try
            {
                List<T> list = new List<T>();
                T obj = default(T);
                while (dr.Read())
                {
                    obj = Activator.CreateInstance<T>();
                    DataTable dt = dr.GetSchemaTable();

                    foreach (PropertyInfo prop in obj.GetType().GetProperties())
                    {
                        if (IsUseName(dt, prop.Name) && !object.Equals(dr[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(obj, dr[prop.Name], null);
                        }
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        /// <summary>
        /// 읽어 온 데이터에 있는 컬럼인지 확인 하는 메서드
        /// </summary>
        /// <param name="dt">스키마 데이터테이블</param>
        /// <param name="name">VO프로퍼티 이름</param>
        /// <returns></returns>
        private static bool IsUseName(DataTable dt, string name)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["ColumnName"].ToString().ToUpper() == name.ToUpper())
                    return true;
            }

            return false;
        }

        public static List<T> ConvertDataTableToList<T>(DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();
                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch (Exception err)
                        {
                            string msg = err.Message;
                        }
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch
            {
                return null;
            }
        }
    }
}
