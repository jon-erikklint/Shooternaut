using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class MapOptions : MonoBehaviour {

    public List<string> sceneNames;

    private Dropdown dropdown;

	void Start ()
    {
        dropdown = FindObjectOfType<Dropdown>();

        dropdown.AddOptions(sceneNames);
	}
}
