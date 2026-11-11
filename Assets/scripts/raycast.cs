using UnityEngine;
using System.Collections;
public class raycast : MonoBehaviour
{
    public Ray RayOrigin;
    private RaycastHit HitInfo;
    public Transform cameraTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out HitInfo, 100.0f))
        {
            Debug.DrawRay(cameraTransform.position, cameraTransform.forward * 100.0f, Color.yellow);
            if (Input.GetMouseButtonDown(0))
            {
                Debug.DrawRay(cameraTransform.position, cameraTransform.forward * 100.0f, Color.red);
                enemyHit health = HitInfo.collider.GetComponent<enemyHit>();
                health.Damage(10);
            }
        }
    }
}
