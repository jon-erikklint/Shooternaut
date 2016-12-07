using UnityEngine;
using System.Collections;

public interface Objective{

    void Begin();

    string Name();
    string Description();

    bool Achieved();
}
