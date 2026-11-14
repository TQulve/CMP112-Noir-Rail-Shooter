using UnityEngine;
using System.Collections;
public class enemyHit : MonoBehaviour
{
    public int health = 30;
    public int dmgMultiplier = 1;

    public void Damage(int damage)
    {
        health -= damage*dmgMultiplier;

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
