using UnityEngine;
using System.Collections;

public class Faster : MonoBehaviour
{
     public float speed;
     public static float speedModifier = 1f;

     private Rigidbody rb;

     Vector3 initialForwardVector;

     void Start()
     {
        rb = GetComponent<Rigidbody>();
        initialForwardVector = transform.forward;
        rb.velocity = initialForwardVector * speed * speedModifier;
     }

     void Update()
     {
        if (Input.GetKey (KeyCode.E))
        {
            speedModifier = 2f;
            rb.velocity = initialForwardVector * (speedModifier * speed);
        }
     }
}