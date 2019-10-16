using UnityEngine;
using System.Collections;
using ClayTargetShooting;

public class FlyCamera : MonoBehaviour
{

    public float mouseSensitivity = 3.0f;
    public float speed = 2.0f;
    private Vector3 transfer;

    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationX = 0F;
    float rotationY = 0F;
    Quaternion originalRotation;

    void Awake()
    {
        GetComponent<Camera>().orthographic = false;
    }

    void Start()
    {
        if (Application.platform != RuntimePlatform.WindowsEditor) this.enabled = false;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        // Движения мыши -> Вращение камеры
        rotationX += Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationY += Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotationX = ClampAngle(rotationX, minimumX, maximumX);
        rotationY = ClampAngle(rotationY, minimumY, maximumY);
        Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.left);
        transform.rotation = originalRotation * xQuaternion * yQuaternion;
        // перемещение камеры
        transfer = transform.forward * Input.GetAxis("Vertical");
        transfer += transform.right * Input.GetAxis("Horizontal");
        transform.position += transfer * speed * Time.deltaTime;

        //if (Input.GetMouseButtonUp(0)) {
        //    GetComponent<Player>().Click();
        //}
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F) angle += 360F;
        if (angle > 360F) angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }

}