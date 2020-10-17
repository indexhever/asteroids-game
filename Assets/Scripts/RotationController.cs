using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    private float turn = 1;

    [SerializeField]
    private Rigidbody2D objectRigidbody;
    [SerializeField]
    public float torque;

    public void Left()
    {
        Debug.Log("Left");
        turn = 1;
        AddRotation();
    }

    public void Right()
    {
        Debug.Log("Right");
        turn = -1;
        AddRotation();
    }

    private void AddRotation()
    {
        objectRigidbody.AddTorque(torque * turn);
    }
}
