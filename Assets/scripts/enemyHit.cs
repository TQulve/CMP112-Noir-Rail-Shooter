using UnityEngine;
using System.Collections;
public class enemyHit : MonoBehaviour
{
    private int health = 30;

    public void Damage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
