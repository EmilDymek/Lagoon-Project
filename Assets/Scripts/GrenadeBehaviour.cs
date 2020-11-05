using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBehaviour : MonoBehaviour
{

    public float throwSpeed;
    public float grenadeFuse;
    public float explosionTimer;
    private bool exploding = false;
    public Rigidbody2D rb;
    public GameObject explosion;
    public GameObject grenadeThrow;
    public CircleCollider2D grenadeCollider;


    void Awake()
    {
        grenadeCollider.enabled = false;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (exploding == false)
        {
            GrenadeUpdate();
        }
        else
        {
            ExplosionUpdate();
        }
    }

    
    private void GrenadeUpdate()
    {
        rb.velocity = transform.right * throwSpeed;
        //transform.position += Vector3.right * throwSpeed;
        grenadeFuse -= Time.deltaTime;
        if (grenadeFuse <= 0)
        {
            exploding = true;
            explosion.SetActive(true);
            grenadeCollider.enabled = true;
            grenadeThrow.SetActive(false);
            rb.velocity = transform.right * 0;
        }
    }

    private void ExplosionUpdate()
    {
        explosionTimer -= Time.deltaTime;
        if (explosionTimer < 0)
        {
            Destroy(gameObject);
        }
    }
}
