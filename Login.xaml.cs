using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace MongoMgr
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        struct serverinfo
        {
            public string servername;
            public string ip;
            public string port;
        }

        List<serverinfo> info = new List<serverinfo>();
        MongoXML mongoxml = new MongoXML();
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            loadlist();
        }

        void loadlist()
        {
            
            serverlist.Items.Clear();
            try
            {
                mongoxml.loaddoc("./config/config.xml");
                XmlNodeList servernodes = mongoxml.getnodes();

                int nodecout = servernodes.Count;
                for (int i = 0; i < nodecout; i++)
                {
                    serverinfo sinfo = new serverinfo();
                    sinfo.servername = servernodes.Item(i).Attributes["name"].Value;
                    sinfo.ip = servernodes.Item(i).Attributes["ip"].Value;
                    sinfo.port = servernodes.Item(i).Attributes["port"].Value;

                    info.Add(sinfo);
                }

                int servercout = info.Count;
                for (int i = 0; i < servercout; i++)
                {
                    serverlist.Items.Add(info[i].servername);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            if(this.serverlist.SelectedItem!=null)
            {
                int count = info.Count;
                for(int i=0;i<count;i++)
                {
                    if(info[i].servername==this.serverlist.SelectedItem.ToString())
                    {
                        HttpModuel http = new HttpModuel();
                        string url = "http://"+info[i].ip+":44444/Mongo/fsstat.php" ;
                        JArray result= http.getjson(url);
                        if(result!=null)
                        {
                            List<List<string>> allnames = new List<List<string>>();
                            List<List<string>> allvalues = new List<List<string>>();
                            for(int j=0;j<result.Count;j++)
                            {
                                List<string> name = new List<string>();
                                List<string> value = new List<string>();
                                JToken values = result[j];
                                
                                
                                foreach (JProperty jp in values)
                                {
                                    name.Add(jp.Name);
                                    value.Add(jp.Value.ToString());
                                }
                                allnames.Add(name);
                                allvalues.Add(value);
                                
                            }

                            MainWindow mainwindow = new MainWindow(allnames,allvalues, info[i].ip);
                            mainwindow.Show();
                            this.Close();
                        }
                    }
                }
            }
        }

        private void button2_Copy_Click(object sender, RoutedEventArgs e)
        {
            AddLogin addlog = new AddLogin();
            addlog.ShowDialog();
            loadlist();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if(this.serverlist.SelectedItem!=null)
            {
                mongoxml.DelNode(this.serverlist.SelectedItem.ToString());
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if(this.serverlist.SelectedItem!=null)
            {
                ModifyLogin mdlog = new ModifyLogin(this.serverlist.SelectedItem.ToString());
                mdlog.ShowDialog();
            }
            else
            { MessageBox.Show("请先选择一个服务器"); }
           
        }
    }
}
