using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subscriber : MonoBehaviour
{
    [SerializeField]
    private Object subscibingObject;

    void OnEnable()
    {
        if (subscibingObject != null)
        {
            Add();
        }
    }

    void OnDisable()
    {
        if (subscibingObject != null)
        {
            Remove();
        }
    }

    private void Add()
    {
        GameManager.Instance.register.AddObject(subscibingObject);
    }

    private void Remove()
    {
        GameManager.Instance?.register.RemoveObject(subscibingObject);
    }
}
