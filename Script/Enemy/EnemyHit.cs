using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{

    int health=10;
    Rigidbody2D rb;
    public int Guc;
    public Vector3 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Damage(int damage)
    {

        health -= damage;
        if (health<=0)
        {
            Die();
        }
    }
    public void Fırlat(Vector3 nab)
    {
 
        rb.AddForce(nab.normalized*Guc);
    }


    void Die()
    {
        Destroy(gameObject, 1);
    }
}
