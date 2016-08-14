using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Gun : MonoBehaviour {

    public Projectile projectile;
    public GameObject owner;
    public UnityEvent onShoot;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Shoot()
    {
        onShoot.Invoke();
    }
}
