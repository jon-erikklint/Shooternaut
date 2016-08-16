using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpeedrunClock : MonoBehaviour {

    public Speedrun speedrun;

    private Text text;

	void Start () {
        text = GetComponent<Text>();
	}
	
	void Update () {
        string time = speedrun.TimeLeft().ToString("0.00");

        text.text = "Time left: "+time;
	}
}
