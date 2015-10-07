using DevExpress.Utils;
using DevExpress.Xpf.Grid;
using Newtonsoft.Json.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MongoMgr
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(List<List<string>> names, List<List<string>> values,string ip)
        {
            InitializeComponent();
            namelist = names;
            valuelist = values;
            targetip = ip;
        }

        List<List<string>> namelist;
        List<List<string>> valuelist;
        string targetip = string.Empty;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
                     

            

            for (int i = 0; i < valuelist.Count; i++)
            {




                mongodata mdata = new mongodata()
                {
                    GridFS名称 = valuelist[i][0],
                    数据库名 = valuelist[i][1],
                    建库时间 = valuelist[i][2],
                    入库时间 = valuelist[i][3],
                    数据类型 = valuelist[i][4],
                    Left = valuelist[i][5],
                    Top = valuelist[i][6],
                    Right = valuelist[i][7],
                    Bottom = valuelist[i][8],
                    最小层级 = valuelist[i][9],
                    最大层级 = valuelist[i][10],
                    描述 = valuelist[i][11]

                };


               
                
                TreeListNode node = new TreeListNode(mdata);
                
                
                this.treeview.Nodes.Add(node);



            }
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<mongodata> results = new List<mongodata>();
            foreach(TreeListNode node in this.treeview.Nodes)
            {
                if(node.IsChecked==true)
                {
                    mongodata checkdata = node.Content as mongodata;
                    results.Add(checkdata);
                }
            }

            if(results.Count!=0)
            {
                JObject jsonlist = new JObject();     //作为传入PHP的Json串
                for(int i=0;i<results.Count;i++)
                {                    
                    JObject resultjson = new JObject();
                    resultjson.Add(new JProperty("GridFS名称",results[i].GridFS名称));
                    resultjson.Add(new JProperty("数据库名", results[i].数据库名));
                    jsonlist.Add(new JProperty(i.ToString(), resultjson));

                    
                }

                //string url = "http://172.17.30.109:44444/Mongo/makeconf.php";
                string url = "http://"+targetip+":44444/Mongo/makeconf.php";
                HttpModuel httpm = new HttpModuel();
                string finalresult = httpm.postjson(url, jsonlist.ToString());
                if(finalresult=="OK")
                {
                    MessageBox.Show("配置文件已重新生成,点击重启服务应用新数据集");
                }
                else
                {
                    MessageBox.Show("服务器故障");
                }
            }
            else
            { MessageBox.Show("请至少选择一个数据集"); }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //string url = "http://172.17.30.109:44444/reload.php";
            string url = "http://" + targetip + ":44444/reload.php";
            HttpModuel httpm = new HttpModuel();
            string finalresult = httpm.getresult(url);
            MessageBox.Show(finalresult);
        }

        private void Allpick_Click(object sender, RoutedEventArgs e)
        {
            foreach (TreeListNode node in this.treeview.Nodes)
            {
                node.IsChecked = true;
            }
        }
    }

    public class mongodata
    {
        public String GridFS名称 { get; set; }
        public string 数据库名 { get; set; }
        public string 建库时间 { get; set; }
        public string 入库时间 { get; set; }
        public string 数据类型 { get; set; }
        public string Left { get; set; }
        public string Top { get; set; }
        public string Right { get; set; }
        public string Bottom { get; set; }
        public string 最小层级 { get; set; }
        public string 最大层级 { get; set; }
        public string 描述 { get; set; }
        
    }
}
