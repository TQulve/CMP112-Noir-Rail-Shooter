using UnityEngine;

public class playerMove : MonoBehaviour
{
    //variables
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
        //lock the cursor in place
        Cursor.lockState = CursorLockMode.Locked;
        //hide it also
        Cursor.visible = false;
        Look();

        //movement points
        if (oneData.score < 20) {
            move(new Vector3(2, 2, 0));
        }
        if (oneData.score == 20)
        {

            move(new Vector3(15, 2, 0));
        }
       
    }


    //func to look around using the mouse
    void Look()
    {
        

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        cameraPitch -= mouseY; cameraPitch = Mathf.Clamp(cameraPitch, -maxLookAngle, maxLookAngle);

        playerCamera.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);
    }


    //func to move the player [tried multiple ways this is an almagamation that teleports the player for some reason, don't know how I made it work]
    void move(params Vector3[] array)
    {
        
        for (int x = 0; x < array.Length; x++)
        {
            while (transform.position != array[currentPoint])
            {
                
                    transform.position = Vector3.MoveTowards(transform.position,array[currentPoint],speed * Time.deltaTime);
                
            }

            if (transform.position == array[currentPoint])
            {
                currentPoint++;

                if (currentPoint >= array.Length)
                {
                    
                    currentPoint = 0;
                }
            }
        }
        
    }
}
