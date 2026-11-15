using UnityEngine;
using System.Collections;
public class raycast : MonoBehaviour
{
    public Ray RayOrigin;
    private RaycastHit HitInfo;
    public Transform cameraTransform;
    private float fireRate = 0f;
    private int ammo = 10;
    private int maxAmmo = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (fireRate > 0f)
        {
            fireRate -= Time.deltaTime;

        }
        
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out HitInfo, 100.0f))
        {
          
            Debug.DrawRay(cameraTransform.position, cameraTransform.forward * 100.0f, Color.yellow);
            if (Input.GetMouseButtonDown(0) && fireRate <= 0 && ammo > 0)
            {
                Debug.DrawRay(cameraTransform.position, cameraTransform.forward * 100.0f, Color.red);
                enemyHit health = HitInfo.collider.GetComponent<enemyHit>();
                if (health != null)
                {
                    health.Damage(10);
                }
                
            }
        }


        if (Input.GetMouseButtonDown(0) && fireRate <= 0 && ammo > 0)
        {
            
            fireRate = 0.5f;
            ammo--;

        }
        if (Input.GetKeyDown(KeyCode.R) && ammo < maxAmmo)
        {
            ammo += maxAmmo - ammo;

        }
    }
}
