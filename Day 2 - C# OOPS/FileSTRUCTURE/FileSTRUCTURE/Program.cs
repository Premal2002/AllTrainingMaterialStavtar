

//File Structure

#region Write File-1
//FileStream file = new FileStream("test.txt",FileMode.Create,FileAccess.Write);

//StreamWriter writer = new StreamWriter(file);

//try
//{
//    writer.WriteLine("Hello welcome Prem!");
//    writer.WriteLine("I love to watch sport animes");
//}
//catch(Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
//finally { 
//    writer.Close(); 
//    file.Close();
//}
#endregion

#region Write File-2
//Console.WriteLine("Enter your name");
//string name = Console.ReadLine();

//bool moreDetails = true;

//FileStream file = new FileStream(name+".txt",FileMode.Create,FileAccess.Write);
//StreamWriter writer = new StreamWriter(file);

//Console.WriteLine("Enter details about you and type END when you done");
//while (moreDetails)
//{
//    string details = Console.ReadLine();

//    if(details == "END")
//    {
//        moreDetails = false;
//    }

//    writer.WriteLine(details);
//}

//writer.Close();
//file.Close();


#endregion

#region Read File

FileStream file = new FileStream("Prem.txt",FileMode.Open,FileAccess.Read);
StreamReader sr = new StreamReader(file);

Console.WriteLine(sr.ReadToEnd());
#endregion