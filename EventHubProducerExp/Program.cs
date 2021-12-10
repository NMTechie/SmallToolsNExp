using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;

namespace EventHubProducerExp
{
    class Program
    {

        // connection string to the Event Hubs namespace
        private const string connectionString = "Endpoint=sb://nilesheventhubexp.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=gDJqP7AFf6ifRKka88zNgrQT8mwDkdp+w75KHW2Q2do=";

        // name of the event hub
        private const string eventHubName = "evthub1";

        // number of events to be sent to the event hub
        private const int numOfEvents = 3;

        // The Event Hubs client types are safe to cache and use as a singleton for the lifetime
        // of the application, which is best practice when events are being published or read regularly.
        static EventHubProducerClient producerClient;


        static async Task Main()
        {
            // Create a producer client that you can use to send events to an event hub
            producerClient = new EventHubProducerClient(connectionString, eventHubName);
            try
            {
                string userInput;
                while (true)
                {
                    Console.WriteLine("Please provide the message input");
                    userInput = Console.ReadLine();
                    if (userInput.Trim().ToUpper().Equals("EXIT"))
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Getting the partition count................");
                        var partitions = await producerClient.GetPartitionIdsAsync();
                        Console.WriteLine($"Total Numer  of Partition is {partitions.Length}");
                        //
                        Random choosingPartitionMock = new Random();
                        SendEventOptions eventOptions = new SendEventOptions() { PartitionId = choosingPartitionMock.Next(0, partitions.Length).ToString() };
                        //
                        using EventDataBatch eventBatch = await producerClient.CreateBatchAsync();
                        if (!eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes(userInput))))
                        {
                            // if it is too large for the batch
                            throw new Exception($"{userInput} ------> is too large for the batch and cannot be sent.");
                        }
                        //
                        await producerClient.SendAsync(eventBatch);
                        Console.WriteLine("Events has been published.");
                    }
                }
            }
            finally
            {
                await producerClient.DisposeAsync();
            }
        }

        private static string constructEventData()
        {
            return string.Empty;
        }
    }
}
