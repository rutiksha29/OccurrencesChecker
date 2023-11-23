using System;
using System.Collections.Generic;
using System.Linq;

class OccurrencesChecker
{
    private Dictionary<int, int> freqQuery;

    public OccurrencesChecker()
    {
        freqQuery = new Dictionary<int, int>();
    }

    public void Insert(int x)
    {
        if (freqQuery.ContainsKey(x))
        {
            freqQuery[x]++;
        }
        else
        {
            freqQuery[x] = 1;
        }
    }

    public void Delete(int y)
    {
        if (freqQuery.ContainsKey(y) && freqQuery[y] > 0)
        {
            freqQuery[y]--;
        }
    }

    public int CheckFrequency(int z)
    {
        return freqQuery.ContainsValue(z) ? 1 : 0;
    }
}


class Program
{
    static void Main()
    {
        OccurrencesChecker occurrencesChecker = new();

        Console.WriteLine("Enter the number of queries:");
        int q = int.Parse(Console.ReadLine());

        int[][] queries = new int[q][];

        for (int i = 0; i < q; i++)
        {
            Console.WriteLine($"Enter query {i + 1} :");
            queries[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }
        Console.WriteLine("Result :\n ");
        foreach (var query in queries)
        {
            int operation = query[0];
            if (query.Length > 1)
            {
                switch (operation)
                {
                    case 1:
                        occurrencesChecker.Insert(query[1]);
                        break;
                    case 2:
                        occurrencesChecker.Delete(query[1]);
                        break;
                    case 3:
                        Console.WriteLine(occurrencesChecker.CheckFrequency(query[1]));
                        break;
                }
            }
        }
    }
}
