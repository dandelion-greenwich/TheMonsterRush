using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float moveSpeed;

    [SerializeField] float turnSpeed;

    [SerializeField] Vector3 movementVec;

    [SerializeField] PlayerLogic player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!player.isSitting)
        {
            rb.AddForce(transform.forward * movementVec.z * moveSpeed);
            rb.AddTorque(transform.up * movementVec.x * turnSpeed);
        }
    }


    public void OnMove(InputValue input)
    {
        Vector2 xyInput = input.Get<Vector2>();

        movementVec = new Vector3(xyInput.x, 0, xyInput.y);
    }
}
