using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksAsynchony
{
    internal class SyncClass1
    {
        private readonly ASyncClass3 _asyncClass;
        public SyncClass1(ASyncClass3 aSyncClass3)
        {
                _asyncClass = aSyncClass3;
        }
        public void DoWorkFromSyncClass1()
        {
            Console.WriteLine($"InSide DoWorkFromSyncClass1 Called --> {Thread.CurrentThread.ManagedThreadId} --> at {DateTime.Now}");
            var p = Task.Run(async () =>
            {
                Console.WriteLine($"InSide DoWorkFromSyncClass1 Task.Run --> {Thread.CurrentThread.ManagedThreadId} --> at {DateTime.Now}");
                await _asyncClass.DoWorkAsyncClass3();
            });
            /*If this line ommited when calling a Async method from a sync method using Task.Run,
             * then called Async method will neved been invoked as the wrapped task in not awaited */
            p.Wait(); 
            Console.WriteLine($"InSide DoWorkFromSyncClass1 End --> {Thread.CurrentThread.ManagedThreadId} --> at {DateTime.Now}");
        }
    }
}
