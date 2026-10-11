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

    public Button backBtn;
    protected override void Init()
    {
        backBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<ServerPanel>();
            UIManager.Instance.ShowPanel<LoginPanel>();
        });
        entryBtn.onClick.AddListener(() =>
        {


        });
        changeBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<ServerPanel>();
            UIManager.Instance.ShowPanel<ChooseServerPanel>();

        });
    }
    //显示当前面板时进行服务器选择信息读取
    public override void Show()
    {
        base.Show();
        if (LoginMgr.Instance.LoginData.frontServerId<=0)
        {
            SetserverInfo("请选择服务器",-1);
        }
        else
        {
            ServerInfo info = LoginMgr.Instance.ServerData[LoginMgr.Instance.LoginData.frontServerId-1];
            if (info != null)
            {
                SetserverInfo(info.name,info.state);
            }
        }
    }
    //根据服务器状态设置服务器信息
    public void SetserverInfo(string info,int state, int? id = null)
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
        if (id!=null)
        {
            serverInfo.text =id+"区" + info;
            return;
        }
        serverInfo.text = info;
    }
}
    