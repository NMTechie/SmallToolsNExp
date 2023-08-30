using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksAsynchony
{
    internal class ASyncClass1
    {
        private readonly ASyncClass2 _asyncClass2;
        public ASyncClass1(ASyncClass2 asyncClass) 
        {
            _asyncClass2 = asyncClass;
        }
        public async Task DoWorkAsyncClass1()
        {
            Console.WriteLine($"InSide DoWorkAsyncClass1 Called --> {Thread.CurrentThread.ManagedThreadId} --> at {DateTime.Now}");
            await _asyncClass2.DoWorkAsyncClass2();
            Console.WriteLine($"InSide DoWorkAsyncClass1 Ended --> {Thread.CurrentThread.ManagedThreadId} --> at {DateTime.Now}");
        }
    }
}
