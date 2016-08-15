using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            gameManager.GameOver();
        }
    }
}
