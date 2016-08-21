using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GunUI : MonoBehaviour {

    public GunController gun;

    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = gun.ToString();
    }
}
