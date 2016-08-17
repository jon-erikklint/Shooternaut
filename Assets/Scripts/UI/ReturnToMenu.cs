using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour {

	void Start () {
        GetComponent<Button>().onClick.AddListener(ReturnMenu);
	}
	
	public void ReturnMenu () {

        SceneManager.LoadScene(0);

	}
}
