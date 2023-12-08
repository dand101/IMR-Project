using UnityEngine;
using UnityEngine.InputSystem;


//maybe it works ¯\_(:|)_/¯
public class PlayerMovement : MonoBehaviour
{
    public float baseMoveSpeed = 3f;  
    public float speedMultiplier = 0.5f;  

    private Vector2 moveInput;

    void Update()
    {
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 desiredMoveDirection = forward * moveInput.y + right * moveInput.x;
        transform.Translate(desiredMoveDirection * (baseMoveSpeed * speedMultiplier) * Time.fixedDeltaTime);
    }
}