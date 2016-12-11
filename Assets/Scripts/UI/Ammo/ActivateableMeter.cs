using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActivateableMeter : MonoBehaviour {

    public Activateable activateable;

    private RectTransform meter;
    private float maxWidth;
    private float height;
    private float y;

    void Start () {
        meter = transform.FindChild("Amount").GetComponent<RectTransform>();
        maxWidth = meter.rect.width;
        height = meter.rect.height;
        y = meter.localPosition.y;
	}
	
	void Update () {

        float multiplier = activateable.ActivateAmount();

        float newWidth = maxWidth * multiplier;

        meter.sizeDelta = new Vector2(newWidth, height);
        meter.localPosition = new Vector3((newWidth - maxWidth) / 2, y);
    }
}
