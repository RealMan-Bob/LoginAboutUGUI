using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI面板管理器、单例类
/// 功能：加载、显示、获取、销毁UI面板，缓存已实例化面板
/// 约定：UI预制体存放路径 Resources/UI/，预制体文件名必须等于面板脚本类名
/// 说明：面板销毁后会从缓存字典移除；如需保留面板，不要调用HidePanel销毁
/// </summary>
public class UIManager
{
    /// <summary>
    /// 饿汉单例实类
    /// </summary>
    private static UIManager instance = new UIManager();
    /// <summary>
    /// 获取UIManager全局唯一实例
    /// </summary>
    public static UIManager Instance =>instance;
    /// <summary>
    /// Canvas根节点Transform，所有UI面板父物体
    /// </summary>
    private Transform canvasTrans;
    /// <summary>
    /// 面板缓存字典
    /// key：面板类名；value：面板实例
    /// 保存已经实例化未销毁的面板
    /// </summary>
    Dictionary<string,BasePanel> panelDic = new Dictionary<string,BasePanel>();
    /// <summary>
    /// 私有构造函数，防止外部new，保证单例
    /// </summary>
    private UIManager()
    {
        canvasTrans = GameObject.Find("Canvas").transform;
        GameObject.DontDestroyOnLoad(canvasTrans);
    }
    /// <summary>
    /// 显示UI面板
    /// 若面板未实例化：加载Resources预制体，创建实例，调用Show
    /// 若面板已经存在缓存：直接调用Show，复用面板实例
    /// </summary>
    /// <typeparam name="T">面板脚本类型，必须继承BasePanel</typeparam>
    /// <returns>面板实例，加载失败返回null</returns>
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
    /// <summary>
    /// 隐藏并销毁面板
    /// </summary>
    /// <typeparam name="T">面板脚本类型</typeparam>
    /// <param name="isFade">true：播放淡出动画，动画结束后销毁；false：直接销毁面板，不播放动画</param>
    public void HidePanel<T>(bool isFade = true) where T : BasePanel
    {
        string panelName = typeof(T).Name;
        if(panelDic.ContainsKey(panelName))
        {
            if (isFade)
            {
                panelDic[panelName].Hide(() =>
                {
                    GameObject.Destroy(panelDic[panelName].gameObject);
                    panelDic.Remove(panelName);
                });
            }
            else
            {
                //从字典中清除
                GameObject.Destroy(panelDic[panelName].gameObject);
                panelDic.Remove(panelName);
            }
        }
    }
    /// <summary>
    /// 获取缓存中的面板实例
    /// 【注意】不会自动加载预制体，仅返回已经实例化存在于字典中的面板
    /// </summary>
    /// <typeparam name="T">面板脚本类型</typeparam>
    /// <returns>存在返回面板实例，不存在返回null</returns>
    public T GetPanel<T>() where T:BasePanel
    {
        string panelName=typeof(T).Name;
        if (panelDic.ContainsKey(panelName))
        {
            return panelDic[panelName] as T;
        }
        return null;
    }
}
