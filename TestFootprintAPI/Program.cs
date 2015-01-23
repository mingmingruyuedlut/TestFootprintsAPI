using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFootprintAPI.Manager;
using TestFootprintAPI.Model;

namespace TestFootprintAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Start to call footprint api:");
                Console.WriteLine();

                //Console.WriteLine("Call Create API:");
                //IssueArgs issueArgs = GetIssueArgs();
                //string issueId = CreateIssue(issueArgs);
                //Console.WriteLine("Issue Id: {0}", issueId);
                //Console.WriteLine("Call Create API Successfully!");
                //Console.WriteLine();
                //Console.WriteLine("Please press any key to test the next api.");
                //Console.ReadKey();

                Console.WriteLine("Call Search API:");
                DateTime startTime = DateTime.Now;
                string query = ConfigurationManager.AppSettings["FPSearchIssueQuery1"];
                string issueResult = SearchIssue(query);
                Console.WriteLine("Search Result:");
                Console.WriteLine(issueResult);
                Console.WriteLine(DateTime.Now - startTime);

                //startTime = DateTime.Now;
                //query = ConfigurationManager.AppSettings["FPSearchIssueQuery2"];
                //issueResult = SearchIssue(query);
                //Console.WriteLine("Search Result:");
                //Console.WriteLine(issueResult);
                //Console.WriteLine(DateTime.Now - startTime);

                Console.WriteLine("Call Search API Successfully!");


                Console.WriteLine("End. Call footprint api successfully!");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Call footprint api error!!!");
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }

        public static string GetIssueDetail(int projectId, int issueId)
        {
            RetrieveIssueManager retrieveManager = new RetrieveIssueManager();
            string username = ConfigurationManager.AppSettings["FPUserName"];
            string psw = ConfigurationManager.AppSettings["FPPassword"];
            string result = retrieveManager.MRWebServices__getIssueDetails(username, psw, "RETURN_MODE => 'xml'", projectId, issueId);
            return result;
        }

        public static string CreateIssue(IssueArgs issueargs)
        {
            CreateIssueManager createIssuemanger = new CreateIssueManager();
            string username = ConfigurationManager.AppSettings["FPUserName"];
            string psw = ConfigurationManager.AppSettings["FPPassword"];
            string IssueId = createIssuemanger.MRWebServices__createIssue(username, psw, "", issueargs);

            return IssueId;
        }

        public static string SearchIssue(string query)
        {
            SearchDBManager searchManager = new SearchDBManager();
            string username = ConfigurationManager.AppSettings["FPUserName"];
            string psw = ConfigurationManager.AppSettings["FPPassword"];
            string result = searchManager.MRWebServices__search(username, psw, "RETURN_MODE => 'xml'", query);
            return result;
        }

        public static IssueArgs GetIssueArgs()
        {
            IssueArgs issue = new IssueArgs();
            issue.title = "Test footprint service api";
            issue.priorityNumber = "1";
            issue.status = "Open";  //currrently only 'Open' works
            issue.description = "This is test footprint service api";
            issue.selectContact = "1";
            issue.projectID = ConfigurationManager.AppSettings["FPCreateIssueProjectId"];
            return issue;
        }
    }
}
