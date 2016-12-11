using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActivateableUI : MonoBehaviour {

    public Activateable activateable;

    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = activateable.ToString();
    }
}
