using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSway : MonoBehaviour
{
    [SerializeField] private float smoothness;
    [SerializeField] private float swayMultiplier;

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * swayMultiplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayMultiplier;
        Quaternion rotationX = Quaternion.AngleAxis(mouseX, Vector3.up);
        Quaternion rotationY = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion targetRot = rotationX* rotationY;
        transform.localRotation= Quaternion.Slerp(transform.localRotation, targetRot, smoothness * Time.smoothDeltaTime);

    }
}
