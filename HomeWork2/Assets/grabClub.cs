using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GolfClubGrab : MonoBehaviour
{
    private Quaternion initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        // Store the initial rotation when the scene starts
        initialRotation = transform.rotation;
    }

    // Called when the club is grabbed
    public void OnGrab()
    {
        // Apply the initial rotation to keep the club in its original orientation
        transform.rotation = initialRotation;
    }
}
