using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginMgr
{
    //单例模式
    private static LoginMgr instance=new LoginMgr();

    public static LoginMgr Instance
    {
        get { return instance; }
    }
    //登录数据
    private LoginData loginData;

    public LoginData LoginData => loginData;
    //构造函数
    private LoginMgr()
    {
        loginData = JsonMgr.Instance.LoadData<LoginData>("LoginData");
    }
    public void SaveLoginData()
    {
        JsonMgr.Instance.SaveData(loginData,"LoginData");
    }
}
