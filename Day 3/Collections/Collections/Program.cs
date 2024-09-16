// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System.Collections;

#region Arrays

//string[] friends = new string[5];
//friends[0] = "Nikhil";
//friends[1] = "Adarsh";
//friends[2] = "Ganesh";
//friends[3] = "Pratik";
//friends[4] = "Sammer";

//for(int i = 0; i < 5; i++)
//{
//    Console.WriteLine(friends[i]);
//}
#endregion

#region ArrayList
//No fixed size and no fixed data type

//it has to do boxing and unboxing


//ArrayList myList = new ArrayList();
//myList.Add(1);
//myList.Add("Prem");
//myList.Add('A');

//foreach (var i in myList)
//{
//    Console.WriteLine(i);
//}
#endregion

#region List
//no fixed sixe but for a fixed data
//List<string> list = new List<string>();

//list.Add("Prem");
//list.Add("DJ");
//list.Add("Ganesh");
//list.Add("Nikhil");

//foreach (string i in list)
//{
//    Console.WriteLine(i);
//}

#endregion

#region Key-value pair types

//There are 2 types
//1. HashTable, which is no fix datatype and size same like ArrayList

//Hashtable myHashtable = new Hashtable();

//myHashtable.Add(1, "Prem");
//myHashtable.Add('A', true);
//myHashtable.Add(false, 22);
//myHashtable.Add(55, "Raj");

////Console.WriteLine(myHashtable.Keys + " " + myHashtable.Values);

//Console.WriteLine(myHashtable[1]);  //Here 1 means a key from defined table
#endregion

#region Dictionary
Dictionary<int,string> map = new Dictionary<int,string>();

//map.Add(1, "Prem");
//map.Add(2, "Pratik");
//map.Add(3, "Dj");
//map.Add(4, "Ganesh");

//foreach (var item in map)
//{
//    Console.WriteLine(item.Key + ": " + item.Value);
//}
#endregion

#region try-Error Test
try
{
    //int a = Convert.ToInt32(Console.ReadLine());
    string str = Console.ReadLine();
    //bool b = Convert.ToBoolean(Console.ReadLine());
    //double d = Convert.ToDouble(Convert.ToInt32(Console.ReadLine()));
    //DateTime dt = Convert.ToDateTime(Console.ReadLine());

    Console.WriteLine("{0},{1},{2},{3},{4}", str);
}
catch ( Exception ex )
{ Console.WriteLine("Pleae enter int"); }



#endregion