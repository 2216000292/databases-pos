using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databases_pos_vs.Common
{
    public class ProductsDB
    {
        public static List<Models.Products> GetList(string where)
        {
            List<Models.Products> list = new List<Models.Products>();
            MySqlDataReader row = DBContext.ExecuteReader("select * from Products where 1=1 " + where);
            if (row != null)
            {
                while (row.Read())
                {
                    Models.Products product = new Models.Products();
                    if (Utils.IsInt(row["product_id"]))
                    {
                        product.product_id = int.Parse(row["product_id"].ToString());
                    }
                    if (Utils.IsInt(row["size"]))
                    {
                        product.size = int.Parse(row["size"].ToString());
                    }
                    if (Utils.IsDecimal(row["price"]))
                    {
                        product.price = decimal.Parse(row["price"].ToString());
                    }
                    if (row["name"] != null)
                    {
                        product.name = row["name"].ToString();
                    }
                    if (Utils.IsDecimal(row["category_id"]))
                    {
                        product.category_id = int.Parse(row["category_id"].ToString());
                    }
                    if (Utils.IsDecimal(row["vendor_id"]))
                    {
                        product.vendor_id = int.Parse(row["vendor_id"].ToString());
                    }
                    list.Add(product);
                }
                row.Close();
                row.Dispose();
            }
            return list;
        }
        /*
        public static Models.Products GetModel(int id)
        {
            Models.Products product = new Models.Products();
            MySqlDataReader row = DBContext.ExecuteReader("select * from Products where product_id=" + id);
            if (row != null)
            {
                while (row.Read())
                {
                    if (Utils.IsInt(row["product_id"]))
                    {
                        product.product_id = int.Parse(row["product_id"].ToString());
                    }
                    if (Utils.IsInt(row["size"]))
                    {
                        product.size = int.Parse(row["size"].ToString());
                    }
                    if (Utils.IsDecimal(row["price"]))
                    {
                        product.price = decimal.Parse(row["price"].ToString());
                    }
                    if (row["name"] != null)
                    {
                        product.name = row["name"].ToString();
                    }
                    if (Utils.IsDecimal(row["category_id"]))
                    {
                        product.category_id = int.Parse(row["category_id"].ToString());
                    }
                    if (Utils.IsDecimal(row["vendor_id"]))
                    {
                        product.vendor_id = int.Parse(row["vendor_id"].ToString());
                    }
                }
                row.Close();
                row.Dispose();
            }
            return product;
        }
        public static int Add(Models.Products product)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Products(");
            strSql.Append("size,price,name,category_id,vendor_id)");
            strSql.AppendFormat(" values ({0},{1},'{2}',{3},{4})", product.size, product.price, product.name, product.category_id, product.vendor_id);
            return DBContext.ExecuteNonQuery(strSql.ToString());
        }
        public static int Edit(Models.Products product)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Products set ");
            strSql.AppendFormat("size={0},", product.size);
            strSql.AppendFormat("price={0},", product.price);
            strSql.AppendFormat("name='{0}',", product.name);
            strSql.AppendFormat("category_id={0},", product.category_id);
            strSql.AppendFormat("vendor_id={0}", product.vendor_id);
            strSql.AppendFormat(" where product_id={0}", product.product_id);
            return DBContext.ExecuteNonQuery(strSql.ToString());
        }
        */
    }
}
