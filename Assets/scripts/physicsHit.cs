using UnityEngine;

public class physicsHit : MonoBehaviour
{
    public Rigidbody rb;

    public void applyForce(Vector3 direction)
    {
        //apply force depending on player direction
        rb.AddForce(direction * 10f, ForceMode.Impulse);
        Debug.Log("hit");
    }
}
