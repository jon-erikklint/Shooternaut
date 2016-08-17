using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class KeyboardListener : MonoBehaviour {

	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.R))
        {
            FindObjectOfType<GameManager>().Reset();
        }

        if (Input.GetKey(KeyCode.M))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            FindObjectOfType<RespawnManager>().TryRespawn();
        }
    }
}
