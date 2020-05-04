using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HtmlAgilityPack;
using System.Windows.Forms;
namespace webCrawler
{
    class Crawler
    {
        HashSet<string> visitedUrls = new HashSet<string>();
        Queue<string> toVisitUrls = new Queue<string>();
        int maxNumOfPages ;
        int numOfVisitedPages ;
        string path;
        string startingUrl;
        string rootFileName;
        bool sameHost;//a flag to specify if the crawl is on pages from the same host only
        string hostUrl;
        //the stream writer to write logs in the info/logfile.txt
        StreamWriter logFileWriter;
        //the stream writer to write index of pages in the info/pages index.txt
        StreamWriter indexFileWriter;
        public Crawler(string url, string savingPath) : this(url,savingPath,100,false)
        {        
        }
        public Crawler(string url, string savingPath, int maxNumOfVisitedPages) : this(url, savingPath, maxNumOfVisitedPages, false)
        {
        }
        public Crawler(string url,string savingPath,int maxNumOfVisitedPages,bool host)
        {
            this.path = savingPath;
            this.startingUrl = url;
            this.maxNumOfPages = maxNumOfVisitedPages;
            this.sameHost = host;
            //get the host of the starting url
            var uri = new Uri(startingUrl);
            this.hostUrl = uri.Host;
            numOfVisitedPages = 0;
            this.rootFileName = "root folder " + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss_fff");
            Directory.CreateDirectory(path + "\\" + rootFileName);
            Directory.CreateDirectory(path + "\\" + rootFileName+"\\info");
            Console.WriteLine(path + "\\" + rootFileName + " has been created");
            indexFileWriter = new StreamWriter(path + "\\" + rootFileName + "\\info\\indexOfPages.txt");
            logFileWriter = new StreamWriter(path + "\\" + rootFileName+"\\info\\logfile.txt");

        }
        public void startCrawling()
        {
            crawl(startingUrl);
            MessageBox.Show("fnished crawling.\n"+numOfVisitedPages+"have been visited");
        }
        private void crawl(string url)
        {
            if (numOfVisitedPages>maxNumOfPages)
            {
                toVisitUrls.Clear();//empty the queue
                return;
            }
            try
            {
                    string fileName = "\\page#" + numOfVisitedPages + ".html";
                    indexFileWriter.WriteLine("page#" + numOfVisitedPages.ToString() + " Url is: " + url);
                Console.WriteLine("page#" + numOfVisitedPages.ToString() + " Url is: " + url);
                    numOfVisitedPages++;
                    HtmlWeb hw = new HtmlWeb();
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc = hw.Load(url);
                //here send the web page to the rabbitMq in order to be processed
                //(to extract title for simplicity)
                    doc.Save(path + "\\" + rootFileName + fileName);
                    foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
                    {
                        // Get the value of the HREF attribute
                        string hrefValue = link.GetAttributeValue("href", string.Empty);
                        if (!visitedUrls.Contains(hrefValue) && !toVisitUrls.Contains(hrefValue)) //not visited yet and not in the queue
                        {
                        string currentPageHostUrl = "";
                        try
                        {
                            var uri = new Uri(hrefValue);
                             currentPageHostUrl = uri.Host;//get the host of the new discovered url
                        }
                        catch (UriFormatException exp)
                        {
                            logFileWriter.WriteLine(DateTime.Now.ToString("yyyy/MM/dd,hh:mm:ss:fff")+" :"+exp.Message);
                            Console.WriteLine(exp.Message);
                        }
                        if (!sameHost || currentPageHostUrl == hostUrl)//check if this page belong to the same host(after checking if the same host option is checked)
                            {
                            logFileWriter.WriteLine(DateTime.Now.ToString("yyyy/MM/dd,hh:mm:ss:fff")+ " :enqueueing: " + hrefValue);
                            Console.WriteLine("enqueueing: " + hrefValue);
                                toVisitUrls.Enqueue(hrefValue);
                            }
                        }
                        else
                        {
                        logFileWriter.WriteLine(DateTime.Now.ToString("yyyy/MM/dd,hh:mm:ss:fff")+" :already visited: " + hrefValue);
                        Console.WriteLine("already visited: " + hrefValue);
                        }
                    }
                if (toVisitUrls.Count != 0)
                {
                    string s = toVisitUrls.Dequeue();
                    visitedUrls.Add(s);
                    logFileWriter.WriteLine(DateTime.Now.ToString("yyyy/MM/dd,hh:mm:ss:fff")+" :visiting: " + s); 
                    Console.WriteLine("visiting: " + s);
                    crawl(s);
                }
            }
            catch (Exception exp)
            {
                //if there is a  problem in one of the pages continue crawling
                //MessageBox.Show(exp.Message);
                if (toVisitUrls.Count != 0)
                {
                    string s = toVisitUrls.Dequeue();
                    visitedUrls.Add(s);
                    logFileWriter.WriteLine(DateTime.Now.ToString("yyyy/MM/dd,hh:mm:ss:fff")+" :visiting: " + s); 
                    Console.WriteLine("visiting: " + s);
                    crawl(s);
                }
            }
        }
        string modifyUrl(string oldUrl)
        {
            return "";
        }
    }
}
