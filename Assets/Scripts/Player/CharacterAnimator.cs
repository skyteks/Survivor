using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 5f;

    private Animator animator;
    private Rigidbody rigid;
    private Transform modelHolder;

    void Awake()
    {
        modelHolder = transform.Find("Model");
        animator = modelHolder.GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        if (Mathf.Abs(rigid.velocity.x) > float.Epsilon || Mathf.Abs(rigid.velocity.z) > float.Epsilon)
        {
            Quaternion look = Quaternion.LookRotation(rigid.velocity.ToWithY(0f), Vector3.up);
            modelHolder.localRotation = Quaternion.RotateTowards(modelHolder.localRotation, look, Time.deltaTime * 100f * rotationSpeed);
        }
    }
}
