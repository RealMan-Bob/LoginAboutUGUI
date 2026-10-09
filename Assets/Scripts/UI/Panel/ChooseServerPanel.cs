using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseServerPanel:BasePanel
{

    public Button backBtn;
    protected override void Init()
    {
        backBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<ChooseServerPanel>();
            UIManager.Instance.ShowPanel<ServerPanel>();
        });
    }
}
