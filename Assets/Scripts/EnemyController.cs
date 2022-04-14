using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;

    private Rigidbody enemyRb;
    private GameObject player;
    private Vector3 movement;

    private const int maxHealth = 3;
    private const int bossMaxHealth = 7;
    private int currentHealth;
    private int bossCurrentHealth;
    private float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = this.GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        currentHealth = maxHealth;
        bossCurrentHealth = bossMaxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDir = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDir * speed);

    }

    public void TakeDamage(int dmg)
    {
        if (this.gameObject.tag == "Boss")
        {
            bossCurrentHealth -= dmg;
        }
        else
        {
            currentHealth -= dmg;
        }
        Debug.Log(gameObject.tag);

        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0f || bossCurrentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(transform.parent.gameObject);
    }

}
