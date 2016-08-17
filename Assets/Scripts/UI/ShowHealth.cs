using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowHealth : MonoBehaviour {

    private HealthInterface health;

    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
        health = FindObjectOfType<Player>().GetComponent<HealthInterface>();
    }

    void Update()
    {
        text.text = health.ToString();
    }
}
