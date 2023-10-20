using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //Events
    //Key
    public event Action OnSpace;
    public event Action OnW;
    public event Action OnA;
    public event Action OnS;
    public event Action OnD;

    //KeyDown
    public event Action OnSpaceDown;
    public event Action OnWDown;
    public event Action OnADown;
    public event Action OnSDown;
    public event Action OnDDown;

    //Mouse
    public event Action<Vector2> OnMouseMovement;

    public static InputManager Instance
    {
        get
        {
            return instance;
        }
    }
    private static InputManager instance;

    public void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        //Check Inputs
        //Key
        if (Input.GetKey(KeyCode.Space) && OnSpace != null) { OnSpace(); }
        if (Input.GetKey(KeyCode.W) && OnW != null) { OnW(); }
        if (Input.GetKey(KeyCode.A) && OnA != null) { OnA(); }
        if (Input.GetKey(KeyCode.S) && OnS != null) { OnS(); }
        if (Input.GetKey(KeyCode.D) && OnD != null) { OnD(); }

        //KeyDown
        if (Input.GetKeyDown(KeyCode.Space) && OnSpaceDown != null) { OnSpaceDown(); }
        if (Input.GetKeyDown(KeyCode.W) && OnWDown != null) { OnWDown(); }
        if (Input.GetKeyDown(KeyCode.A) && OnADown != null) { OnADown(); }
        if (Input.GetKeyDown(KeyCode.S) && OnSDown != null) { OnSDown(); }
        if (Input.GetKeyDown(KeyCode.D) && OnDDown != null) { OnDDown(); }

        ////Mouse
        Vector2 mouseDir = new Vector2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));
        if (OnMouseMovement != null) { OnMouseMovement(mouseDir); }
    }
}
