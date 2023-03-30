using StackExchange.Redis;

ConnectionMultiplexer redis = await ConnectionMultiplexer.ConnectAsync("localhost:1453");


ISubscriber subscriber = redis.GetSubscriber();

//subscriber oluştururak publis edilen mesajları almayı amacladık

await subscriber.SubscribeAsync("mychannel", (channel, message) =>
{
    Console.WriteLine(message);
});

Console.Read();