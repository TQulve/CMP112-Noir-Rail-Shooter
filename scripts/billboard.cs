
using UnityEngine;

public class Billboard : MonoBehaviour
{

   
    private Transform player;
    void Start()
    {

        // find player
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");


        //ensure player exists
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }


    void LateUpdate()
    {

        //get the player position
        Vector3 direction = player.position - transform.position;

        // Make the enemy face the player
        transform.rotation = Quaternion.LookRotation(direction,Vector3.up) * Quaternion.Euler(90f, 0f, 0f);
    }
}