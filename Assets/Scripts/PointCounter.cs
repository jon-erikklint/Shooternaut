using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour {

    public int points { get { return _points; } }
    public int balls;

    private int _points;

    private Text text;
	
	void Start () {
        balls = 0;
        _points = 0;

        text = GetComponent<Text>();
	}
	
	void Update () {
        float elapsed = Time.deltaTime;

        Debug.Log(elapsed);
        Debug.Log(points);

        _points += (int) (elapsed * (Math.Pow(2, balls)-1) * 1000);

        text.text = ""+points;
	}
}
