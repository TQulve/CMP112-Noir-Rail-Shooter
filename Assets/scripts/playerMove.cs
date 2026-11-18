using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class playerMove : MonoBehaviour
{
    //variables
    int currentPoint = 0;
    public float speed = 3f;

    private float moveTimer = 0f;
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
        

        // move timer
        if (moveTimer > 0f)
        {
            moveTimer -= Time.deltaTime;

        }
        if (moveTimer <= 0f && oneData.flag < 2)
        {
            moveTimer = 30f;
            oneData.flag += 1;
        }

        //lock the cursor in place
        Cursor.lockState = CursorLockMode.Locked;
        //hide it also
        Cursor.visible = false;
        Look();

        //movement points
        if (oneData.flag == 1) {
            move(new Vector3(3.34f, 3.25f, 2.76f));

        }
        if (oneData.flag == 2)
        {
            move(new Vector3(4.946f, 3.25f, -29.001f));
        }

        Debug.Log(oneData.flag);
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
