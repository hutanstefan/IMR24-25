using UnityEngine;

public class ChangeAnimationOnCollision : MonoBehaviour
{
    private bool isColliding = false;
    public Animator animator; 

    void Start()
    {
        if (animator == null)
        {
            Debug.LogError("Animator component is not assigned.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.CompareTag("Enemy") && !isColliding)
        {
            animator.SetBool("isAttacking", true); 
            isColliding = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            animator.SetBool("isAttacking", false); 
            isColliding = false;
        }
    }
}
