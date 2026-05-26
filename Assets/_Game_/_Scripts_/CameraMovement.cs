using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]private float sensX;
    [SerializeField]private float sensY;

    private float xRotation;
    private float yRotation;

    public Transform oriantation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * sensX * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensY * Time.deltaTime;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        oriantation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
