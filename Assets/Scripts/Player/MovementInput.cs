using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInput : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 3f;

    private Rigidbody rigid;
    private Vector2 input;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        rigid.velocity = new Vector3(input.x * movementSpeed, rigid.velocity.y, input.y * movementSpeed);
    }
}
