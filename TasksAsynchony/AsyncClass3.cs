using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksAsynchony
{
    internal class ASyncClass3
    {
        public ASyncClass3()
        {
                
        }
        public async Task DoWorkAsyncClass3()
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"InSide DoWorkAsyncClass3 Task.Run --> {Thread.CurrentThread.ManagedThreadId}");
            });
        }
    }
}
