using UnityEngine;
using System.Collections;

public class Destroyable : MonoBehaviour {

	public virtual void Destroy()
    {
        Destroy(this.gameObject);
    }

    public void Destroy(float time)
    {
        Invoke("Destroy", time);
    }
}
