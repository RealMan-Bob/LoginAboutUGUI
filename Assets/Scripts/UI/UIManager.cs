using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    private static UIManager instance = new UIManager();

    public static UIManager Instance =>instance;

    private Transform canvasTrans;

    Dictionary<string,BasePanel> panelDic = new Dictionary<string,BasePanel>();
    private UIManager()
    {
        canvasTrans = GameObject.Find("Canvas").transform;
        GameObject.DontDestroyOnLoad(canvasTrans);
    }
    // Start is called before the first frame update
    public T ShowPanel<T>() where T : BasePanel
    {
        string panelName = typeof(T).Name;

        if (panelDic.ContainsKey(panelName) )
            return (T)panelDic[panelName];

        GameObject panelObj = GameObject.Instantiate(Resources.Load<GameObject>("UI/" + panelName));
        panelObj.transform.SetParent(canvasTrans,false);

        T panel=panelObj.GetComponent<T>();
        panelDic.Add(panelName,panel);
        panel.Show();
        return panel;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
