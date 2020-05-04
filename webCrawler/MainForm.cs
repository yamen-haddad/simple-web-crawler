using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using HtmlAgilityPack;

namespace webCrawler
{
    public partial class MainForm : Form
    {
        private static Object Lock = new Object();
        //the number of threads to serve the clients
        static int limit = 10;
        Thread[] workers = new Thread[limit];
        //to specify if the thread number i is working or not
        bool[] busy = new bool[limit];
        Thread mainThread;
        string path = "";
        delegate void addLogCallback(string logLine);
        public void addLog(string logLine)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            //If these threads are different, it returns true.
            if (this.logRichTextBox.InvokeRequired)
            {
                addLogCallback d = new addLogCallback(addLog);
                this.Invoke(d, new object[] { logLine });
            }
            else
            {
                this.logRichTextBox.Text += logLine + "\r\n";
            }
        }
        //this function return the index of the first free thread or -1 if all the threads are busy
        private int getWorker()
        {
            for (int i = 0; i < limit; i++)
            {
                if (!busy[i])
                    return i;
            }
            return -1;
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog pathFBD = new FolderBrowserDialog();
            //pathFBD.RootFolder;
            //pathFBD.SelectedPath = @"F:\study\4th year\hurry\3rd semester\network programming\2nd homework\webCrawler\webCrawler";
            if (pathFBD.ShowDialog()== DialogResult.OK)
            {
                path = pathFBD.SelectedPath;
                pathTextBox.Text = path;
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void crawlingButton_Click(object sender, EventArgs e)
        {
            int workerIndex = getWorker();
            if (workerIndex == -1)
            {
                MessageBox.Show("application is busy right now please try again later.");
                addLog("all the workers are busy try again later.");
            }
            else
            {
                //we have to lock this code to avoid choosing the same free thread more than once
                lock (Lock)
                {
                    workers[workerIndex] = new Thread(
                        new ThreadStart(
                            () =>
                            {
                                int numOfPages = 100,x;
                                bool check = false;
                                if (samehostCheckBox.Checked)
                                    check = true;
                                if (int.TryParse(maxnumTextBox.Text,out x))
                                {
                                    if(x>0)
                                        numOfPages = x;
                                }
                                Crawler c = new Crawler(urlTextBox.Text, path, numOfPages, check);
                                c.startCrawling();
                            }
                       ));
                    busy[workerIndex] = true;
                    workers[workerIndex].Start();
                    addLog("crawler number["+workerIndex+"] started working");
                }
            }
        }
        private void savePage()
        {
            try
            {
                string fileName = "\\1st try.html";
                string rootFileName = "root folder site "+ DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss_fff");
                Console.WriteLine(path + "\\" + rootFileName);
                Directory.CreateDirectory(path + "\\" + rootFileName);
                HtmlWeb hw = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc = hw.Load(urlTextBox.Text);
                doc.Save(path + "\\" + rootFileName + fileName);
                int i = 0;
                foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
                {
                    // Get the value of the HREF attribute
                    string hrefValue = link.GetAttributeValue("href", string.Empty);
                    //link.SetAttributeValue();
                    Console.WriteLine("link number " + i + " is: " + hrefValue);
                    i++;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void urlTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pathTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void s_Click(object sender, EventArgs e)
        {

        }

        private void logRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void samehostCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void maxnumTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
