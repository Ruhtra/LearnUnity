using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Methods : MonoBehaviour
{
    public static List<T> CreateList<T>(int capicity) => Enumerable.Repeat(default(T), capicity).ToList();


    public static void UpgradeCheck<T>(List<T> list, int length) where T : new()
    {
        try
        {
            if (list.Count == 0) list = CreateList<T>(length);
            while (list.Count < length)
            {
                list.Add(new T());
            }

        }
        catch
        {

            list = CreateList<T>(length);
        }
    }
}
