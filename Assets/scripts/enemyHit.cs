using UnityEngine;
using System.Collections;
public class enemyHit : MonoBehaviour
{
    //vars
    public int health = 30;
    public int dmgMultiplier = 1;


    //damage function
    public void Damage(int damage)
    {

        // take away damage as given by whatever calls the function [might remove damage multiplier]
        health -= damage*dmgMultiplier;
        
        

        // if hp reaches 0 add score points and get rid of the object
        if (health <= 0)
        {

            oneData.score += 10;
            Debug.Log(oneData.score);
            gameObject.SetActive(false);
        }
    }
}
