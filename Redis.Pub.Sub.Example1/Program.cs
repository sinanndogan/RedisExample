using StackExchange.Redis;

ConnectionMultiplexer redis = await ConnectionMultiplexer.ConnectAsync("localhost:yourlocalhost");



ISubscriber subscriber=redis.GetSubscriber();


while (true)
{
    Console.Write("Mesaj : ");
    string message =Console.ReadLine();
    subscriber.PublishAsync("mychannel",message);
}