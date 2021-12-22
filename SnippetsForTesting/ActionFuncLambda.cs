using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetsForTesting
{
    public class ActionFuncLambda
    {
        delegate string DelStringReverse(string input); // this is Type declaration, could not be used
                                                                // inside the method
        public string DoTheStringReverse(string input)
        {
            return new string(input.Reverse().ToArray());
        }

        public string StringReverseWithNormalDelegate(string input)
        {
            DelStringReverse delObj = DoTheStringReverse;
            return delObj.Invoke(input);
        }

        public string StringReverseWithNormalDelegateAnonymousMethod(string input)
        {
            DelStringReverse delObj = new DelStringReverse(
                delegate(string inputX)
                {
                    return new string(inputX.Reverse().ToArray());
                }
                );
            return delObj.Invoke(input);
        }
        public string StringReverseWithFunc(string input)
        {
            Func<string, string> strWithFunc = inputX => new string(inputX.Reverse().ToArray()); // expression style
            Func<string, string> strWithFunc1 = (string inputX1) => { return new string(inputX1.Reverse().ToArray()); } ; // statement style
            Func<string, string> strWithFunc2 = inputX2 => { return new string(inputX2.Reverse().ToArray()); }; // statement style
            return strWithFunc(input);
        }
        public void StringReverseWithAction(string input)
        {
            Action<string> strWithAction = inputY => Console.WriteLine( new string(inputY.Reverse().ToArray())); // expression style
            Action<string> strWithAction1 = (string inputZ) => { Console.Write(new string(inputZ.Reverse().ToArray())); }; // statement style
            strWithAction(input);
            strWithAction1(input);
        }
    }
}
