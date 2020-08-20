using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUChairVO
{
    public class AuthorVO
    {
        public string Program_ID        { get; set; }
        public string Program_Name      { get; set; }
        public int    Program_order     { get; set; }
        public int    Module_order { get; set; }
        public int    Module_ID          { get; set; }
        public string Module_Name       { get; set; }
        public string  Method_Search     { get; set; }
        public string  Method_New        { get; set; }
        public string  Method_Save          { get; set; }
        public string  Method_Delete    { get; set; }
        public string Method_Excel       { get; set; }
    }
    public class AuthorBooltypeVO
    {
        public string Program_ID         { get; set; }
        public string Program_Name       { get; set; }
        public int    Program_order     { get; set; }
        public int    Module_ID         { get; set; }
        public string   Module_Name       { get; set; }
        public bool   Method_Search     { get; set; }
        public bool Method_New { get; set; }
        public bool   Method_Save    { get; set; }
        public bool   Method_Delete     { get; set; }
        public bool   Method_Excel      { get; set; }
    }
    public class ProgramVO
    {
        public string Module_Name            { get; set; }
        public int       Module_ID              { get; set; }
        public string Program_ID             { get; set; }
        public string Program_Name           { get; set; }
        public string Program_Explanation    { get; set; }
        public int Program_order          { get; set; }
    } 
}     
      
      
      
      