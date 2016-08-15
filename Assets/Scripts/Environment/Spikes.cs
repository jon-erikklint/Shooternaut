using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

    private GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

	void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag.Equals("Player"))
        {
            col.gameObject.GetComponent<Player>().health.Die();
        }
    }
}
