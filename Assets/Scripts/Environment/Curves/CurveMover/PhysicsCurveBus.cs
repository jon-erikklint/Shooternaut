using UnityEngine;
using System.Collections;

public class PhysicsCurveBus : CurveBus {

	public float friction = 0;

	// Update is called once per frame
	void Update () {
		MoveGameObjects ();
	}

	private void MoveGameObjects()
	{
		for (int i = 0; i < gameObjects.Count; i++) 
		{
			GameObject gameObj = gameObjects [i];
			Vector3 pos = gameObj.transform.position;
			Rigidbody2D rb = gameObj.GetComponent<Rigidbody2D> ();
			float x = XAtPoint (pos);
			gameObj.transform.position = GlobalPointAt (x);
			if (x - 0.001f < 0 || x + 0.001f > curve.length)
				rb.velocity = Vector3.zero;
			else 
			{
				Vector3 tangent = (PointAt (x + 0.001f) - PointAt (x - 0.001f)).normalized;
				rb.velocity = Vector3.Dot (rb.velocity, tangent) * tangent;
			}
		}
	}
}
