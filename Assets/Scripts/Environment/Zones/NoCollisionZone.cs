using UnityEngine;
using System.Collections;

public class NoCollisionZone : Zone {
	protected override void DoOnEnterForTags(Collider2D col)	
	{
		Physics2D.IgnoreCollision (gameObject.GetComponent<Collider2D>(), col);
	}
}
