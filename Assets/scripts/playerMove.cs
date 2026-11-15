using UnityEngine;

public class playerMove : MonoBehaviour
{

    int currentPoint = 0;
    public float speed = 3f;
    public Transform playerCamera;
    private float cameraPitch;
    private CharacterController controller;
    public float mouseSensitivity = 2f;
    public float maxLookAngle = 85f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Look();
        move(new Vector3(2, 2, 0));
        Debug.Log(oneData.locked);
    }

    void Look()
    {
        if (Cursor.lockState != CursorLockMode.Locked)
            return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(
            cameraPitch, -maxLookAngle, maxLookAngle);

        playerCamera.localRotation =
            Quaternion.Euler(cameraPitch, 0f, 0f);
    }

    void move(params Vector3[] array)
    {
        
        for (int x = 0; x < array.Length; x++)
        {
            if (oneData.locked == false)
            {
                transform.position = Vector3.MoveTowards(
                transform.position,
                array[currentPoint],
                speed * Time.deltaTime
            );
            }

            if (transform.position == array[currentPoint])
            {
                currentPoint++;

                if (currentPoint >= array.Length)
                {
                    oneData.locked = true;
                    currentPoint = 0;
                }
            }
        }
        
    }
}
