using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
/// <summary>
/// 开始面板类 登录后显示的主界面
/// </summary>
public class BeginPanel : BasePanel
{
    public Button playBtn;
    public Button registBtn;
    public Button shopBtn;
    public Button bagBtn;
    public Button settingBtn;
    public Button rankBtn;


    [Header("按钮点击动画参数")]
    public float pressScale = 0.9f;    // 按下缩小到多少
    public float animDuration = 0.1f; // 动画时间
    protected override void Init()
    {
        #region 按钮点击事件绑定
        playBtn.onClick.AddListener(() =>
        {
            PlayButtonPressAnim(playBtn);
            UIManager.Instance.HidePanel<BeginPanel>();
            UIManager.Instance.ShowPanel<LoginPanel>();
        });
        registBtn.onClick.AddListener(() =>
        {
            PlayButtonPressAnim(registBtn);
            UIManager.Instance.HidePanel<BeginPanel>();
        });
        shopBtn.onClick.AddListener(() =>
        {
            PlayButtonPressAnim(shopBtn);
            UIManager.Instance.HidePanel<BeginPanel>();
        });
        bagBtn.onClick.AddListener(() =>
        {
            PlayButtonPressAnim(bagBtn);
            UIManager.Instance.HidePanel<BeginPanel>();
        });
        settingBtn.onClick.AddListener(() =>
        {
            PlayButtonPressAnim(settingBtn);
            UIManager.Instance.HidePanel<BeginPanel>();
            UIManager.Instance.ShowPanel<SettingPanel>();
           
        });
        rankBtn.onClick.AddListener(() =>
        {
            PlayButtonPressAnim(rankBtn);
            UIManager.Instance.HidePanel<BeginPanel>();
        });
        #endregion

    }
    /// <summary>
    /// 按钮下陷回弹动画
    /// </summary>
    private void PlayButtonPressAnim(Button btn)
    {
        // 停止当前按钮正在播放的动画，防止连点错乱
        btn.transform.DOKill();

        // 序列：缩小(按下) → 恢复原大小(松开)
        DOTween.Sequence()
            .Append(btn.transform.DOScale(pressScale, animDuration))
            .Append(btn.transform.DOScale(1f, animDuration));
    }

    // 面板隐藏时清理动画，可选优化
    public override void Hide(UnityAction unityAction = null)
    {
        base.Hide(null);
        playBtn.transform.DOKill();
        registBtn.transform.DOKill();
        shopBtn.transform.DOKill();
        bagBtn.transform.DOKill();
    }
}
