﻿using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public class Player : MonoBehaviour
{
    public Activateable mouseLeft;
    public Activateable mouseRight;

    public Health health;

    void Start()
    {
        health = GetComponent<Health>();
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.right = mousePosition - transform.position;

        Act();
    }

    private void Act()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mouseLeft.Act();
        }

        if (Input.GetMouseButtonDown(1))
        {
            mouseRight.Act();
        }
    }
}