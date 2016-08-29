using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public interface Respawnable {

    List<object> RespawnPointReached(RespawnPoint respawn);

    void Respawn(List<object> lastState);

}
