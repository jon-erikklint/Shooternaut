using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Zone: MonoBehaviour {
	public List<string> tags;

	protected virtual void DoOnCollisionEnterForTags(Collision2D col) {}
	protected virtual void DoOnCollisionEnterForOthers(Collision2D col) {}
	protected virtual void DoOnCollisionExitForTags(Collision2D col) {}
	protected virtual void DoOnCollisionExitForOthers(Collision2D col) {}
	protected virtual void DoOnCollisionStayForTags(Collision2D col) {}
	protected virtual void DoOnCollisionStayForOthers(Collision2D col) {}

	void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log ("moi");
		if (tags.Contains (col.gameObject.tag)) {
			DoOnCollisionEnterForTags (col);
		} else {
			DoOnCollisionEnterForOthers (col);
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (tags.Contains (col.gameObject.tag)) {
			DoOnCollisionExitForTags (col);
		} else {
			DoOnCollisionExitForOthers (col);
		}
	}
}
