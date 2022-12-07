using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform characterTransform;

    private Vector3 myCamPos;
    
    void Start()
    {
        myCamPos = transform.position;
    }
    void LateUpdate()
    {
        Vector3 posCharacter = characterTransform.position;
        myCamPos.x = Mathf.Lerp(myCamPos.x, posCharacter.x, Time.deltaTime * 10);
    }
}
