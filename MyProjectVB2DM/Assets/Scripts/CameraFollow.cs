using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform characterTransform;

    private Vector3 myCamPos;
    void Start()
    {
        myCamPos = transform.position;
    }
    
    void LateUpdate()
    {
        Vector3 characterPos = characterTransform.position;
        myCamPos.x = Mathf.Lerp(myCamPos.x, characterPos.x, Time.deltaTime * 10f);
        transform.position = myCamPos;
    }
}
