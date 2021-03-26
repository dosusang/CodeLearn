using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPoint : MonoBehaviour
{
    // Update is called once per frame
    private Vector3 tempAngle;
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            tempAngle = transform.rotation.eulerAngles;
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            tempAngle.x = tempAngle.x - mouseY;
            tempAngle.y = tempAngle.y - mouseX;
            transform.rotation = Quaternion.Euler(tempAngle);
        }
    }
}
