using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Tuple<T1, T2>: object
{
    public T1 _1;
    public T2 _2;
}

public class Tuple<T1, T2, T3>
{
    public T1 _1 { get; set; }
    public T2 _2 { get; set; }
    public T3 _3 { get; set; }
}

public class Tuple<T1, T2, T3, T4>
{
    public T1 _1 { get; set; }
    public T2 _2 { get; set; }
    public T3 _3 { get; set; }
    public T4 _4 { get; set; }
}
