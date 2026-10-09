using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipPanel : BasePanel
{
    public Text tips;

    public Button sure;
    protected override void Init()
    {
        sure.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<TipPanel>();
        });
    }
    public void SetTips(string tip)
    {
        tips.text = tip;
    }
}
