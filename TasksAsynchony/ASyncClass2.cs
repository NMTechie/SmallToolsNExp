using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksAsynchony
{
    internal class ASyncClass2
    {
        private readonly SyncClass1 _syncClass;
        public ASyncClass2(SyncClass1 syncClass) 
        {
            _syncClass = syncClass;
        }    
        public async Task<bool> DoWorkAsyncClass2()
        {
            Console.WriteLine($"InSide DoWorkAsyncClass2 Called --> {Thread.CurrentThread.ManagedThreadId} --> at {DateTime.Now}");
            await Task.Run(() =>
                            { 
                                Console.WriteLine($"InSide DoWorkAsyncClass2 Task.Run --> {Thread.CurrentThread.ManagedThreadId} --> at {DateTime.Now}"); 
                            });
            _syncClass.DoWorkFromSyncClass1();
            Console.WriteLine($"InSide DoWorkAsyncClass2 Ended --> {Thread.CurrentThread.ManagedThreadId} --> at {DateTime.Now}");
            return true;
        }
    }
}
