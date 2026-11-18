using UnityEngine;

public class enemy_Spawn : MonoBehaviour
{
    public GameObject spawn;
    public Transform[] points;

    private Vector3[] spawns = { new Vector3(-11, 2, -6), new Vector3(-5, 2, -13)};

    private Vector3[] spawns2 = { new Vector3(-6.9f, 5.4f, -22.98f), new Vector3(-5.97f, 5.439f, -35.84f) };
    public Transform player;
    public float delay = 2f;
    public float radius = 25f;

    private float timer = 2f;
    private float next;

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime; 
        }
        if (timer <= 0)
        {
            Spawn();
            timer = 2f;
        }
        Debug.Log("flag is " + oneData.flag);
        
    }

    void Spawn()
    {
        if (oneData.flag < 2)
        {
            int index = Random.Range(0, points.Length);
            Instantiate(spawn, spawns[Random.Range(0, spawns.Length)], points[index].rotation);
        }
        if (oneData.flag == 2)
        {
            int index = Random.Range(0, points.Length);
            Instantiate(spawn, spawns2[Random.Range(0, spawns2.Length)], points[index].rotation);
        }
        


    }
}
