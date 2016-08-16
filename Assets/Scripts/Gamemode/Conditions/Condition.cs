using UnityEngine;
using System.Collections;

public interface Condition{

    void Begin();
    void End();

    string Name();
    string Description();

    bool Lost();
}
