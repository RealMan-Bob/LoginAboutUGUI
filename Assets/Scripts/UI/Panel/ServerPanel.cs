using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 当前服务器面板
/// </summary>
public class ServerPanel : BasePanel
{
    public Button entryBtn;
    public Button changeBtn;

    public Text serverInfo;
    protected override void Init()
    {
        entryBtn.onClick.AddListener(() =>
        {


        });
        changeBtn.onClick.AddListener(() =>
        {


        });
    }
    //根据服务器状态设置服务器信息
    public void SetserverInfo(string info,int state)
    {
        switch (state)
        {
            case 0:
                info += "（维护中）";
                break;
            case 1:
                info += "（正常）";
                break;
            case 2:
                info += "（火爆）";
                break;
            default:
                info += "（未知状态）";
                break;
        }
        serverInfo.text = info;
    }
}
    