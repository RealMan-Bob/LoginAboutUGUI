using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginPanel : BasePanel
{
    public Button playBtn;
    public Button registBtn;
    public Button shopBtn;
    public Button bagBtn;
    protected override void Init()
    {
        playBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<BeginPanel>();

        });
        registBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<BeginPanel>();
        });
        shopBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<BeginPanel>();
        });
        bagBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<BeginPanel>();
        });
    }
}
