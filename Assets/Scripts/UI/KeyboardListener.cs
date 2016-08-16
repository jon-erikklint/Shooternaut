using UnityEngine;
using System.Collections;

public class KeyboardListener : MonoBehaviour {

	void Update () {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
