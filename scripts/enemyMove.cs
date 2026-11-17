using UnityEngine;
using System.Collections;

public class enemyMove : MonoBehaviour
{
    private float time = 3;
    private float moveSpd = 0.001f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("CountDown");
    }

    // Update is called once per frame
    void Update()
    {
      
        transform.position += new Vector3(moveSpd, 0f, 0f);
        




    }
    public IEnumerator CountDown()
    {
        yield return new WaitForSeconds(time);
        moveSpd *= -1;
        StartCoroutine("CountDown");


    }


}
