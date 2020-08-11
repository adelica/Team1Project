using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUChairVO
{
   public  class UserVO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
       
    }
    public class TestVO
    {
         public string  a { get; set; }
        public string  b { get; set; }
        public string  c { get; set; }
        public string  d { get; set; }
        public string e { get; set; }
        public string f { get; set; }
        public string g { get; set; }
        public string h { get; set; }
        public string i { get; set; }
        public string j { get; set; }
        public string k { get; set; }
    }
    public class CUserVO
    {
        public string CUser_ID           { get; set; }
        public int    AuthorGroup_ID     { get; set; }
        public string AuthorGroup_Name   { get; set; }
        public string  CUser_Name        { get; set; }
        public string  CUser_PWD         { get; set; }
        public bool CUser_UseOrNot       { get; set; }
        public string CUser_Mark         { get; set; }
    }   
}
