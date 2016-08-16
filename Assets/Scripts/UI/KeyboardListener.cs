using UnityEngine;
using System.Collections;

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
    }
}
