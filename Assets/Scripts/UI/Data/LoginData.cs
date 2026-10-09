using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 数据类、用于装载登录信息
/// </summary>
public class LoginData
{
    //用户名
    public string account;
    //密码
    public string password;
    //记住密码
    public bool rememberPwd;
    //自动登录
    public bool autoLogin;
    //当前服务器id
    public int frontServerId = 0;
}
