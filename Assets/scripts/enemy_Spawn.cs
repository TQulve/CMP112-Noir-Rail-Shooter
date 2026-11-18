using UnityEngine;

public class enemy_Spawn : MonoBehaviour
{
    public GameObject spawn;
    public Transform[] points;
    public Transform player;
    public float delay = 3.0f;
    public float radius = 25.0f;

    private float next;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > next && Vector3.Distance(player.position, transform.position) <= radius)
        {
            Spawn();
            next = Time.time + delay;
        }
    }

    void Spawn()
    {
        int index = Random.Range(0, points.Length);
        Instantiate(spawn, points[index].position, points[index].rotation);
    }
}
