using System.IO;

internal class Program()
{
    public static void Main(string[] args)
    {
        list<list<string>> myList = new list<list<string>>();

    using (var reader = new StreamReader(userDetails.txt))
    {
        console.writeline("hello");
        while(!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(",");
            myList.add(values);
        }

    }
    for(int i =0; i<myList.length(); i++)
    {
        for (int j=0; j<myList[i].count(); j++)
        {
            console.writeline(myList[i][j]);
        }
    }
        


    }

}
