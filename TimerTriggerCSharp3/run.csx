#r "Microsoft.WindowsAzure.Storage"

using Microsoft.WindowsAzure.Storage.Table;
using System;

public static void Run(TimerInfo myTimer,IQueryable<SampleTable> inputTable, CloudTable outputTable, TraceWriter log)
{    
    // Query from the Table
    SampleTable user = inputTable.Where(u => u.UserId == "user1").ToList().FirstOrDefault();

    // Update the Entity
    user.UserName = "urashimataro"; // Change UserName column
    var updateOperation = TableOperation.Replace(user);
    outputTable.Execute(updateOperation);

    // Delete the Entity
    var deleteOperation = TableOperation.Delete(user);
    outputTable.Execute(deleteOperation);
}

public class SampleTable : TableEntity
{
    public string UserId { get; set; }
    public string UserName { get; set; }
}