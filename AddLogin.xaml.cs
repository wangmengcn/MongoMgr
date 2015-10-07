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
    /// AddLogin.xaml 的交互逻辑
    /// </summary>
    public partial class AddLogin : Window
    {
        public AddLogin()
        {
            InitializeComponent();
        }
        MongoXML mongoxml = new MongoXML();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = this.servername.Text;
            string serverip = this.ip.Text;
            string serverport = this.port.Text;


            try
            {
                mongoxml.loaddoc("./config/config.xml");
                mongoxml.AddXMLNode(name, serverip, serverport);
                //MessageBox.Show("添加成功");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
