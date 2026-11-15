
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform player;
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }
    void LateUpdate()
    {
        if (player == null) return;

        Vector3 direction = player.position - transform.position;

        // Make the Plane face the player
        transform.rotation = Quaternion.LookRotation(
            direction,
            Vector3.up
        ) * Quaternion.Euler(90f, 0f, 0f);
    }
}