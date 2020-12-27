using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health;

    [HideInInspector]
    public Transform player;

    public float speed;

    public float timeBetweenAttacks;

    public int damage;

    public int healthPickupChance;
    public int pickupChance;
    public GameObject[] pickups;
    public GameObject healthPickup;

    public GameObject deathEffect;
    public GameObject bloodEffect;

   

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
           
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            var blood = Instantiate(bloodEffect , transform.position , Quaternion.identity);
            Destroy(blood, 3f);

            int RandomNumber = Random.Range(0, 101);
            if(RandomNumber < pickupChance)
            {
                GameObject weaponPickup = pickups[Random.Range(0, pickups.Length)];
                Instantiate(weaponPickup, transform.position, transform.rotation);
            }

            int RandomHealth = Random.Range(0, 101);
            if(RandomHealth < healthPickupChance)
            {
                Instantiate(healthPickup, transform.position, transform.rotation);
            }

            Destroy(gameObject);
        }
    }

    


}
