using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public struct relevanceWord
    {
        public int num;
        public string words;
    }

    class Relevance
    {
        //判断词语是否重复
        public int isRepet(string word1,string word2, ArrayList relevanceWordsWord, int criterion)
        {
            string aa = word1 + "-----" + word2 + "(" + criterion + ")";
            for (int i = 0; i < relevanceWordsWord.Count; i++)
            {
                if (aa == (string)relevanceWordsWord[i])
                {
                    string a = "这个关联已经找过了";
                    string b = "提示";
                    MessageBox.Show(a, b);
                    return 0;
                }
            }
            return 1;
        }

        //判断输入是否只有汉字
        public int isLegal(string word1, string word2)
        {
            for (int i = 0; i < word1.Length; i++)
            {
                //不是汉字
                if (word1[i] < 0x4e00 || word1[i] > 0x9fbb)
                {
                    string a = "词语一不能包含非汉字哦";
                    string b = "提示";
                    MessageBox.Show(a, b);
                    return 0;
                }
            }
            for (int i = 0; i < word2.Length; i++)
            {
                if (word2[i] < 0x4e00 || word2[i] > 0x9fbb)
                {
                    string a = "词语二不能包含非汉字哦";
                    string b = "提示";
                    MessageBox.Show(a, b);
                    return 0;
                }
            }
            return 1;
        }

        //判断是否是数字
        public bool isNum(string criterion)
        {
            if (criterion.Length == 0)
            {
                string a = "请输入关联度";
                string b = "提示";
                MessageBox.Show(a, b);
                return false;
            }
            for (int i=0;i<criterion.Length;i++)
            {
                if (criterion[i] < 48 || criterion[i] > 57)
                {
                    string a = "关联度应是正整数";
                    string b = "提示";
                    MessageBox.Show(a, b);
                    return false;
                }

            }
            return true;
        }

        //判断是否输入了
        public bool isInput(string word1,string word2)
        {
            if(word1.Length==0||word2.Length==0)
            {
                string a = "请输入关联词";
                string b = "提示";
                MessageBox.Show(a, b);
                return false;
            }
            return true;
        }

        //得出两个词语关联的次数
        public relevanceWord[] getRelevance(string word1,string word2,string allWords2,int criterion, ArrayList relevanceWordsNum, ArrayList relevanceWordsWord)
        {
            if (isRepet(word1, word2, relevanceWordsWord,criterion)==1 && isLegal(word1, word2)==1&& isInput( word1,  word2))
            {

                //含有第一个词的所有“句子”
                ArrayList sentences = new ArrayList();

                string aa = word1 + "-----" + word2+"("+criterion+")";
                relevanceWordsWord.Add(aa);
                relevanceWordsNum.Add(0);
                //找出所有句子
                for (int i = 0; i < allWords2.Length; i++)
                {
                    if (allWords2[i] == word1[0])
                    {
                        for (int n = 0; n < word1.Length; n++)
                        {
                            if (i + n >= allWords2.Length)
                                break;
                            //某个字不符
                            if (allWords2[i + n] != word1[n])
                                break;
                            //文本中找到该词
                            if (n == (word1.Length - 1))
                            {
                                int a, b;
                                //不超出范围
                                a = (i - criterion < 0) ? 0 : (i - criterion);
                                b = (i + word1.Length + criterion > allWords2.Length - 1) ? allWords2.Length - 1 : i + word1.Length + criterion;

                                sentences.Add(allWords2.Substring(a, b - a + 1));
                            }
                        }
                    }
                }
                //在每个“句子”中找第二个词
                for (int m = 0; m < sentences.Count; m++)
                {
                    for (int i = 0; i < ((string)sentences[m]).Length; i++)
                    {
                        if (((string)sentences[m])[i] == word2[0])
                        {
                            for (int n = 0; n < word2.Length; n++)
                            {
                                if (i + n >= ((string)sentences[m]).Length)
                                    break;
                                if (((string)sentences[m])[i + n] != word2[n])
                                    break;
                                if (n == (word2.Length - 1))
                                    relevanceWordsNum[relevanceWordsNum.Count - 1] = Convert.ToInt32(relevanceWordsNum[relevanceWordsNum.Count - 1]) + 1;
                            }
                        }
                    }
                }
            }
            //将数据保存到结构体数组
            relevanceWord[] relevanceword = new relevanceWord[relevanceWordsWord.Count];

            for (int i = 0; i < relevanceWordsWord.Count; i++)
            {
                relevanceword[i].num = Convert.ToInt32(relevanceWordsNum[i]);
                relevanceword[i].words = (string)relevanceWordsWord[i];
            }

            return relevanceword;
        }


    }
}
