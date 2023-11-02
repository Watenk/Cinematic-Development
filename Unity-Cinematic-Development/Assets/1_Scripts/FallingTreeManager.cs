using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTreeManager : MonoBehaviour
{
    public Camera MainCamera;
    public Camera TreeCam;
    public float TransitionDuration;
    public GameObject Tree;
    public float FallSpeed;

    private bool falling;

    public void Start()
    {
        InputManager.Instance.OnTDown += StartFallingTree;
    }

    public void FixedUpdate()
    {
        if (falling)
        {
            Tree.transform.eulerAngles -= Vector3.right * FallSpeed;
        }
    }

    private void StartFallingTree()
    {
        StartCoroutine(TransitionCamera(MainCamera, TreeCam));
        falling = true;
    }

    private IEnumerator TransitionCamera(Camera fromCamera, Camera toCamera)
    {
        float elapsedTime = 0f;
        Vector3 initialPosition = fromCamera.transform.position;
        Quaternion initialRotation = fromCamera.transform.rotation;

        while (elapsedTime < TransitionDuration)
        {
            fromCamera.transform.position = Vector3.Lerp(initialPosition, toCamera.transform.position, elapsedTime / TransitionDuration);
            fromCamera.transform.rotation = Quaternion.Slerp(initialRotation, toCamera.transform.rotation, elapsedTime / TransitionDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure a smooth transition by setting the final position and rotation
        fromCamera.transform.position = toCamera.transform.position;
        fromCamera.transform.rotation = toCamera.transform.rotation;

        fromCamera.gameObject.SetActive(false);
        toCamera.gameObject.SetActive(true);
    }
}
