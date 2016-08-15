using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {

    public Player player;

    void Start()
    {
        if(player == null)
        {
            player = FindObjectOfType<Player>();
        }
        
        UnityEvent playerDies = player.GetComponent<Health>().onDeath;
        playerDies.AddListener(GameOver);
    }

	public void GameOver ()
    {
        Debug.Log("Game Over!");
        SceneManager.LoadScene(0);
    }
}
