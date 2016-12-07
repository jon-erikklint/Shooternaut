using UnityEngine;
using System.Collections;

public abstract class Laser : MonoBehaviour {

    public Vector3 startPosition = Vector3.zero;
    public Vector3 facingDirection = Vector3.zero;

    public float laserWidth;

    private LineRenderer lr;

	void Start () {
        lr = GetComponent<LineRenderer>();

        lr.SetWidth(laserWidth, laserWidth);
	}

    private RaycastHit2D Hit()
    {
        return Physics2D.Raycast(startPosition, facingDirection, 1000);
    }
	
	void FixedUpdate () {
        RaycastHit2D hit = Hit();

        OnHit(hit);
	}

    void Update()
    {
        UpdateLineRenderer(Hit().point);
    }

    private void UpdateLineRenderer(Vector3 endPoint)
    {
        endPoint *= (endPoint.magnitude + laserWidth) / endPoint.magnitude;

        Vector3[] positions = { startPosition, endPoint };
        lr.SetPositions(positions);
    }

    public abstract void OnHit(RaycastHit2D hit);
}
