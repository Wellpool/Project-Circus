using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool hasKey = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            hasKey = !hasKey;
    }
}
