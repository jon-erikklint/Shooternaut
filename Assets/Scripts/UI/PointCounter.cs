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
        FindObjectOfType<Player>().GetComponent<Health>().onDamageTaken.AddListener(ballRemoved);

        balls = 0;
        _points = 0;

        text = GetComponent<Text>();
    }
	
	void Update () {
        float elapsed = Time.deltaTime;

        _points += (int) (elapsed * (Math.Pow(2, balls)-1)*100);

        text.text = ""+points;
	}

    public void ballRemoved()
    {
        balls--;
    }
}
