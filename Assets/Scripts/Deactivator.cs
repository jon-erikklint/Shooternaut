using UnityEngine;
using System.Collections;

public class Deactivator: MonoBehaviour{

    public void ActivateGameobject(GameObject gameObject, Vector3 startingPosition, float rotation, Vector3 startVelocity)
    {
        SetGameObject(gameObject, true);

        gameObject.transform.position = startingPosition;

        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.rotation = rotation;
        rb.velocity = startVelocity;
    }

    public void DeactivateGameObject(GameObject gameObject)
    {
        SetGameObject(gameObject, false);
    }

	public void SetGameObject(GameObject gameObject, bool active)
    {
        ActivateRigidbody(gameObject.GetComponent<Rigidbody2D>(), active);
        ActivateCollider(gameObject.GetComponent<Collider2D>(), active);
        ActivateRenderer(gameObject.GetComponent<Renderer>(), active);
        ActivateChildren(gameObject.transform, active);
    }

    private void ActivateRigidbody(Rigidbody2D rb, bool active)
    {
        if(rb == null)
        {
            return;
        }

        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;

        rb.isKinematic = !active;
    }

    private void ActivateCollider(Collider2D col, bool active)
    {
        if(col == null)
        {
            return;
        }

        col.enabled = active;
    }

    private void ActivateRenderer(Renderer r, bool active)
    {
        if(r == null)
        {
            return;
        }

        r.enabled = active;
    }

    private void ActivateChildren(Transform t, bool active)
    {
        for(int i = 0; i < t.childCount; i++)
        {
            GameObject child = t.GetChild(i).gameObject;
            child.SetActive(active);
        }
    }
}
