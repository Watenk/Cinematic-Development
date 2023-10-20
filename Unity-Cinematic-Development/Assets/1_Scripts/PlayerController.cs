using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private Vector3 direction = Vector3.zero;

    //References
    private Camera cam;
    private Rigidbody rb;
    private CheckGround checkGround;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) { Debug.LogError("PlayerController Couldn't find a rigidbody"); }

        cam = GetComponentInChildren<Camera>();
        if (cam == null) { Debug.LogError("PlayerController Couldn't find a Camera In Children"); }

        checkGround = GetComponentInChildren<CheckGround>();
        if (checkGround == null) { Debug.LogError("PlayerController Couldn't find CheckGround Script in Children"); }
    }

    void Start()
    {
        InputManager.Instance.OnW += MoveForwards;
        InputManager.Instance.OnA += MoveLeft;
        InputManager.Instance.OnS += MoveBackwards;
        InputManager.Instance.OnD += MoveRight;
        InputManager.Instance.OnMouseMovement += MouseMovement;
        InputManager.Instance.OnSpaceDown += Jump;
    }

    private void FixedUpdate()
    {
        //Some extra Gravity
        rb.AddForce(new Vector3(0, -0.5f, 0), ForceMode.Impulse);

        //MovePlayer
        direction.Normalize();
        direction *= GameSettings.Instance.PlayerSpeed;
        rb.AddForce(direction);
        direction = Vector3.zero;
    }

    private void MoveForwards()
    {
        direction += transform.forward;
    }

    private void MoveLeft()
    {
        direction += -transform.right;
    }

    private void MoveBackwards()
    {
        direction += -transform.forward;
    }

    private void MoveRight()
    {
        direction += transform.right;
    }

    private void Jump()
    {
        if (checkGround.IsOnGround)
        {
            rb.AddForce(new Vector3(0, GameSettings.Instance.PlayerJumpStrenght, 0), ForceMode.Impulse);
        }
    }

    private void MouseMovement(Vector2 mouseDir)
    {
        float newCameraX = cam.transform.eulerAngles.x - mouseDir.x * GameSettings.Instance.CameraRotationSpeed;
        float newPlayerY = transform.eulerAngles.y + mouseDir.y * GameSettings.Instance.CameraRotationSpeed;

        cam.transform.localEulerAngles = new Vector3(newCameraX, 0, 0);
        transform.eulerAngles = new Vector3(0, newPlayerY, 0);
    }
}
