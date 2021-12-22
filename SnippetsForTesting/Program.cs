using System;

namespace SnippetsForTesting
{
    class Program
    {
        static void Main(string[] args)
        {
                        
            var actionFuncLambdaObj = new ActionFuncLambda();
            Console.WriteLine(actionFuncLambdaObj.DoTheStringReverse("Hello World!"));
            Console.WriteLine(actionFuncLambdaObj.StringReverseWithNormalDelegate("Hello World 1234!"));
            Console.WriteLine(actionFuncLambdaObj.StringReverseWithNormalDelegateAnonymousMethod("Hello World 1234567!"));
            Console.WriteLine(actionFuncLambdaObj.StringReverseWithFunc("Hello World 12345678!"));
            actionFuncLambdaObj.StringReverseWithAction("Hello World 1234567890!");

            /*
             * https://www.goodwin.dev/dev/2019/10/3/how-to-connect-postman-to-microsoft-azure-service-bus-via-rest/
             * https://docs.microsoft.com/en-us/azure/service-bus-messaging/service-bus-sas
             */
            ESBSaSTokenGen saSTokenGen = new ESBSaSTokenGen("https://testnilesh.servicebus.windows.net/nileshqueue",
                "RootManageSharedAccessKey",
                "lJQFDziOpdI0QwMM8r4IoGK0VxvppxUaHzf+yctN+b8=");
            var token = saSTokenGen.GetSasToken();
            Console.WriteLine("Authorization: " + token);

            Console.ReadLine();
        }

    }
}
