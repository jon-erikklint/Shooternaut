using UnityEngine;
using System.Collections;

public class Destroyable : MonoBehaviour {

	public virtual void DestroySelf()
    {
        Destroy(this.gameObject);
    }

    public void DestroySelf(float time)
    {
        Invoke("DestroySelf", time);
    }
}
