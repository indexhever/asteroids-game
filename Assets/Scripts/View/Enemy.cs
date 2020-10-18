using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDisposable
{
    public void Dispose()
    {
        gameObject.SetActive(false);
    }
}
