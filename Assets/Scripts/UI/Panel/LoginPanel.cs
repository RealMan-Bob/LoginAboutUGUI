using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 登录面板类
/// </summary>
public class LoginPanel : BasePanel
{
    //panel控件
    public InputField accountInput;
    public InputField passwordInput;

    public Toggle rememberPwdTog;
    public Toggle autoLoginTog;

    public Button loginBtn;
    public Button registerBtn;

    public Button closeBtn;

    protected override void Init()
    {
        //登录按钮监听
        loginBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<LoginPanel>();
        });
        //注册按钮监听
        registerBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<LoginPanel>();
        });
        //记住密码Tog监听
        rememberPwdTog.onValueChanged.AddListener((isOn) =>
        {
            if (!isOn)
            {
                autoLoginTog.isOn = false;
            }
        });
        //自动登录Tog监听
        autoLoginTog.onValueChanged.AddListener((isOn) =>
        {
            if (isOn)
            {
                rememberPwdTog.isOn = true;
            }
        });
        closeBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowPanel<BeginPanel>();
            UIManager.Instance.HidePanel<LoginPanel>();
            
        });
    }

    public override void Show()
    {
        base.Show();
        //得到数据
        LoginData loginData=LoginMgr.Instance.LoginData;

        rememberPwdTog.isOn = loginData.rememberPwd;
        autoLoginTog.isOn = loginData.autoLogin;

        accountInput.text = loginData.account;

        //记住密码
        if (rememberPwdTog.isOn)
        {
            passwordInput.text = loginData.password;
        }
        else
        {
            passwordInput.text = "";
        }
        //自动登录
        if (autoLoginTog.isOn)
        {

        }
    }
}
