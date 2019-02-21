using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util {

    public static string PrintList<T>(List<T> list)
    {
        return String.Join(", ",
                 list
                 .ConvertAll(i => i.ToString())
                 .ToArray());
    }
}
