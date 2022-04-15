using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public new Camera camera;
    private float xRotation = 0f;
    public float xSenstivity = 30f;
    public float ySenstivity = 30f;
    private GameObject gun;

    private void Start()
    {
        gun = GetComponent<PlayerWeapon>().gun;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
    }
    public void ProcessLook(Vector2 input)
    {

        float mouseX = input.x;
        float mouseY = input.y;
        xRotation -= (mouseY * Time.deltaTime) * ySenstivity;
        xRotation = Mathf.Clamp(xRotation, -27f, 27f);
        camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSenstivity);
        gun.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

    }
}
