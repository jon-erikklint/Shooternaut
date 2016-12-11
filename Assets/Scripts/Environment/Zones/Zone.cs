using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Zone: MonoBehaviour {
	public List<string> tags;

	protected virtual void DoOnEnterForTags(Collider2D col) {}
	protected virtual void DoOnEnterForOthers(Collider2D col) {}
	protected virtual void DoOnExitForTags(Collider2D col) {}
	protected virtual void DoOnExitForOthers(Collider2D col) {}
	protected virtual void DoOnStayForTags(Collider2D col) {}
	protected virtual void DoOnStayForOthers(Collider2D col) {}

	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log ("moi");
		if (tags.Contains (col.gameObject.tag)) {
			DoOnEnterForTags (col);
		} else {
			DoOnEnterForOthers (col);
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (tags.Contains (col.gameObject.tag)) {
			DoOnExitForTags (col);
		} else {
			DoOnExitForOthers (col);
		}
	}
}
