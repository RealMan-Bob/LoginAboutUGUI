using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 登录管理类、用于管理登录数据和注册数据
/// </summary>
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

    //注册数据
    private RegisterData registerData;
    public RegisterData RegisterData => registerData;
    //登录数据
    public LoginData LoginData => loginData;

    //服务器数据
    private List<ServerInfo> serverData;

    public List<ServerInfo> ServerData => serverData;
    //构造函数
    private LoginMgr()
    {
        //读取登录数据
        loginData = JsonMgr.Instance.LoadData<LoginData>("LoginData");
        //读取注册数据
        registerData = JsonMgr.Instance.LoadData<RegisterData>("RegisterData");
        //获取服务器数据
        serverData = JsonMgr.Instance.LoadData<List<ServerInfo>>("ServerInfo");
    }
    /// <summary>
    /// 存储登录数据
    /// </summary>
    public void SaveLoginData()
    {
        JsonMgr.Instance.SaveData(loginData,"LoginData");
    }
    /// <summary>
    /// 存储注册数据
    /// </summary>
    public void SaveRegisterData()
    {
        JsonMgr.Instance.SaveData(registerData,"RegisterData");
    }

    //注册方法
    public bool RegisterUser(string userName,string password)
    {
        //判断用户名是否存在
        if (registerData.registerInfo.ContainsKey(userName))
        {
            return false;
        }
        registerData.registerInfo.Add(userName,password);

        SaveRegisterData();
        return true;
    }
    //检查用户名和密码是否正确
    public bool CheckUserInfo(string userName,string password)
    {
        if (registerData.registerInfo.ContainsKey(userName))
        {
            if (registerData.registerInfo[userName]==password)
            {
                return true;
            }
        }
        return false;
    }
}
