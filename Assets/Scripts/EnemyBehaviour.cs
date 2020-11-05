using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;

    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(damage);
    }
}
