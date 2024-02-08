using UnityEngine;

public class FreezeRotation : MonoBehaviour
{
    public Transform target;
    public float heightOffset = -1.5f;

    void Update()
    {
        if (target != null)
        {
            Quaternion savedRotation = transform.rotation;

            transform.position = new Vector3(target.position.x, target.position.y + heightOffset, target.position.z);

            float targetYRotation = target.rotation.eulerAngles.y;

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, targetYRotation, transform.rotation.eulerAngles.z);
        }
        else
        {
            Debug.LogWarning("Target object is not assigned for following.");
        }
    }
}
