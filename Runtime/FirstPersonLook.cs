using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    public GameObject ParentObject;
    public float xSensitivity = 3f;
    public float ySensitivity = 3f;

    public bool xInvert = false;
    public bool yInvert = false;

    private float xRotation = 0f;
    private float yRotation = 0f;

    void Update()
    {
        int xflip = 1;
        if (xInvert)
        {
            xflip = -1;
        }

        int yflip = 1;
        if (yInvert)
        {
            yflip = -1;
        }

        xRotation += Input.GetAxis("Mouse X") * xSensitivity * xflip;
        yRotation -= Input.GetAxis("Mouse Y") * ySensitivity * yflip;

        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
        ParentObject.transform.localRotation = Quaternion.Euler(0f, xRotation, 0f);
    }
}
