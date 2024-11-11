
using Newtonsoft.Json;

public class SpendingManager (List<Spending> spending)
{
    List<Spending> ManagerSpending = spending;

    public void AddSpending(Spending spending)
    {
     
    }
        public void AddSpendingList()
    {
        string filePath = "Spendings_payments.txt";
        string addJson = JsonConvert.SerializeObject(ManagerSpending);
        File.WriteAllText(filePath, addJson);
    }

    public void GetSpendingList()
    {
        string filePath = "Spendings_payments.txt";
        string x = File.ReadAllText(filePath);
        List<Spending>? getJson = JsonConvert.DeserializeObject<List<Spending>>(x);
        
        System.Console.WriteLine($"XXXXXXXXXX{getJson}XXXXXXXXXX");
    } 
}