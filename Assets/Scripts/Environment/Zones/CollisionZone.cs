using UnityEngine;
using System.Collections;

public class CollisionZone : Zone {
	protected override void DoOnCollisionEnterForOthers(Collision2D col)	
	{
		Physics2D.IgnoreCollision (gameObject.GetComponent<Collider2D>(), col.collider);
	}
}
