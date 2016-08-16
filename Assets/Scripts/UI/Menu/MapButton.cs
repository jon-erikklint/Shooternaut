using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapButton : MonoBehaviour {

    private Button button;
    private Text text;

    private Dropdown choice;

    void Start()
    {
        button = GetComponent<Button>();
        text = GetComponentInChildren<Text>();
        
        button.onClick.AddListener(SelectMap);

        choice = FindObjectOfType<Dropdown>();
    }

    public void SelectMap()
    {
        SceneManager.LoadScene(choice.value+1);
    }
}
