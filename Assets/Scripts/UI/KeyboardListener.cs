using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class KeyboardListener : MonoBehaviour {

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            FindObjectOfType<GameManager>().Reset();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            FindObjectOfType<RespawnManager>().TryRespawn(null);
        }
    }
}
