using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerItem : MonoBehaviour
{
    //按钮本身
    public Button btnSelf;
    //服务器状态图片
    public Image imageState;
    //服务器名称文本
    public Text textName;

    //当前按钮对应的服务器信息
    public ServerInfo nowServerInfo;

    private void Start()
    {
        btnSelf.onClick.AddListener(() =>
        {
            LoginMgr.Instance.LoginData.frontServerId = nowServerInfo.id;
            //点击按钮时，设置当前服务器信息
            UIManager.Instance.GetPanel<ServerPanel>().SetserverInfo(nowServerInfo.name, nowServerInfo.state);
            //隐藏选择服务器面板
            UIManager.Instance.HidePanel<ChooseServerPanel>();
            //显示当前服务器面板
            UIManager.Instance.ShowPanel<ServerPanel>();
        });
    }
    
    public void InitInfo(ServerInfo info)
    {
        //记录数据
        nowServerInfo = info;

        textName.text = info.id+"区"+info.name;
        imageState.gameObject.SetActive(info.isNew);
    }
}

