using UnityEngine;

public class InstanceBehaviour<T> : MonoBehaviour where T : Component
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    GameObject newGO = new GameObject();
                    _instance = newGO.AddComponent<T>();
                }
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this as T;
    }
}
