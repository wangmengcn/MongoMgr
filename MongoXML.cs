using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml;

namespace MongoMgr
{
    class MongoXML
    {
        XmlDocument xmldoc = new XmlDocument();
        public void loaddoc(string xmlpath)
        {
            try
            {
                xmldoc.Load(xmlpath);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        public XmlNodeList getnodes()
        {
            XmlNodeList nodelist = xmldoc.SelectNodes("/MongoConf/ServerName");
            return nodelist;
        }

        public void  AddXMLNode(string name,string ip,string port)
        {
            
            XmlNode root= xmldoc.SelectSingleNode("MongoConf");
            if(root==null)
            {
                return;
            }
            else
            {
                if (chechnode(name))
                {
                    XmlElement newnode = xmldoc.CreateElement("ServerName");
                    newnode.SetAttribute("name", name);
                    newnode.SetAttribute("ip", ip);
                    newnode.SetAttribute("port", port);

                    root.AppendChild(newnode);
                    xmldoc.Save("./config/config.xml");
                    MessageBox.Show("添加成功");
                     
                }
                else
                    MessageBox.Show("节点已存在，请设置其他的名称！");
                
            }
        }


        public void DelNode(string name)
        {
            XmlNodeList childNodes = xmldoc.SelectNodes("/MongoConf/ServerName");

            XmlNode rootnode = xmldoc.SelectSingleNode("MongoConf");
            for (int i = 0; i < childNodes.Count;i++ )
            {
                XmlElement childElement = (XmlElement)childNodes[i];
                if (childElement.GetAttribute("name") == name)
                {

                    //childElement.RemoveAll();
                    rootnode.RemoveChild(childElement);
                    break;
                }
            }

            xmldoc.Save("./config/config.xml");  
        }

        public void ModifyNode(string name,string ip,string port)
        {
            XmlNodeList childNodes = xmldoc.SelectNodes("/MongoConf/ServerName");

            
            for (int i = 0; i < childNodes.Count; i++)
            {
                XmlElement childElement = (XmlElement)childNodes[i];
                if (childElement.GetAttribute("name") == name)
                {

                    //childElement.RemoveAll();
                    childElement.SetAttribute("ip", ip);
                    childElement.SetAttribute("port", port);
                    break;
                }
            }

            xmldoc.Save("./config/config.xml");  
        }


        bool chechnode(string servername)
        {
            XmlNodeList nodelist=getnodes();
            for(int i=0;i<nodelist.Count;i++)
            {
                string name = nodelist.Item(i).Attributes["name"].Value;
                if (servername == name)
                    return false;
            }

            return true;
        }
    }
}
