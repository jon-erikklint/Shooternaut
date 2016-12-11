using UnityEngine;
using System.Collections;

public class NoCollisionZone : Zone {
	protected override void DoOnCollisionEnterForTags(Collision2D col)	
	{
		Physics2D.IgnoreCollision (gameObject.GetComponent<Collider2D>(), col.collider);
	}
}
