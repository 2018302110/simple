using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication1
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        //将非汉字的部分变为字符‘0’
        [WebMethod]
        public string removeNonWords(string allWords1)
        {
            char[] c = allWords1.ToCharArray();
            //只保留汉字
            for (int i = 0; i < c.Length; i++)
            {   //不是汉字
                if (c[i] < 0x4e00 || c[i] > 0x9fbb)
                {
                    c[i] = '0';
                }
            }
            string allWords2 = new string(c);
            return allWords2;
        }
    }
}
