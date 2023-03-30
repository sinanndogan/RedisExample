using StackExchange.Redis;

ConnectionMultiplexer redis= await ConnectionMultiplexer.ConnectAsync("localhost:1453");


ISubscriber subscriber=redis.GetSubscriber();

//bir publisher ürettik mesaj girilen mesajı subs'lara dağıtacak
while (true)
{
    Console.Write("Message : ");
    string message=Console.ReadLine();
    await subscriber.PublishAsync("mychannel", message);
}