using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBall : MonoBehaviour
{
    public float hitForce = 1000f;
    public AudioSource hitSound; 
    public GameObject ballEffect; 
    public float stopThreshold = 0.1f; 

    private Rigidbody rb;
    private bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (ballEffect != null)
        {
            ballEffect.SetActive(false); 
        }
    }

    void Update()
    {
         if (isMoving)
        {
            if (ballEffect != null)
            {
                ballEffect.transform.position = transform.position;
            }

            if (rb.velocity.magnitude < stopThreshold)
            {
                isMoving = false;
                if (ballEffect != null)
                {
                    ballEffect.SetActive(false);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Club"))
        {
            Vector3 impactDirection = (transform.position - collision.transform.position).normalized;
            impactDirection.z = 0;

            rb.AddForce(impactDirection * hitForce, ForceMode.Impulse);

            if (hitSound != null)
            {
                hitSound.Play();
            }

            if (ballEffect != null)
            {
                ballEffect.SetActive(true);
            }

            isMoving = true;
        }
    }
}
