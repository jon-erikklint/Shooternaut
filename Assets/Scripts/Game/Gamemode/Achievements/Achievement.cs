using UnityEngine;
using System.Collections;

public interface Achievement {

    void Begin();
    void End();

    string Name();
    string Description();

    bool Fulfilled();
}
