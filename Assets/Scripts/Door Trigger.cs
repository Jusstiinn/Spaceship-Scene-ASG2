using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animator leftAnimator;
    public Animator rightAnimator;

    private bool playerPresent = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPresent = true;
            Debug.Log("Player in door range!");

            if (leftAnimator != null && rightAnimator != null)
            {
                leftAnimator.ResetTrigger("CloseDoor");
                rightAnimator.ResetTrigger("CloseDoor");

                leftAnimator.SetTrigger("OpenDoor");
                rightAnimator.SetTrigger("OpenDoor");

                leftAnimator.SetBool("IsOpen", true);
                rightAnimator.SetBool("IsOpen", true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPresent = false;
            Debug.Log("Player left door range!");

            if (leftAnimator != null && rightAnimator != null)
            {
                leftAnimator.ResetTrigger("OpenDoor");
                rightAnimator.ResetTrigger("OpenDoor");

                leftAnimator.SetTrigger("CloseDoor");
                rightAnimator.SetTrigger("CloseDoor");

                leftAnimator.SetBool("IsOpen", false);
                rightAnimator.SetBool("IsOpen", false);
            }
        }
    }
}
