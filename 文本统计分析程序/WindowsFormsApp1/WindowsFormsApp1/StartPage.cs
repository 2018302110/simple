using System;
using System.Collections;

namespace WindowsFormsApp1
{
    public struct theWord
    {
        public int num;
        public char word;
    }

    public class StartPage
    {
        static int zero = 0;

        public theWord[] start(string allWords1)
        {
            string allWords2 = removeNonWords(allWords1);
            theWord[] theWords1 = getTheSort1(allWords2);
            theWord[] theWords2 = getTheSort2(theWords1);
            return theWords2;
        }

        //将非汉字的部分变为字符‘0’
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

        //得出汉字的种类和数量
        public theWord[] getTheSort1(string allWords2)
        {
            //存储每种字的数量
            ArrayList theWordsNum = new ArrayList();
            //存储所有字的种类
            ArrayList theWordsWord = new ArrayList();
            char[] c = allWords2.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if(c[i]!='0')
                {
                    if(theWordsWord.Count==0)
                    {
                        theWordsWord.Add(c[i]);
                        theWordsNum.Add(0);
                    }
                    for(int a=zero;a<theWordsWord.Count;a++)
                    {
                        if(c[i]==(char)theWordsWord[a])
                        {
                            theWordsNum[a]=Convert.ToInt32(theWordsNum[a])+1;
                            break;
                        }
                        else if(a== theWordsWord.Count-1)
                        {
                            theWordsWord.Add(c[i]);
                            theWordsNum.Add(1);
                            break;
                        }
                    }
                }
            }

            theWord[] theWords = new theWord[theWordsWord.Count];

            for (int i=0;i<theWordsWord.Count;i++)
            {
                theWords[i].num = Convert.ToInt32(theWordsNum[i]);
                theWords[i].word = (char)theWordsWord[i];
            }

            return theWords;
        }

        //将汉字按照数量由多到少排序
        public theWord[] getTheSort2(theWord[] getIn)
        {
            for(int i=0;i<getIn.Length;i++)
            {
                int max = getIn[i].num;
                int maxNum=0;
                for(int c=i;c<getIn.Length;c++)
                {
                    if(max<getIn[c].num)
                    {
                        max = getIn[c].num;
                        maxNum = c;
                    }
                }
                //当有更大的才交换
                if (maxNum != 0)
                {
                    int ii; char iii;
                    ii = getIn[i].num;
                    getIn[i].num = getIn[maxNum].num;
                    getIn[maxNum].num = ii;
                    iii = getIn[i].word;
                    getIn[i].word = getIn[maxNum].word;
                    getIn[maxNum].word = iii;
                }
            }
            return getIn;
        }
    }
}
