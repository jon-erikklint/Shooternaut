using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayMapButton : MonoBehaviour {

    private Dropdown choice;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SelectMap);

        choice = FindObjectOfType<Dropdown>();
    }

    public void SelectMap()
    {
        SceneManager.LoadScene(choice.value+2);
    }
}
