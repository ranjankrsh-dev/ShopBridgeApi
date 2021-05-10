using ShopBridgeApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ShopBridgeApi.DbHelper
{
    public class ProductRepository
    {
        string constr = ConfigurationManager.ConnectionStrings["ProductCon"].ConnectionString;

        public List<Inventory> GetAllInventory()
        {
            List<Inventory> inventories = new List<Inventory>();
            Inventory resp = null;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.Sp_GetInventories"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                foreach (DataRow row in dt.Rows)
                                {
                                    resp = new Inventory();
                                    resp.ItemId = Convert.ToInt32(row["Id"].ToString());
                                    resp.ItemName = row["ItemName"].ToString();
                                    resp.ItemDescription = row["ItemDescription"].ToString();
                                    resp.ItemPrice = Convert.ToDouble(row["ItemPrice"].ToString());
                                    resp.ItemCategory = row["ItemCategory"].ToString();
                                    resp.ImageFileName = row["ImageFileName"].ToString();
                                    resp.ImageFileExtension = row["ImageFileExtension"].ToString();
                                    resp.ImageFilePath = row["ImageFilePath"].ToString();
                                    resp.IsItemInStock = Convert.ToBoolean(row["IsItemInStock"].ToString());
                                    resp.CreatedBy = row["CreatedBy"].ToString();
                                    resp.CreatedOn = row["CreatedOn"].ToString();
                                    inventories.Add(resp);
                                }
                            }
                        }
                    }
                }
            }
            return inventories;
        }

        public Response AddNewInventory(Inventory inventory)
        {
            Response resp = null;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.Sp_AddNewInventory"))
                {
                    cmd.Parameters.AddWithValue("@ItemName", inventory.ItemName);
                    cmd.Parameters.AddWithValue("@ItemDescription", inventory.ItemDescription);
                    cmd.Parameters.AddWithValue("@ItemPrice", inventory.ItemPrice);
                    cmd.Parameters.AddWithValue("@ItemCategory", inventory.ItemCategory);
                    cmd.Parameters.AddWithValue("@ImageFileName", inventory.ImageFileName);
                    cmd.Parameters.AddWithValue("@ImageFileExtension", inventory.ImageFileExtension);
                    cmd.Parameters.AddWithValue("@ImageFilePath", inventory.ImageFilePath);
                    cmd.Parameters.AddWithValue("@ImageFileSize", inventory.ImageFileSize);
                    cmd.Parameters.AddWithValue("@CreatedBy", inventory.CreatedBy);
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                foreach (DataRow row in dt.Rows)
                                {
                                    resp = new Response();
                                    resp.IsValid = Convert.ToBoolean(row["IsValid"].ToString());
                                    resp.Message = row["Message"].ToString();
                                }
                            }
                        }
                    }
                }
            }
            return resp;
        }

        public Response UpdateInventory(Inventory inventory)
        {
            Response resp = null;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.Sp_UpdateItemInfos"))
                {
                    cmd.Parameters.AddWithValue("@ItemId", inventory.ItemId);
                    cmd.Parameters.AddWithValue("@ItemName", inventory.ItemName);
                    cmd.Parameters.AddWithValue("@ItemDescription", inventory.ItemDescription);
                    cmd.Parameters.AddWithValue("@ItemPrice", inventory.ItemPrice);
                    cmd.Parameters.AddWithValue("@ItemCategory", inventory.ItemCategory);
                    cmd.Parameters.AddWithValue("@CreatedBy", inventory.CreatedBy);
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                foreach (DataRow row in dt.Rows)
                                {
                                    resp = new Response();
                                    resp.IsValid = Convert.ToBoolean(row["IsValid"].ToString());
                                    resp.Message = row["Message"].ToString();
                                }
                            }
                        }
                    }
                }
            }
            return resp;
        }

        public Response DeleteInventory(Inventory inventory)
        {
            Response resp = null;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.Sp_DeletItemFromInventories"))
                {
                    cmd.Parameters.AddWithValue("@ItemId", inventory.ItemId);
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                foreach (DataRow row in dt.Rows)
                                {
                                    resp = new Response();
                                    resp.IsValid = Convert.ToBoolean(row["IsValid"].ToString());
                                    resp.Message = row["Message"].ToString();
                                }
                            }
                        }
                    }
                }
            }
            return resp;
        }
    }
}