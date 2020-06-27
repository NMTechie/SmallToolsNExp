using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringComparerExp
{
    class Program
    {
        static void Main(string[] args)
        {
            TableQuery tableQuery = new TableQuery();
            tableQuery.Take(100);
            tableQuery.FilterString = TableQuery.CombineFilters(
                TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "1"),
                TableOperators.And,
                TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, "2"));
            try
            {
                CloudStorageAccount sta = CloudStorageAccount.Parse("");
                CloudTableClient tableClient = sta.CreateCloudTableClient();
                CloudTable table = tableClient.GetTableReference("TestQuestionnaireComments");
                var result = table.ExecuteQuery(tableQuery).ToList().FirstOrDefault();
                Int64 highestVal = Int64.MinValue;
                foreach (var item in result.Properties)
                {
                    if (highestVal == Int64.MinValue)
                    {
                        highestVal = Convert.ToInt64(item.Key.Substring(1));
                    }
                    else if(highestVal < Convert.ToInt64(item.Key.Substring(1)))
                    {
                        highestVal = Convert.ToInt64(item.Key.Substring(1));
                    }
                }
                Console.WriteLine($"The latest comments is {result.Properties["A"+highestVal.ToString()]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Prees any Key to close ......................");
                Console.ReadKey();
            }
        }
    }
}
