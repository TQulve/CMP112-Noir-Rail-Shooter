using UnityEngine;
using System.Collections;
public class raycast : MonoBehaviour
{

    //variables
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
        // firerate timer
        if (fireRate > 0f)
        {
            fireRate -= Time.deltaTime;

        }
        
        //shoot out raycast from camera and store info on what it is hitting
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out HitInfo, 500.0f))
        {
          
            Debug.DrawRay(cameraTransform.position, cameraTransform.forward * 100.0f, Color.yellow);

            // if the ray is hitting something and we press the mouse and other requirements are met then...
            if (Input.GetMouseButtonDown(0) && fireRate <= 0 && ammo > 0)
            {
                Debug.DrawRay(cameraTransform.position, cameraTransform.forward * 100.0f, Color.red);

                //if the enemy is hit damage them
                enemyHit health = HitInfo.collider.GetComponent<enemyHit>();
                if (health != null)
                {
                    health.Damage(10);
                }

                //if a physics object is hit fling it
                physicsHit phis = HitInfo.collider.GetComponent<physicsHit>();
                if (phis != null)
                {
                    phis.applyForce(transform.forward);
                }

            }
        }


        // subtract ammo and set fireRate
        if (Input.GetMouseButtonDown(0) && fireRate <= 0 && ammo > 0)
        {
            
            fireRate = 0.2f;
            ammo--;

        }

        // press "R" to reload
        if (Input.GetKeyDown(KeyCode.R) && ammo < maxAmmo)
        {
            ammo += maxAmmo - ammo;

        }
    }

    int ammo_count()
    {
        return ammo;
    }
}
