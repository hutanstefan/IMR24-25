using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBall : MonoBehaviour
{
    public float hitForce = 10f;
    public float friction = 0.98f;

    public Vector3 hitDirection = new Vector3(1, 0, 0); 

    void Start()
    {
        
    }

    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb.velocity.magnitude > 0.1f)
        {
            rb.velocity *= friction;
        }     
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Club"))
        {
            Vector3 impactDirection = collision.contacts[0].normal;
            
            GetComponent<Rigidbody>().AddForce(-impactDirection * hitForce, ForceMode.Impulse);
        }
    }
}
