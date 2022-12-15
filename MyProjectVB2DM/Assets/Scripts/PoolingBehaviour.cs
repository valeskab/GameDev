using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PoolingBehaviour : MonoBehaviour
{
    [SerializeField] private string poolerName;
    [SerializeField] private GameObject[] objsToCreate;
    [SerializeField] private int objsQuanity;

    private List<GameObject> createdInstances = new List<GameObject>();
    private GameObject PoolerContainer;

    private void Awake()
    {
        PoolerContainer = new GameObject($"Pooler - {poolerName}");
        CreatePooler();
    }

    private void CreatePooler()
    {
        for (int i = 0; i < objsToCreate.Length; i++)
        {
            for (int j = 0; j < objsQuanity; j++)
            {
                createdInstances.Add(AddInstancer(objsToCreate[i]));
            }
        }
    }

    private GameObject AddInstancer(GameObject obj)
    {
        GameObject newObj = Instantiate(obj, PoolerContainer.transform);
        newObj.name = obj.name;
        newObj.SetActive(false);
        return newObj;
    }

    public GameObject ObtainPoolerInstancer(string nombre)
    {
        for (int i = 0; i < createdInstances.Count; i++)
        {
            if (createdInstances[i].name == nombre)
            {
                if (createdInstances[i].activeSelf == false)
                {
                    return createdInstances[i];
                }
            }
        }
        return null;
    }
}