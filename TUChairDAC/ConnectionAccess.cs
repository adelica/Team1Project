using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TUChairDAC
{
   public class ConnectionAccess
    {
        protected string ConnectionString
        {
            get
            {
                string connStr = string.Empty;
                XmlDocument configXml = new XmlDocument();
                configXml.Load(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/XMLFile1.xml");
                //Assembly.GetExecutingAssembly().Location 디렉토리 정보까지 가져옴
                XmlNodeList addNodes = configXml.SelectNodes("configuration/settings/add");
                foreach (XmlNode xmlNode in addNodes)
                {
                    if (xmlNode.Attributes["key"].InnerText == "MyDB")
                    {
                        connStr = ((XmlCDataSection)xmlNode.ChildNodes[0]).InnerText;
                        break;
                    }
                }
                Amhuhua.Amhuhua amhuhua = new Amhuhua.Amhuhua();
                
                return amhuhua.Decrypt(connStr);

            }
        }
    }
}
