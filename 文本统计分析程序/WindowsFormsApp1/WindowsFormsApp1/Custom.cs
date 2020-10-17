using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public struct customWord
    {
        public int num;
        public string word;
    }

    class Custom
    {
        //判断词语是否重复
        public bool isRepet(string custom, ArrayList theWordsWord)
        {
            for (int i = 0; i < theWordsWord.Count; i++)
            {
                if (custom == (string)theWordsWord[i])
                {
                    string a = "这个词语重复了";
                    string b = "提示";
                    MessageBox.Show(a, b);
                    return false;
                }
            }
            return true;
        }

        //判断输入是否只有汉字
        public bool isLegal(string custom)
        {
            for(int i=0;i<custom.Length;i++)
            {
                //不是汉字
                if (custom[i] < 0x4e00 || custom[i] > 0x9fbb)
                {
                    string a = "词语不能包含非汉字哦";
                    string b = "提示";
                    MessageBox.Show(a, b);
                    return false;
                }
            }
            return true;
        }

        //判断是否输入了
        public bool isInput(string custom)
        {
            if (custom.Length == 0)
            {
                string a = "请输入自定义词";
                string b = "提示";
                MessageBox.Show(a, b);
                return false;
            }
            return true;
        }

        //得出自定义词数量，更新输出
        public customWord[] countWord(string custom,string allWords2,ArrayList theWordsNum, ArrayList theWordsWord)
        {
            if (isRepet(custom, theWordsWord)&&isLegal(custom)&&isInput(custom))
            {
                theWordsWord.Add(custom);
                theWordsNum.Add(0);
                allWords2.ToCharArray();
                custom.ToCharArray();

                //得出文本中自定义词的数量
                for (int i = 0; i < allWords2.Length; i++)
                {
                    if (allWords2[i] == custom[0])
                    {
                        for (int n = 0; n < custom.Length; n++)
                        {
                            if (allWords2[i + n] != custom[n])
                                break;
                            if (n == (custom.Length - 1))
                                theWordsNum[theWordsNum.Count - 1] = Convert.ToInt32(theWordsNum[theWordsNum.Count - 1]) + 1;
                        }
                    }
                }
            }

            customWord[] customword = new customWord[theWordsWord.Count];

            for (int i = 0; i < theWordsWord.Count; i++)
            {
                customword[i].num = Convert.ToInt32(theWordsNum[i]);
                customword[i].word = (string)theWordsWord[i];
            }

            return customword;
        }

        //将词语按照数量由多到少排序
        public customWord[] getTheSort2(customWord[] getIn)
        {
            for (int i = 0; i < getIn.Length; i++)
            {
                int max = getIn[i].num;
                int maxNum = 0;
                for (int c = i; c < getIn.Length; c++)
                {
                    if (max < getIn[c].num)
                    {
                        max = getIn[c].num;
                        maxNum = c;
                    }
                }
                //当有更大的才交换
                if (maxNum != 0)
                {
                    int ii; string iii;
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
