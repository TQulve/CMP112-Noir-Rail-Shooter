using UnityEngine;
using System.Collections;

public class enemyMove : MonoBehaviour
{
    private float time = 3f;
    private float moveSpd = 0.08f;
    private Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("CountDown");
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player);
            transform.position += new Vector3(moveSpd, 0f, 0f);
        }

        if (transform.position.x >= 25f)
        {
            Destroy(gameObject);
        }
    }
    public IEnumerator CountDown()
    {
        yield return new WaitForSeconds(time);
        
        if (transform.position.x < -34f)
        {
            moveSpd = 0f;
        }
        else
        {
            moveSpd *= 0.8f;
        }
        StartCoroutine("CountDown");


    }


}
