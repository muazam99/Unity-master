using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Animator anim;

    public int health;

    private Vector2 moveAmount;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Animator hurtPanel;
    private Animator cameraAnim;

    private sceneTransition transition;

    private void Start()
    {
        cameraAnim = Camera.main.GetComponent<Animator>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        transition = FindObjectOfType<sceneTransition>();

    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;

        if(moveInput != Vector2.zero)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }

    public void takeDamage(int damage)
    {

        health -= damage;
        updateHealth(health);
        hurtPanel.SetTrigger("hurt");
        cameraAnim.SetTrigger("shake");
        if (health <= 0)
        {
            transition.LoadScene("Losee");
            Destroy(gameObject);
        }
    }


    public void ChangeWeapon(Weapon weapon)
    {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        Instantiate(weapon, transform.position, transform.rotation, transform);
    }

    void updateHealth(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }


        }
    }


    public void Heal(int healAmount)
    {
        if(health + healAmount > 5)
        {
            health = 5;
        }
        else
        {
            health += healAmount;
            updateHealth(health);
        }
    }


}
