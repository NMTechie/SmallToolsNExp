using System;
using DevLab.JmesPath;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Nilesh.SmallTools
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = "{\"customerIdentifier\":\"INSCOM001\",\"recordCount\":\"2\",\"timestamp\":\"2021 - 10 - 17T14: 59:15.449Z\",\"documents\":[{\"dataType1\":\"DB\",\"documentType\":\"Policy\",\"documentKey\":{\"policyNum\":123456},\"documentValue\":{\"carrierName\":\"bobs insurance\",\"policyNum\":123456,\"insuredAddress\":\"123  main st, anytown, PA 19109\"}},{\"dataType\":\"DB\",\"documentType\":\"Policy\",\"timestamp\":\"2021 - 10 - 15T09: 43:43.045Z\",\"documentKey\":{\"policyNum\":123789},\"documentValue\":{\"carrierName\":\"sims insurance\",\"policyNum\":123789,\"insuredAddress\":\"123  main st, anytown, PA 19109\"}}]}";

            string customerIdentifierQuery = "customerIdentifier";
            string recordCountQuery = "recordCount";
            /* Please do not put any line break in the query*/
            string schemaValidationQuery = "documents[*].{dataType:dataType,documentType:documentType,documentKey:documentKey,documentValue:documentValue}";
            string findInvlaidPolicyNumQuery = "[?documentValue == null || dataType == null || documentType == null || documentKey == null].documentKey.policyNum";
            var jmesPath = new JmesPath();
            //
            var customerIdentifier = jmesPath.Transform(jsonString, customerIdentifierQuery);
            customerIdentifier = customerIdentifier.Substring(1, customerIdentifier.Length - 2);
            var recordCount = jmesPath.Transform(jsonString, recordCountQuery);
            if (recordCount.Trim().Equals("null", StringComparison.OrdinalIgnoreCase))
            {
                recordCount = "1";
            }
            else
            {
                recordCount = recordCount.Substring(1, recordCount.Length - 2);
            }
            //
            var afterValidateSchema = jmesPath.Transform(jsonString, schemaValidationQuery);
            var invalidPolicyNum = jmesPath.Transform(afterValidateSchema, findInvlaidPolicyNumQuery);

            var jObjArrayInvalidPolicies = JsonConvert.DeserializeObject<JArray>(invalidPolicyNum);
            if(jObjArrayInvalidPolicies.Count > 0 )
            {
                Console.WriteLine(jObjArrayInvalidPolicies.ToString());
            }
            else
            {
                Console.WriteLine($" There is no Error in the request ");
            }

            Console.WriteLine($" The customer Identifier is ----------- {customerIdentifier} ");
            Console.WriteLine($" No of records expected  ----------- {recordCount} ");
            
            Console.ReadLine();
        }
    }
}
