using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 选择服务器面板
/// </summary>
public class ChooseServerPanel:BasePanel
{

    public Button backBtn;
    //左右的滚动视图
    public ScrollRect svLeft;
    public ScrollRect svRight;

    //用于存储右侧服务器区间的预制体
    private List<GameObject> itemList = new List<GameObject>();

    protected override void Init()
    {
        backBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<ChooseServerPanel>();
            UIManager.Instance.ShowPanel<ServerPanel>();
        });

        //获取服务器列表的数据
        List<ServerInfo> serverList = LoginMgr.Instance.ServerData;

        //动态循环创建左侧的服务器区间
        int num = serverList.Count / 5 + 1;
        for (int i = 0; i < num; i++)
        {
            GameObject item = Instantiate(Resources.Load<GameObject>("UI/ServerRangeItem"));
            item.transform.SetParent(svLeft.content,false);
            //初始化
            ServerRangeItem serverRange= item.GetComponent<ServerRangeItem>();
            int beginIndex = i * 5 + 1;
            int endIndex = (i + 1) * 5;
            if (endIndex>serverList.Count)
                endIndex = serverList.Count;
            serverRange.InitInfo(beginIndex,endIndex);
        }
    }

    public override void Show()
    {
        base.Show();
        UpdateRightItem(1,5>LoginMgr.Instance.ServerData.Count? LoginMgr.Instance.ServerData.Count : 5);
        
    }
    //根据传入的起始索引和结束索引，显示右侧的服务器区间
    public void UpdateRightItem(int startIndex,int endIndex)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            //删除之前存储的服务器区间的预制体
            Destroy(itemList[i]);
            
            //创建新的服务器区间的预制体
        }
        itemList.Clear();
        for (int i = startIndex; i <= endIndex;i++)
        {
            ServerInfo info = LoginMgr.Instance.ServerData[i-1];

            //创建右侧的服务器区间的预制体
            GameObject serverItem = Instantiate(Resources.Load<GameObject>("UI/ServerItem"));
            serverItem.transform.SetParent(svRight.content,false);
            ServerItem server=serverItem.GetComponent<ServerItem>();
            server.InitInfo(info);

            //创建成功后，存储到itemList中
            itemList.Add(serverItem);
        }
    }
}
