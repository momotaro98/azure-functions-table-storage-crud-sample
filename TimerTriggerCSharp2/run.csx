#r "Microsoft.WindowsAzure.Storage"

using Microsoft.WindowsAzure.Storage.Table;
using System;

public static void Run(TimerInfo myTimer,IQueryable<SampleTable> inputTable, TraceWriter log)
{    
    // Query from the Table
    SampleTable user = inputTable.Where(u => u.UserId == "user1").ToList().FirstOrDefault();
    log.Info($"User Name: {user.UserName}");   
}

public class SampleTable : TableEntity
{
    public string UserId { get; set; }
    public string UserName { get; set; }
}