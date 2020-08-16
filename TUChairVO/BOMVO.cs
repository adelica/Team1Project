using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUChairVO
{
   public class BOMVO
    {
           public string        INFO                         {get; set;}
           public string        Item_Code                   { get; set; }
        public string           Item_Type                   {get; set;}
           public int           BOM_No                     {get; set;}
           public string        ItemCode                { get; set;}
           public string        ParentItem_Code             {get; set;}
           public int           BOM_Require                 {get; set;}
           public int           Lvl                        {get; set;}
           public DateTime      BOM_StartDate              {get; set;}
           public DateTime      BOM_EndDate                 {get; set;}
           public string        BOM_UserOrNot               {get; set;}
           public string        BOM_Modifier                {get; set;}
           public DateTime      BOM_ModifiyDate             {get; set;}
           public string        BOM_AutoDeducion           {get; set;}
           public string        BOM_RequirePlan             {get; set;}
           public string        BOM_Others                 { get; set; }
    }
}
