namespace Exercisse6140425
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Stack<string>> users = new Dictionary<string, Stack<string>>();
            string info = Console.ReadLine();
            List<string> output = new List<string>(); 
            while (!info.Equals("EXIT"))
            {
                
                string[] commands = info.Split(' ').ToArray();
                if (commands[0].Equals("ADD"))
                {
                    if (users.ContainsKey(commands[1]))
                    {
                        users[commands[1]].Push(commands[2]);
                    }
                    else
                    {
                        users.Add(commands[1], new Stack<string>());
                        users[commands[1]].Push(commands[2]);
                    }
                    string k = $"{commands[1]} visited {commands[2]}";
                    output.Add(k);
                }else if (commands[0].Equals("BACK"))
                {
                    if (users.ContainsKey(commands[1]))
                    {
                        if(users[commands[1]].TryPop(out string removedItem))
                        {
                            string k = $"{commands[1]} is back from {removedItem}";
                            output.Add(k);
                        }
                    }    
                }else if (commands[0].Equals("HISTORY"))
                {
                    if (users[commands[1]].Count > 0)
                    {
                        string k = $"{commands[1]}'s history:";
                        output.Add(k);
                        foreach(string h in users[commands[1]])
                        {
                            output.Add($"> {h}");
                        }
                    }
                }

                info = Console.ReadLine();


            }
            foreach(string p in output)
            {
                Console.WriteLine(p);
            }
        }
    }
}
