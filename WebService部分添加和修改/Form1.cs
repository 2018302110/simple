using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using WindowsFormsApp1;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        ServiceReference2.WebService1SoapClient myWebService = null;
        public Form1()
        {
            InitializeComponent();
            myWebService = new ServiceReference2.WebService1SoapClient("WebService1Soap");
        }

        StartPage startPage = new StartPage();
        ShowResult showResult = new ShowResult();
        Custom custom = new Custom();
        Relevance relevance = new Relevance();

        //start按钮
        private void button1_Click(object sender, EventArgs e)
        {
            //用户输入的初始文本
            string allWords1 = textBox1.Text;
            //返回排列好的结构体数组
            theWord[] theWords2 = startPage.start(allWords1);
            //在结果page上显示结果
            textBox2.Text = showResult.wordResult(theWords2);
            textBox3.Text = showResult.numResult1(theWords2);
            textBox4.Text = showResult.numResult2(theWords2);
        }


        //自定义页须将中间过程保存在button方法外面
        //存储每种字的数量
        ArrayList theWordsNum = new ArrayList();
        //存储所有字的种类
        ArrayList theWordsWord = new ArrayList();

        //自定义添加按钮
        private void button2_Click(object sender, EventArgs e)
        {
            //用户输入的自定义词
            string customWord = textBox5.Text;

            //用户输入的初始文本
            string allWords1 = textBox1.Text;
            //返回去除非汉字的文本
            string allWords2 = myWebService.removeNonWords(allWords1);

            //得出自定义词数量，更新输出词组
            customWord[] customWords=custom.countWord(customWord, allWords2, theWordsNum, theWordsWord);
            //将词语按照数量由多到少排序
            customWords = custom.getTheSort2(customWords);

            //在自定义page上显示结果
            textBox6.Text = showResult.wordResult(customWords);
            textBox7.Text = showResult.numResult1(customWords);
            textBox8.Text = showResult.numResult2(customWords);

        }


        //关联词语页须将中间过程保存在button方法外面
        //存储关联词的关联次数
        ArrayList relevanceWordsNum = new ArrayList();
        //存储所有关联词的种类
        ArrayList relevanceWordsWord = new ArrayList();

        //关联页查看关联按钮
        private void button3_Click(object sender, EventArgs e)
        {
            //用户输入的关联词
            string word1 = textBox9.Text;
            string word2 = textBox10.Text;

            //用户输入的初始文本
            string allWords1 = textBox1.Text;
            //返回去除非汉字的文本
            string allWords2 = myWebService.removeNonWords(allWords1);

            //获得关联度的标准
            int criterion = 0;
            if (radioButton1.Checked)
                criterion = 3;
            if (radioButton2.Checked)
                criterion = 6;
            if (radioButton3.Checked)
                criterion = 10;
            if (radioButton4.Checked&&relevance.isNum(textBox11.Text))
                criterion = int.Parse(textBox11.Text);

            //得出关联词关联度
            relevanceWord[] relevanceword = relevance.getRelevance(word1, word2, allWords2, criterion, relevanceWordsNum, relevanceWordsWord);
            
            //在关联页上显示结果
            textBox13.Text= showResult.wordResult(relevanceword);
            textBox12.Text = showResult.numResult1(relevanceword);
            textBox14.Text = showResult.numResult2(relevanceword);

        }

        //清除关联页的结果
        private void button4_Click(object sender, EventArgs e)
        {
            relevanceWordsNum.Clear();
            relevanceWordsWord.Clear();
            textBox13.Text = null;
            textBox12.Text = null;
            textBox14.Text = null;
        }

        //清除自定义页的结果
        private void button5_Click(object sender, EventArgs e)
        {
            theWordsNum.Clear();
            theWordsWord.Clear();
            textBox6.Text = null;
            textBox7.Text = null;
            textBox8.Text = null;
        }
    }
}
