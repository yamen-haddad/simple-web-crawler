using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace webCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost/shaghelni-27-5/index.php";
            Console.WriteLine("Trying Http Get...");

            string page = HttpHelper.HttpGet(url);
            Console.WriteLine(page);
            Console.WriteLine("Trying Http Get succeeded...");
            Console.ReadKey();
            Thread formThread = new Thread(new ThreadStart(mainFormService));
            formThread.SetApartmentState(ApartmentState.STA);
            formThread.Start();
            try
            {
                var uri = new Uri("#");
                Console.WriteLine(uri.Host);
            }
            catch (UriFormatException exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        static void mainFormService()
        {
            MainForm f1 = new MainForm();
            f1.ShowDialog();
        }
    }
}
