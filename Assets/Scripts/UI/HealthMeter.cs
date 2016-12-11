using UnityEngine;
using System.Collections;

public class HealthMeter : MonoBehaviour {

    public HealthInterface health;

    private float maxWidth;
    private float height;

    private RectTransform meter;

    void Start()
    {
        meter = transform.FindChild("Amount").GetComponent<RectTransform>();
        maxWidth = meter.rect.width;
        height = meter.rect.height;
    }

    void Update()
    {

        float multiplier = health.HealthPercentage();

        meter.sizeDelta = new Vector2(maxWidth * multiplier, height);
    }
}
