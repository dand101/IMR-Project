using UnityEngine;

public class CellDoor : MonoBehaviour
{
    public GameObject doorPart1Prefab;
    public GameObject doorPart2Prefab;
    public GameObject doorPart3Prefab;

    private int hitCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            hitCount++;

            if (hitCount >= 1)
            {
                Vector3 doorPosition = transform.position;
                Quaternion doorRotation = transform.rotation;

                Instantiate(doorPart1Prefab, doorPosition, doorRotation);
                Instantiate(doorPart2Prefab, doorPosition, doorRotation);
                Instantiate(doorPart3Prefab, doorPosition, doorRotation);

                Destroy(gameObject);
            }
        }
    }
}
