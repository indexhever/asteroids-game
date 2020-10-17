using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D objectRigidbody;
    [SerializeField]
    private float thrust; // 50 is 1 unit per second
    [SerializeField]
    private float maxSpeed;

    public void AddForce()
    {
        objectRigidbody.AddForce(transform.up * thrust);
    }

    public void FixedUpdate()
    {
        LimitSpeedToMaximumAllowed();        
    }

    private void LimitSpeedToMaximumAllowed()
    {
        if (Mathf.Abs(objectRigidbody.velocity.x) > maxSpeed || Mathf.Abs(objectRigidbody.velocity.y) > maxSpeed)
        {
            // clamp velocity:
            Vector3 newVelocity = objectRigidbody.velocity.normalized;
            newVelocity *= maxSpeed;
            objectRigidbody.velocity = newVelocity;
        }
        //Debug.Log(objectRigidbody.velocity);
    }
}
