using System.Net;

public static void Run(TimerInfo myTimer, ICollector<SampleTable> outputTable, TraceWriter log)
{
    log.Info($"C# Timer trigger function executed at: {DateTime.Now}");

    // RowKeyの重複回避のためランダムな文字列を生成する
    Random random = new Random();
    string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    string randomStr = new string(Enumerable.Repeat(chars, 32)
        .Select(s => s[random.Next(s.Length)]).ToArray());

    // SampleTableへEntity(レコード)登録
    outputTable.Add(
        new SampleTable() { 
            PartitionKey = "PremiumUser",
            RowKey = randomStr,
            UserId = "user1",
            UserName = "momotaro" }
        );
}

public class SampleTable
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public string UserId { get; set; }
    public string UserName { get; set; }
}