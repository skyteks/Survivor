using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Register
{
    private Dictionary<System.Type, List<Object>> dictionary = new();
    private List<Object> list = new();

    public delegate void ObjectRegisterEvent(Object obj);
    public event ObjectRegisterEvent onAdded;
    public event ObjectRegisterEvent onRemoved;

    public bool AddObject(Object obj)
    {
        if (obj == null)
        {
            throw new System.NullReferenceException();
        }
        if (list.Contains(obj))
        {
            return false;
        }

        if (dictionary.TryGetValue(obj.GetType(), out List<Object> typeList))
        {
            typeList.Add(obj);
        }
        else
        {
            List<Object> newTypeList = new();
            newTypeList.Add(obj);
            dictionary.Add(obj.GetType(), newTypeList);
        }
        list.Add(obj);
        onAdded?.Invoke(obj);
        return true;
    }

    public bool RemoveObject(Object obj)
    {
        if (obj == null)
        {
            throw new System.NullReferenceException();
        }
        bool removed = list.Remove(obj);
        if (removed)
        {
            dictionary[obj.GetType()].Remove(obj);
            onRemoved?.Invoke(obj);
        }
        return removed;
    }

    public bool ContainsObject(Object obj)
    {
        if (obj == null)
        {
            throw new System.NullReferenceException();
        }
        return list.Contains(obj);
    }

    public Object GetFirstObjectOfType(System.Type type)
    {
        if (dictionary.TryGetValue(type, out List<Object> objList))
        {
            if (objList.Count > 0)
            {
                return objList[0];
            }
            else
            {
                return null;
            }
        }
        return null;
    }

    public Object GetLastObjectOfType(System.Type type)
    {
        if (dictionary.TryGetValue(type, out List<Object> objList))
        {
            if (objList.Count > 0)
            {
                return objList[objList.Count - 1];
            }
            else
            {
                return null;
            }
        }
        return null;
    }
}
