using Steamworks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAchStatic : MonoBehaviour {
    public static string[] ACH_SA =
    {
        "ACH_11",  "ACH_12",  "ACH_13",  "ACH_14",  "ACH_15",  "ACH_16",  "ACH_17", "ACH_18",
        "ACH_19",  "ACH_20",  "ACH_21",  "ACH_22",  "ACH_23",  "ACH_24",  "ACH_25", "ACH_26",
        "ACH_27",  "ACH_28",  "ACH_29",  "ACH_30",  "ACH_31",  "ACH_32",  "ACH_33", "ACH_34",
        "ACH_35",  "ACH_36",  "ACH_37",  "ACH_38",  "ACH_39",  "ACH_40",  "ACH_41", "ACH_42",
        "ACH_43",  "ACH_44",  "ACH_45",  "ACH_46",  "ACH_47",  "ACH_48",  "ACH_49", "ACH_50"
    };

    // 解锁成就
    public static bool SetAchievement(string str)
    {
        if (str == "-1") return false;
        bool bl = SteamUserStats.SetAchievement(str);
        SteamUserStats.StoreStats();
        return bl;
        //return false;
    }

    public static bool SetAchievement(int index)
    {
        bool bl = SteamUserStats.SetAchievement(ACH_SA[index]);
        SteamUserStats.StoreStats();
        return bl;
        //return false;
    }

    // 获取成就状态
    public static bool GetAchievement(int index, out bool obl)
    {
        bool bl = SteamUserStats.GetAchievement(ACH_SA[index], out obl);
        return bl;
    }

    // 初始化成就状态
    public static bool ClearAchievement(int index)
    {
        bool bl = SteamUserStats.ClearAchievement(ACH_SA[index]);
        return bl;
    }
}
