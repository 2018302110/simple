using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class ShowResult
    {
        //输出字的种类的函数
        public string wordResult(theWord[]  a)
        {
            string allWords3 = null;
            for (int i = 0; i < a.Length; i++)
            {
                allWords3 += (i + 1) + "：" + (a[i].word).ToString() + "\r\n\r\n";
            }
            return allWords3;
        }

        //输出字的数量的函数
        public string numResult1(theWord[] a)
        {
            string  allNums1 = null;
            for (int i = 0; i < a.Length; i++)
            {
                allNums1 += (i + 1) + "：" + (a[i].num).ToString() + "\r\n\r\n";
            }
            return allNums1;
        }

        //输出字数量条形图的函数
        public string numResult2(theWord[] a)
        {
            string  allNums2 = null;
            for (int i = 0; i < a.Length; i++)
            {
                string line = null;
                for (int ii = 0; ii < a[i].num; ii++)
                {
                    line += "I";
                }
                allNums2 += (i + 1) + "：" + line + "\r\n\r\n";
            }
            return allNums2;
        }

        //输出词的种类的函数
        public string wordResult(customWord[] a)
        {
            string allWords3 = null;
            for (int i = 0; i < a.Length; i++)
            {
                allWords3 += (i + 1) + "：" + a[i].word + "\r\n\r\n";
            }
            return allWords3;
        }

        //输出词的数量的函数
        public string numResult1(customWord[] a)
        {
            string allNums1 = null;
            for (int i = 0; i < a.Length; i++)
            {
                allNums1 += (i + 1) + "：" + (a[i].num).ToString() + "\r\n\r\n";
            }
            return allNums1;
        }

        //输出词数量条形图的函数
        public string numResult2(customWord[] a)
        {
            string allNums2 = null;
            for (int i = 0; i < a.Length; i++)
            {
                string line = null;
                for (int ii = 0; ii < a[i].num; ii++)
                {
                    line += "I";
                }
                allNums2 += (i + 1) + "：" + line + "\r\n\r\n";
            }
            return allNums2;
        }

        //输出关联词的种类的函数
        public string wordResult(relevanceWord[] a)
        {
            string allWords3 = null;
            for (int i = 0; i < a.Length; i++)
            {
                allWords3 += (i + 1) + "：" + a[i].words + "\r\n\r\n";
            }
            return allWords3;
        }

        //输出关联词关联度的函数
        public string numResult1(relevanceWord[] a)
        {
            string allNums1 = null;
            for (int i = 0; i < a.Length; i++)
            {
                allNums1 += (i + 1) + "：" + (a[i].num).ToString() + "\r\n\r\n";
            }
            return allNums1;
        }

        //输出关联词关联度条形图的函数
        public string numResult2(relevanceWord[] a)
        {
            string allNums2 = null;
            for (int i = 0; i < a.Length; i++)
            {
                string line = null;
                for (int ii = 0; ii < a[i].num; ii++)
                {
                    line += "I";
                }
                allNums2 += (i + 1) + "：" + line + "\r\n\r\n";
            }
            return allNums2;
        }

    }
}
