using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TransformBehaviour : MonoBehaviour
{
    public UnityEvent onEnableEvent;
    public Vector3Data location;
    public float holdTime = 3f;
    private WaitForSeconds waitForSecondsObj;

    private void Awake()
    {
        waitForSecondsObj = new WaitForSeconds(holdTime);
    }

    private IEnumerator Start()
    {
        yield return waitForSecondsObj;
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        onEnableEvent.Invoke();
        StartCoroutine(Start());
    }

    public void UpdatePosition()
    {
        transform.position = location.value;
    }
}
