using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 服务器信息类、用于装载服务器信息
/// </summary>
public class ServerInfo
{
    //id
    public int id;
    //名称
    public string name;
    //状态
    public int state;// 0: Maintenance, 1: Normal, 2: Hot
    //是否是新服
    public bool isNew;

}
