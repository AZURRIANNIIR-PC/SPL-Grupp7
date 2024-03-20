using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveGame : MonoBehaviour
{
    private const string RESPAWN_POSITION_KEY = "ActiveRespawnPosition";
    private const string PlayerSpriteIndexKey = "PlayerSpriteIndex";

    public static void SaveRespawnPosition(string respawnName)
    {
        PlayerPrefs.SetString(RESPAWN_POSITION_KEY, respawnName);
        PlayerPrefs.Save();
    }

    public static void LoadRespawnPosition()
    {
        if (PlayerPrefs.HasKey(RESPAWN_POSITION_KEY))
        {
            PlayerPrefs.GetString(RESPAWN_POSITION_KEY);
            //Debug.Log("Restartposition is" + RESPAWN_POSITION_KEY + ",not empty");
            Debug.Log("LoadRespawnPosition method");
        }
        //else
        //{
        //    // om respawnPosition inte sparas kommer start positionen användas
        //    return "";
        //    Debug.Log(PlayerPrefs.GetString(RESPAWN_POSITION_KEY));
        //}
    }

    public string GetKey()
    {
        Debug.Log(RESPAWN_POSITION_KEY);
        return PlayerPrefs.GetString(RESPAWN_POSITION_KEY);
    }

    public static void SavePlayerSpriteIndex(int spriteIndex)
    {
        PlayerPrefs.SetInt(PlayerSpriteIndexKey, spriteIndex);
        PlayerPrefs.Save();
    }

    public static int LoadPlayerSpriteIndex()
    {
        return PlayerPrefs.GetInt(PlayerSpriteIndexKey, 0);
    }

    public void DeleteSavedPlayerPosition()
    {
        PlayerPrefs.DeleteKey(RESPAWN_POSITION_KEY);
    }
}
