using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoldableBehavior : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("BONK! from towel");
    }
}
