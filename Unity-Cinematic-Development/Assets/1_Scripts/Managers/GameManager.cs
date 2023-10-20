using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        if (GameSettings.Instance.CursorVisible)
        {
            Cursor.visible = false;
        }

        if (GameSettings.Instance.CursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
