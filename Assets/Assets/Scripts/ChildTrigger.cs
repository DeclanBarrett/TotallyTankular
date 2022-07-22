using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ChildTrigger : MonoBehaviour
{
    public delegate void ChildTriggerCheck(GameObject childGameObject, Collider otherCollider);
    public static event ChildTriggerCheck TriggerTransfer;

    void OnTriggerStay(Collider collidedCollider)
    {
        try
        {
            TriggerTransfer(this.gameObject, collidedCollider);
        }
        catch(Exception NullReferenceException)
        {
            Debug.Log("Null Reference Exception");
        }
        
    }
}
