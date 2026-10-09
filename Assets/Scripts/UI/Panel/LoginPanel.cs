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

    protected override void Init()
    {
        //登录按钮监听
        loginBtn.onClick.AddListener(() =>
        {
            //长度判断
            if (accountInput.text.Length < 6 || passwordInput.text.Length < 6)
            {
                TipPanel tip = UIManager.Instance.ShowPanel<TipPanel>();
                tip.SetTips("用户名和密码必须都大于六");
            }
            //登录验证
            if (LoginMgr.Instance.CheckUserInfo(accountInput.text,passwordInput.text))
            {
                LoginMgr.Instance.LoginData.account = accountInput.text;
                LoginMgr.Instance.LoginData.password = passwordInput.text;
                LoginMgr.Instance.LoginData.rememberPwd = rememberPwdTog.isOn;
                LoginMgr.Instance.LoginData.autoLogin = autoLoginTog.isOn;
                LoginMgr.Instance.SaveLoginData();
                UIManager.Instance.HidePanel<LoginPanel>();
            }
            else
            {
                UIManager.Instance.ShowPanel<TipPanel>().SetTips("用户名或密码错误");
            }

        });
        //注册按钮监听
        registerBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowPanel<RegisterPanel>();
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
    }

    public override void Show()
    {
        base.Show();
        //得到数据
        LoginData loginData=LoginMgr.Instance.LoginData;

        if (loginData != null) 
        {
            if (rememberPwdTog.isOn)
            {
                rememberPwdTog.isOn = loginData.rememberPwd;
                autoLoginTog.isOn = loginData.autoLogin;

                accountInput.text = loginData.account;
            }
            //记住密码
            if (rememberPwdTog.isOn)
            {
                passwordInput.text = loginData.password;
            }
            else
            {
                passwordInput.text = "";
            }
        }
        //自动登录
        if (autoLoginTog.isOn)
        {

        }
    }
    /// <summary>
    /// 提供给外部修改当前面板的信息
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    public void SetInfo(string userName,string password)
    {
        accountInput.text = userName;
        passwordInput.text = password;
    }
}
