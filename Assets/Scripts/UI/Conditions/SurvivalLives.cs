using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SurvivalLives : MonoBehaviour {

    public Survival survival;

    private Text text;

	void Start () {
        text = GetComponent<Text>();
	}
	
	
	void Update () {
        text.text = "Lives: "+survival.lives;
	}
}
