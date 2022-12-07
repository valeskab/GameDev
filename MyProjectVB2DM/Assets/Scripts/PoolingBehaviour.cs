using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PoolingBehaviour : MonoBehaviour
{
    public List<GameObject> poolList;
    public List<GameObject> pooledItems;
    public UnityEvent startEvent, poolEvent;
    public float seconds = 2f;
    private WaitForSeconds wfsObj;
    private int i;
    private int randObj;
    public bool canRun = true;
    IEnumerator Start()
    {
        startEvent.Invoke();
        wfsObj = new WaitForSeconds(seconds);
        while (canRun)
        {
            yield return wfsObj;
            poolEvent.Invoke();
            //poolList[i].position = Vector2.zero;
            poolList[i].gameObject.SetActive(true);
            i++;
            if (i > poolList.Count - 1)
            {
                i = 0;
            }
            
        }
    }
}
