using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{

    public int health;

    public enemy[] enemies;

    public float spawnOffset;

    private int halfHealth;
    private Animator anim;

    public int damage;
    public GameObject deathEffect;

    private Slider healthBar;

    private sceneTransition transition;


    private void Start()
    {
        halfHealth = health / 2;
        anim = GetComponent<Animator>();
        healthBar = FindObjectOfType<Slider>();
        healthBar.maxValue = health;
        healthBar.value = health;
        transition = FindObjectOfType<sceneTransition>();
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        healthBar.value = health;
        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            healthBar.gameObject.SetActive(false);
            transition.LoadScene("Win");

        }
        if(health <= halfHealth)
        {
            anim.SetTrigger("stage2");
        }

        enemy RandomEnemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(RandomEnemy, transform.position + new Vector3(spawnOffset,spawnOffset , 0), transform.rotation);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Player>().takeDamage(damage);
        }
    }




}
