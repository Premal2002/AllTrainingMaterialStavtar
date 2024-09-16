// See https://aka.ms/new-console-template for more information
using Serialization_Demo;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

//Console.WriteLine("Hello, World!");

#region Serialization
//Accounts accounts = new Accounts() 
//{ 
//    AccountNumber = 103, 
//    Accountbalance=10000, 
//    AccountName = "Saurabh", 
//    AccountIsActive=true,
//    AccountType = "PF" 
//};

//FileStream myFile = new FileStream(accounts.AccountNumber + ".xml",FileMode.Create,FileAccess.Write);
////BinaryFormatter bf = new BinaryFormatter();  --deprecated

////JsonSerializer for jSON format

////use serialize method to store and use deserialize method to open or bring the object
//XmlSerializer serializer = new XmlSerializer(typeof(Accounts));
//serializer.Serialize(myFile, accounts);
//myFile.Close();
//Console.WriteLine("Object serialized");

//List<Accounts> list = new List<Accounts>() 
//{ 
//    new Accounts(){AccountNumber = 101,Accountbalance=10000, AccountName = "Saurabh",AccountIsActive=true,AccountType = "PF" },
//    new Accounts(){AccountNumber = 102,Accountbalance=10000, AccountName = "Premal",AccountIsActive=true,AccountType = "Saving" },
//    new Accounts(){AccountNumber = 103,Accountbalance=10000, AccountName = "Sammer",AccountIsActive=true,AccountType = "Current" }
//};

//FileStream fileStream = new FileStream("myAccounts.json", FileMode.Create,FileAccess.Write);
//XmlSerializer serializer = new XmlSerializer(typeof(List<Accounts>));
//serializer.Serialize(fileStream, list);

//fileStream.Close();
//Console.WriteLine("All accounts saved to the file");



//string serializedData = JsonSerializer.Serialize(list);
//File.WriteAllText("myAccounts.json",serializedData);

//JsonSerializer.Serialize(fileStream, list);
//fileStream.Close();
#endregion


#region Deserialization

//Accounts acc;
//FileStream file = new FileStream("101.xml",FileMode.Open,FileAccess.Read);

//XmlSerializer serializer = new XmlSerializer(typeof(Accounts));

//acc = (Accounts)serializer.Deserialize(file);

//Console.WriteLine(acc.Accountbalance + " "+acc.AccountName);
//file.Close();

List<Accounts> list = new List<Accounts>();
FileStream file = new FileStream("myAccounts.json", FileMode.Open, FileAccess.Read);

//XmlSerializer serializer = new XmlSerializer(typeof(List<Accounts>));

//list = (List<Accounts>)serializer.Deserialize(file);


//JSON Deserialization
list = JsonSerializer.Deserialize<List<Accounts>>(File.ReadAllText("myAccounts.json"));


foreach (var item in list) 
{
    Console.WriteLine("Account Number : "+item.AccountName);
    Console.WriteLine("Account name : " + item.AccountName);
    Console.WriteLine("Account Type : " + item.AccountType);
    Console.WriteLine("Account Balance : " + item.Accountbalance);
    Console.WriteLine("Account IsActive : " + item.AccountIsActive);
    Console.WriteLine("----------------------------------------------");
}

file.Close();
#endregion

