using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings")]
public class GameSettings : ScriptableObject
{
    public static GameSettings Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<GameSettings>("GameSettings");
                if (instance == null)
                {
                    Debug.LogError("Couldn't find GameSettings in Resources folder");
                }
            }
            return instance;
        }
    }
    private static GameSettings instance;

    [Header("Cursor Settings")]
    public bool CursorVisible;
    public bool CursorLocked;

    [Header("Player Settings")]
    public float PlayerSpeed;
    public float PlayerJumpStrenght;
    public int PlayerMaxHealth;
    public float PlayerHeadRotationSpeed;
}
