using System;
using UnityEditor;
using UnityEngine;

public class MenuItemsExample
{
    [MenuItem("GameObject/Util/Data/Prefs/DeleteAll", false,2)]
    public static void PrefabDataReset()
    {
        try
        {
            Debug.Log("PlayerPrefs Data Delet All Complet");
            PlayerPrefs.DeleteAll();
        }
        catch (Exception ex)
        {
            Debug.LogError($"Data Delet Error Exception : {ex}");
        }
    }
}