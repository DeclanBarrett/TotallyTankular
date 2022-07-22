using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisable : MonoBehaviour
{

    void TurnOnObject(GameObject objectToTurnOn)
    {
        MonoBehaviour[] scripts = objectToTurnOn.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            if (script != this)
            {
                script.enabled = true;
            }
        }
        Rigidbody currentRigidBody = objectToTurnOn.GetComponent<Rigidbody>();
        if (currentRigidBody != null)
        {
            currentRigidBody.WakeUp();
        }

        ParticleSystem currentParticleSystem = objectToTurnOn.GetComponent<ParticleSystem>();
        if (currentParticleSystem != null)
        {
            currentParticleSystem.Play(true);
        }
    }

    void TurnOffObject(GameObject objectToTurnOff)
    {
        MonoBehaviour[] scripts = objectToTurnOff.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            if (script != this)
            {
                script.enabled = false;
            }
        }
        Rigidbody currentRigidBody = objectToTurnOff.GetComponent<Rigidbody>();
        if (currentRigidBody != null)
        {
            currentRigidBody.Sleep();
        }

        ParticleSystem currentParticleSystem = objectToTurnOff.GetComponent<ParticleSystem>();
        if (currentParticleSystem != null)
        {
            currentParticleSystem.Stop(true);
        }
    }

    void BreadthFirstTraversalTurningOnScripts()
    {
        GameObject root = gameObject;
        Queue<GameObject> childQueue = new Queue<GameObject>();
        childQueue.Enqueue(root);
        while (childQueue.Count != 0)
        {
            GameObject tempChild = childQueue.Dequeue();
            TurnOnObject(tempChild);
            for (int i = 0; i < tempChild.transform.childCount; i++)
            {
                childQueue.Enqueue(tempChild.transform.GetChild(i).gameObject);
            }
        }
    }

    void BreadthFirstTraversalTurningOffScripts()
    {
        GameObject root = gameObject;
        Queue<GameObject> childQueue = new Queue<GameObject>();
        childQueue.Enqueue(root);
        while (childQueue.Count != 0)
        {
            GameObject tempChild = childQueue.Dequeue();
            //Debug.Log(tempChild.name + " Has the child count: " + tempChild.transform.childCount);
            TurnOffObject(tempChild);
            for (int i = 0; i < tempChild.transform.childCount; i++)
            {
                childQueue.Enqueue(tempChild.transform.GetChild(i).gameObject);
            }
        }
    }

    void OnEnable()
    {
        RoundInstantiate.OnRoundStarted += BreadthFirstTraversalTurningOnScripts;
        RoundInstantiate.OnRoundInstantiated += BreadthFirstTraversalTurningOffScripts;
        RoundInstantiate.OnRoundFinished += BreadthFirstTraversalTurningOffScripts;
    }

    void OnDisable()
    {
        RoundInstantiate.OnRoundStarted -= BreadthFirstTraversalTurningOnScripts;
        RoundInstantiate.OnRoundInstantiated -= BreadthFirstTraversalTurningOffScripts;
        RoundInstantiate.OnRoundFinished -= BreadthFirstTraversalTurningOffScripts;
    }
}
