using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    public GameObject explosion;
    public int damage;

    private Animator cameraAnim;

    public GameObject sound;

    private void Start()
    {
        Instantiate(sound, transform.position, transform.rotation);
        cameraAnim = Camera.main.GetComponent<Animator>();
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

     void DestroyProjectile()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemy")
        {
            cameraAnim.SetTrigger("shake");
            collision.GetComponent<enemy>().takeDamage(damage);
            DestroyProjectile();
        }

        if(collision.tag == "Boss")
        {
            cameraAnim.SetTrigger("shake");
            collision.GetComponent<Boss>().takeDamage(damage);
            DestroyProjectile();
        }

    }

}
