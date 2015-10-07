using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MongoMgr
{
    /// <summary>
    /// ModifyLogin.xaml 的交互逻辑
    /// </summary>
    public partial class ModifyLogin : Window
    {
        public ModifyLogin(string servername)
        {
            InitializeComponent();
            name = servername;
            
            
        }

        string name = "";
        string ip = "";
        string port = "";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MongoXML mongoxml = new MongoXML();
            if(name!="")
            {
                 name = this.modservername.Text;
                 ip = this.modip.Text;
                 port = this.modport.Text;


                try
                {
                    mongoxml.loaddoc("./config/config.xml");
                    mongoxml.ModifyNode(name, ip, port);
                    //MessageBox.Show("添加成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.modservername.Text = name;
            this.modip.Text = ip;
            this.modport.Text = port;
        }
    }
}
