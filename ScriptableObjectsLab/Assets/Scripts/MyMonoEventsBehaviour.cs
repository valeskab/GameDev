using System;
using UnityEngine;
using UnityEngine.Events;

public class MyMonoEventsBehaviour : MonoBehaviour
{
    public UnityEvent resetEvent, collisionEnterEvent, destroyEvent, enableEvent;

    private void Reset()
    {
        resetEvent.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        collisionEnterEvent.Invoke();
    }

    private void OnDestroy()
    {
        destroyEvent.Invoke();
    }

    private void OnEnable()
    {
        enableEvent.Invoke();
    }
    
    
    //Never put event inside of update
}
