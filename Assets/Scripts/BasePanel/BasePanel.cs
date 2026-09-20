using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel <T>: MonoBehaviour where T:BasePanel<T>
{
    private static T instance;

    public static T Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
        }
        else if (instance != this) 
        {
            Destroy(gameObject);
        }
    }
    public void ShowMe()
    {
        gameObject.SetActive(true);
    }
    public void HideMe()
    {
        gameObject.SetActive(false);
    }
}
