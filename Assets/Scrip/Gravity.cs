using System;
using System.Collections.Generic;
using UnityEngine;
public class Gravity : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.006674f;
    public static List<Gravity> otherObjectList;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (otherObjectList == null)
        {
            otherObjectList = new List<Gravity>();
        }
        otherObjectList.Add(this);
    }

    private void FixedUpdate()
    {
        foreach (Gravity obj in otherObjectList)
        {
            if (obj != this)
            {
                Attract(obj);
            }
        }
    }
    void Attract(Gravity other)
    {
        Rigidbody otherRb = other.rb;

        Vector3 direction = rb.position - otherRb.position;
        float distance = direction.magnitude;
        if (distance == 0f) { return; }
        float forceMagnitude = G * (rb.mass * otherRb.mass) / Mathf.Pow(distance, 2);
        Vector3 gravityForce = forceMagnitude * direction.normalized;

        otherRb.AddForce(gravityForce);
    }
}

