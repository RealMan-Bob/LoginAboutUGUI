using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : BasePanel
{
    //panel控件
    public InputField accountInput;
    public InputField passwordInput;

    public Button cancelBtn;
    public Button confirmBtn;

    public Button closeBtn;

    protected override void Init()
    {
        //取消按钮监听
        cancelBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<RegisterPanel>();
            UIManager.Instance.ShowPanel<LoginPanel>();
        });
        //确定注册按钮监听
        confirmBtn.onClick.AddListener(() =>
        {
            if (accountInput.text.Length<6||passwordInput.text.Length<6)
            {
                TipPanel tip= UIManager.Instance.ShowPanel<TipPanel>();
                tip.SetTips("用户名和密码必须都大于六");
            }
            if (LoginMgr.Instance.RegisterUser(accountInput.text,passwordInput.text))
            {

                LoginPanel loginPanel = UIManager.Instance.ShowPanel<LoginPanel>();
                loginPanel.SetInfo(accountInput.text,passwordInput.text);
                UIManager.Instance.HidePanel<RegisterPanel>();
            }
            else
            {
                TipPanel tip = UIManager.Instance.ShowPanel<TipPanel>();
                tip.SetTips("用户名已存在");
                accountInput.text = "";
                passwordInput.text = "";
            }
            
        });
        closeBtn.onClick.AddListener(() =>
        {

            UIManager.Instance.HidePanel<RegisterPanel>();
            UIManager.Instance.ShowPanel<LoginPanel>();

        });


    }
}
