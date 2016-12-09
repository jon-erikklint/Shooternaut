using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag.Equals("Player"))
        {
            col.gameObject.GetComponent<Player>().Destroy();
        }
    }
}
