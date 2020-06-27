using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TasksAndTPL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void AsyncWithNewTask_Click(object sender, EventArgs e)
        {
            Stopwatch myWatch = new Stopwatch();
            OperationWithTask obj = new OperationWithTask();
            Func<string,string> myNewFunc = new Func<string,string>(obj.GetPrintContent);
            Task<string> newTask = new Task<string>(() => myNewFunc("")); // This is how you pass a func or action that accepts input parameter
            myWatch.Start();
            /*If the task has been created then it should be start to excute the function wrapped by it. Else it will not work*/
            newTask.Start();

            /*The below implementation will work howevr it is blocking the called thread who has called the method as used task.wait()*/
            //newTask.Wait();            
            //textBox1.Text = newTask.Result;

            /*The below implementation will release the called thread (UI) and perform the work*/
            textBox1.Text = await newTask;
            myWatch.Stop();
            textBox1.Text = textBox1.Text + $"Total Time elapsed is {myWatch.ElapsedMilliseconds.ToString()}";
        }

        private void SyncProcess_Click(object sender, EventArgs e)
        {
            Stopwatch myWatch = new Stopwatch();
            OperationWithTask obj = new OperationWithTask();
            myWatch.Start();
            textBox1.Text = obj.GetPrintContent("");
            myWatch.Stop();
            textBox1.Text = textBox1.Text + $"Total Time elapsed is {myWatch.ElapsedMilliseconds.ToString()}";
        }

        private async void AsyncWithTaskRun_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            /*
             * We have seen what async/await does inside AsyncWithNewTask_Click method.
             * The same could be achieved using Task.Run, what we do here as Step 1
             */
            Stopwatch myWatch = new Stopwatch();
            OperationWithTask obj = new OperationWithTask();
            myWatch.Start();
            textBox1.Text = await Task.Run<string>(()=> obj.GetPrintContent(""));
            myWatch.Stop();
            textBox1.Text = textBox1.Text + $"Total Time elapsed is {myWatch.ElapsedMilliseconds.ToString()}"+Environment.NewLine;

            /*
             * Step 2 ... Now we are going to change the code for
             * parallel execution
             */
            textBox1.Text = textBox1.Text + "------------------" + Environment.NewLine + Environment.NewLine;
            await PrintWebSiteContentParallely();

        }

        private async Task PrintWebSiteContentParallely()
        {
            OperationWithTaskRun obj = new OperationWithTaskRun();
            List<WebsiteInfo> inputURLs = new List<WebsiteInfo>() {
                new WebsiteInfo(){ContentLength=0,WebsiteContent="",URL="https://www.google.com"},
                new WebsiteInfo(){ContentLength=0,WebsiteContent="",URL="https://www.yahoo.in"},
                new WebsiteInfo(){ContentLength=0,WebsiteContent="",URL="https://www.microsoft.com"},
                new WebsiteInfo(){ContentLength=0,WebsiteContent="",URL="https://www.stackoverflow.com"},
                new WebsiteInfo(){ContentLength=0,WebsiteContent="",URL="https://www.youtube.com"},
                new WebsiteInfo(){ContentLength=0,WebsiteContent="",URL="https://www.netflix.com"}
            };
            List<Task<WebsiteInfo>> tasks = new List<Task<WebsiteInfo>>();
            Stopwatch myWatch = new Stopwatch();
            myWatch.Start();
            foreach (WebsiteInfo item in inputURLs)
            {
                Task<WebsiteInfo> task = Task.Run<WebsiteInfo>(() => obj.DownLoadWebsiteContent(item));
                //textBox1.Text += obj.FormatTheWebSiteContent(await task);

                //This will run things in parallel but loose the display one at a time in the text box.Refer calback from Async method implementation.
                tasks.Add(task);
            }

            inputURLs = new List<WebsiteInfo>(await Task.WhenAll(tasks));
            foreach (WebsiteInfo item in inputURLs)
            {
                textBox1.Text += obj.FormatTheWebSiteContent(item);
            }

            myWatch.Stop();
            textBox1.Text = textBox1.Text + $"Total Time elapsed is {myWatch.ElapsedMilliseconds.ToString()}";
        }

        private async void AsyncCallBack_Click(object sender, EventArgs e)
        {
            OperationWithTaskRun obj = new OperationWithTaskRun();
            List<WebsiteInfo> inputURLs = new List<WebsiteInfo>() {
                new WebsiteInfo(){ContentLength=0,WebsiteContent="",URL="https://www.google.com"},
                new WebsiteInfo(){ContentLength=0,WebsiteContent="",URL="https://www.yahoo.in"},
                new WebsiteInfo(){ContentLength=0,WebsiteContent="",URL="https://www.microsoft.com"},
                new WebsiteInfo(){ContentLength=0,WebsiteContent="",URL="https://www.stackoverflow.com"},
                new WebsiteInfo(){ContentLength=0,WebsiteContent="",URL="https://www.youtube.com"},
                new WebsiteInfo(){ContentLength=0,WebsiteContent="",URL="https://www.netflix.com"}
            };
            List<Task<WebsiteInfo>> tasks = new List<Task<WebsiteInfo>>();
            Stopwatch myWatch = Stopwatch.StartNew();
            ///*
            // * This section is the arrangement is made for Progress and async task call back
            // */
            Progress<ListOfWebsiteInfo> progressInfo = new Progress<ListOfWebsiteInfo>();
            progressInfo.ProgressChanged += ProgressInfo_ProgressChanged;
            //
            var result = await obj.DownLoadWebsiteContentAsyncWithCallBack(inputURLs, progressInfo);
            //
            List<WebsiteInfo> newResult = new List<WebsiteInfo>();
            newResult.AddRange(result);
            newResult.Add(new WebsiteInfo() {ContentLength=10,URL="Test",WebsiteContent="Test" });
            PrintContentInTextBox(newResult);
            //
            myWatch.Stop();
            textBox1.Text = textBox1.Text + $"Total Time elapsed is {myWatch.ElapsedMilliseconds.ToString()}";
            
        }
        private void ProgressInfo_ProgressChanged(object sender, ListOfWebsiteInfo e)
        {
            progressBar1.Value = e.Progress;
            //List<WebsiteInfo> result = new List<WebsiteInfo>();
            //result.AddRange(e.WebSiteInfos);
            //result.Add(new WebsiteInfo() { ContentLength = 20, URL = "Test1", WebsiteContent = "Test1" });
            //PrintContentInTextBox(result);
             
        }
        private void PrintContentInTextBox(List<WebsiteInfo> result)
        {
            OperationWithTaskRun obj = new OperationWithTaskRun();
            textBox1.Text = "";
            foreach (WebsiteInfo item in result)
            {
                textBox1.Text += obj.FormatTheWebSiteContent(item);
            }
            MessageBox.Show(textBox1.Text);
        }


        /*
         * This will not going to work beacuse of cross thread update in the UI control 
         * as we have made this call under the task
        private string GetPrintContent(string extraInputURL, string anotherTestValue)
        {
            OperationWithTaskRun obj = new OperationWithTaskRun();
            List<WebsiteInfo> inputURLs = new List<WebsiteInfo>() {
                new WebsiteInfo(){ContentLength=0,WebsiteContent="",URL="https://www.google.com"},
                new WebsiteInfo(){ContentLength=0,WebsiteContent="",URL="https://www.yahoo.in"},
                new WebsiteInfo(){ContentLength=0,WebsiteContent="",URL="https://www.microsoft.com"},
                new WebsiteInfo(){ContentLength=0,WebsiteContent="",URL="https://www.stackoverflow.com"},
                new WebsiteInfo(){ContentLength=0,WebsiteContent="",URL="https://www.youtube.com"},
                new WebsiteInfo(){ContentLength=0,WebsiteContent="",URL=extraInputURL}
            };
            //Use of Reference type variable => "without the new keyword" 
            foreach (WebsiteInfo item in inputURLs)
            {
                obj.DownLoadWebsiteContent(item);
                textBox1.Text += obj.FormatTheWebSiteContent(item);
            }
            return "It is the return from the Method";
        }
    */
    }
}
