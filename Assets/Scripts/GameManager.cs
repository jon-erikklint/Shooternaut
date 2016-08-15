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
        playerDies.AddListener(Defeat);
    }

    public void Victory()
    {
        Debug.Log("Victory!");
        SceneManager.LoadScene(0);
    }

	public void Defeat ()
    {
        Debug.Log("Game Over!");
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
