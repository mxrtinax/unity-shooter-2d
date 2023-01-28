using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public int damage;
    public GameObject hitEffect;

    void Start()
    {
        StartCoroutine(SelfDestruct());   
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);            // bullet self destroys after set amount of time if it didn't hit anything
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        if (collider.CompareTag("Enemy"))
        {
            collider.GetComponent<Enemy>().TakeDamage(damage);
        }
        else if (collider.CompareTag("Player"))
        {
            collider.GetComponent<PlayerScript>().TakeDamage(damage);
        }
        
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
