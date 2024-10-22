using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    public GameObject targetObject; 
    private Rigidbody rb; 
    private Vector3 initialPosition; 
    private bool hasStopped = false; 
    int hits=3;

    void Start()
    {

        initialPosition = transform.position;

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rb.velocity.magnitude < 0.05f && !hasStopped)
        {
            hasStopped = true; 

            float distance = Vector3.Distance(transform.position, targetObject.transform.position);

            Debug.Log("Distanța față de obiectul țintă: " + distance + " unități");
            hits--;
            Debug.Log("Mai aveti "+ hits + "lovituri");
        if(hits==0)
        {
            if(distance>20)
                 Debug.Log("Aveti 0 puncte");
            else{
            if(distance<20 && distance>10)
                Debug.Log("Aveti 10 puncte");
            else if(distance<10 && distance>5)
                Debug.Log("Aveti 15 puncte");
            else if(distance<5)
                Debug.Log("Aveti 20 puncte");
            }
        }
        }


        if (rb.velocity.magnitude > 0.05f)
        {
            hasStopped = false;
        }
    }
}
