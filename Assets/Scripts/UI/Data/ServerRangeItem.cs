using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 服务器区间
/// </summary>
public class ServerRangeItem : MonoBehaviour
{
    //按钮自己
    public Button btnSelf;
    public Text txtInfo;

    //区间范围
    private int beginIndex;
    private int endIndex;
    // Start is called before the first frame update
    void Start()
    {
        btnSelf.onClick.AddListener(() =>
        {

        });
    }

    public void InitInfo(int beginIndex,int endIndex)
    {
        this.beginIndex = beginIndex;
        this.endIndex = endIndex;

        txtInfo.text = beginIndex + "-" + endIndex;
    }
}
