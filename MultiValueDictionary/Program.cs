using System;
using System.Collections.Generic;
using System.Threading;

namespace MultiValueDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> keyValues = new Dictionary<string, List<string>>();
            Console.Write(">");
            GetCommand(Console.ReadLine(), keyValues);  
        }

        //Function to add/remove key value pairs to dictionary and retrieve items from dictionary
        public static void GetCommand(string input, Dictionary<string, List<string>> keyValues)
        {
            string[] splitValue = input.Split(' '); // splitting the input by spaces
            try
            {
                if (input.StartsWith("ADD ", StringComparison.OrdinalIgnoreCase))
                {
                    if (keyValues.ContainsKey(splitValue[1]))
                    {
                        if (keyValues[splitValue[1]].Contains(splitValue[2]))
                        {
                            Console.WriteLine("ERROR, value already exists");
                        }
                        else
                        {
                            keyValues[splitValue[1]].Add(splitValue[2]);
                        }
                    }
                    else
                    {
                        keyValues.Add(splitValue[1], new List<string>() { splitValue[2] });
                    }
                    Console.WriteLine(") Added");
                }
                else if (input.StartsWith("REMOVE ", StringComparison.OrdinalIgnoreCase))
                {


                    if (keyValues[splitValue[1]].Contains(splitValue[2]))
                    {
                        keyValues[splitValue[1]].Remove(splitValue[2]);
                        Console.WriteLine(") Removed");
                    }
                    else
                    {
                        Console.WriteLine("ERROR, value does not exist");
                    }

                }
                else if (input.StartsWith("REMOVEALL", StringComparison.OrdinalIgnoreCase))
                {
                    if (keyValues.ContainsKey(splitValue[1]))
                    {
                        keyValues.Remove(splitValue[1]);
                        Console.WriteLine(") Removed");
                    } else
                    {
                        Console.WriteLine("ERROR, key does not exist");
                    }
                }
                else if (input.StartsWith("CLEAR", StringComparison.OrdinalIgnoreCase))
                {
                    keyValues.Clear();
                    Console.WriteLine(") Cleared");
                }
                else if (input.StartsWith("KEYS", StringComparison.OrdinalIgnoreCase))
                {
                    if (keyValues.Count > 0)
                    {
                        foreach (var key in keyValues.Keys)
                        {
                            Console.WriteLine(key);
                        }
                    }
                    else
                    {
                        Console.WriteLine("(empty set)");
                    }
                }
                else if (input.StartsWith("MEMBERS", StringComparison.OrdinalIgnoreCase))
                {
                    List<string> res = new List<string>();

                    keyValues.TryGetValue(splitValue[1], out res);

                    if (res != null)
                    {
                        // For Wriring all members of a key
                        foreach (var r in res)
                        {
                            Console.WriteLine(r);
                        }
                    }
                    else
                    {
                        Console.WriteLine("ERROR, key does not exist.");
                    }

                }
                else if (input.StartsWith("KEYEXISTS", StringComparison.OrdinalIgnoreCase))
                {

                    if (keyValues.ContainsKey(splitValue[1]))
                        Console.WriteLine("true");
                    else
                        Console.WriteLine("false");
                }
                else if (input.StartsWith("VALUEEXISTS", StringComparison.OrdinalIgnoreCase))
                {
                    if (keyValues[splitValue[1]].Contains(splitValue[2]))
                        Console.WriteLine("true");
                    else
                        Console.WriteLine("false");
                }
                else if (input.StartsWith("ALLMEMBERS", StringComparison.OrdinalIgnoreCase))
                {
                    if (keyValues.Count > 0)
                    {
                        foreach (var key in keyValues)
                        {
                            if (key.Value.Count > 0)
                            {
                                foreach (var val in key.Value)
                                {
                                    Console.WriteLine(val);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("(empty set)");
                    }
                }
                else if (input.StartsWith("ITEMS", StringComparison.OrdinalIgnoreCase))
                {
                    if (keyValues.Count > 0)
                    {
                        foreach (var key in keyValues)
                        {
                            Console.WriteLine(key.Key);
                        }
                    }
                    else
                    {
                        Console.WriteLine("(empty set)");
                    }
                }
                else if (input.StartsWith("EXIT", StringComparison.OrdinalIgnoreCase))
                {
                    Environment.Exit(1);
                }
                else
                {
                    Console.WriteLine("Please enter correct command");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            Console.Write(">");
            GetCommand(Console.ReadLine(), keyValues);
        }
    }
}
