using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {

    public Player player;
    public Gamemode gamemode;
    public RespawnManager respawnManager;

    public RespawnPoint start;

    void Start()
    {
        if(player == null)
        {
            player = FindObjectOfType<Player>();
        }

        if(gamemode == null)
        {
            gamemode = FindObjectOfType<Gamemode>();
        }

        if(respawnManager == null)
        {
            respawnManager = FindObjectOfType<RespawnManager>();
        }

        respawnManager.SetSpawnpoint(start);

    }

    public void Reset()
    {
        Debug.Log("Resetted!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Victory()
    {
        Debug.Log("Victory!");
        SceneManager.LoadScene(1);
    }

	public void Defeat ()
    {
        Debug.Log("Loser!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        if (!gamemode.hasStarted)
        {
            return;
        }

        if (gamemode.Victory())
        {
            Victory();
        }

        if (gamemode.Defeat())
        {
            Defeat();
        }
    }
}
