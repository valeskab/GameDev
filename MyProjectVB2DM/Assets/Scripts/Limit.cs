using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limit : MonoBehaviour
{
    public static event Action NewBlockRequestEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            if (NewBlockRequestEvent != null)
            {
                NewBlockRequestEvent.Invoke();
            }
            other.transform.position = Vector3.zero;
            other.gameObject.SetActive(false);
        }
    }
}
