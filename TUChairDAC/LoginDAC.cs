﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairVO;
using System.Data.SqlClient;

namespace TUChairDAC
{
    public class LoginDAC : ConnectionAccess
    {
        public CUserVO GetUserinfo(string userID)
        {
            try
            {
                SqlConnection strConn = new SqlConnection(this.ConnectionString);
               
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = strConn;
                    cmd.CommandText = @"select CUser_ID, c.AuthorGroup_ID,a.AuthorGroup_Name,CUser_Name, CUser_PWD,CUser_Mark from CUser C inner join AuthorGroup A On  c.AuthorGroup_ID=a.AuthorGroup_ID  where CUser_UseOrNot='Y' and CUser_ID =@userID ";
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<CUserVO> list = Helper.MeilingDataReaderMapToList<CUserVO>(reader);
                    cmd.Connection.Close();
                    if (list.Count == 0)
                        return null;
                    else
                        return list[0];
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public bool InsertMark(string marks, string UID)
        {
            try
            {
                SqlConnection strConn = new SqlConnection(this.ConnectionString);

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = strConn;
                    cmd.CommandText = @"update [dbo].[CUser] set [CUser_Mark]=@marks where [CUser_ID]= @UID";
               
                    cmd.Parameters.AddWithValue("@marks", marks);
                    cmd.Parameters.AddWithValue("@UID", UID==""?DBNull.Value: (Object)UID);
                    cmd.Connection.Open();
                    var rowsAffected = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception err)
            {
                _log.WriteError(err.Message, err);
                throw err;
            }
        }

        public List<AuthorVO> GetAuthorInfo(int authorGroup_ID)
        {
            try
            {
                SqlConnection strConn = new SqlConnection(this.ConnectionString);

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = strConn;
                    cmd.CommandText = @"select AuthorGroup_ID, Program_ID, Program_Name, Program_order, Module_ID, Module_Name, Module_order, Method_Search, Method_Save, Method_New, Method_Delete, Method_Excel from vm_AuthorbyAuthGroup where AuthorGroup_ID = @authorGroup_ID order by Module_order,[Program_order]";
                    cmd.Parameters.AddWithValue("@authorGroup_ID", authorGroup_ID);
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<AuthorVO> list = Helper.MeilingDataReaderMapToList<AuthorVO>(reader);
                    cmd.Connection.Close();
                    return list;
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
