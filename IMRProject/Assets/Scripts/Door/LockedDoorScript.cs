using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public int doorNumber;  // Unique identifier for the door
    private bool isLocked = true;
    public GameObject barrier;
    private Rigidbody doorRigidbody;


    private void Start()
    {
        doorRigidbody = GetComponent<Rigidbody>();

        if (doorRigidbody == null)
        {
            Debug.LogError("Rigidbody not found on the door. Please add a Rigidbody component to the door.");
        }
        else
        {
            doorRigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }

        if (barrier != null)
        {
            barrier.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Key keyScript = collision.gameObject.GetComponent<Key>();

        if (keyScript != null && isLocked && keyScript.keyNumber == doorNumber)
        {
            UnlockDoor(keyScript.gameObject);
        }
    }

    private void UnlockDoor(GameObject keyObject)
    {
        if (barrier != null)
        {
            Destroy(barrier);
        }

        if (keyObject != null)
        {
            Destroy(keyObject);
        }
        else
        {
            Debug.LogWarning("Key GameObject is null. Check your key finding logic.");
        }

        if (doorRigidbody != null)
        {
            doorRigidbody.constraints = RigidbodyConstraints.None;
        }

        isLocked = false;
        Debug.Log("Door unlocked!");
    }
}
