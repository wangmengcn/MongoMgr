using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MongoMgr
{
    class HttpModuel
    {
        public string postjson(string url,string json)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);      //此处填写php服务的url地址 
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);

                streamWriter.Flush();
                streamWriter.Close();
            }



            try
            {
                HttpWebResponse httpResponse = (HttpWebResponse)(httpWebRequest.GetResponse());
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();                                                              //服务返回值，在使用Qury操作之后，返回Json串
                    //string abc=obj["user"].ToString();
                    //MessageBox.Show("success");
                    //

                    //从这里开始 就是对返回的Json串进行解析，得到的ja是一个数组 可以按照下边的操作取到想要的字段值
                    
                    return result.ToString();
                    //ja[0]表示ja中的第一条记录，ja[0]["字段名"]可以获取到目标字段

                }
            }
            catch (WebException e)
            {

                return e.Message;
            }



        }

        public JArray getjson(string url)
        {
            string strURL = url ;

            try
            {
                System.Net.HttpWebRequest request;
                // 创建一个HTTP请求
                request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
                //request.Method="get";
                System.Net.HttpWebResponse response;
                response = (System.Net.HttpWebResponse)request.GetResponse();
                System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string responseText = myreader.ReadToEnd();
                myreader.Close();
                try
                {
                    JArray ja = (JArray)JsonConvert.DeserializeObject(responseText);
                    return ja;
                }
                catch
                {
                    MessageBox.Show(responseText);
                    return null;
                }
                
               
            }
            catch (WebException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }


        }


        public string getresult(string url)
        {
            string strURL = url;

            try
            {
                System.Net.HttpWebRequest request;
                // 创建一个HTTP请求
                request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
                //request.Method="get";
                System.Net.HttpWebResponse response;
                response = (System.Net.HttpWebResponse)request.GetResponse();
                System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string responseText = myreader.ReadToEnd();
                myreader.Close();
                return responseText;


            }
            catch (WebException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }


        }
    }
}
