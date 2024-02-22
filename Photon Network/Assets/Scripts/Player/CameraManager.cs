using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] float cameraRotationLimit = 60;
    [SerializeField] float scrollSpeed = 100.0f;
    [SerializeField] float sensitivity = 20f;
    [SerializeField] float currentRotationX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();


    }

    public void RotateCamera()
    {
        float xRotation = Input.GetAxisRaw("Mouse Y");

        float cameraRotationX = xRotation * sensitivity;

        currentRotationX -= cameraRotationX * Time.deltaTime;

        currentRotationX = Mathf.Clamp(currentRotationX, -cameraRotationLimit, cameraRotationLimit);

        transform.localEulerAngles = new Vector3(currentRotationX, 0, 0);
    }
}
