using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 场景设置面板类（音效、音乐）
/// </summary>
public class SettingPanel : BasePanel
{
    public Button closeBtn;

    public Toggle musicTog;
    public Toggle soundTog;

    protected override void Init()
    {
        closeBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<SettingPanel>();
            UIManager.Instance.ShowPanel<BeginPanel>();
        });

    }

    
}
