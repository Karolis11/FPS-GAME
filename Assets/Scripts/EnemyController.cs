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
    private int currentHealth;
    private float speed = 2.0f;
    
    

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = this.GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        currentHealth = maxHealth;
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
        currentHealth -= dmg;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(transform.parent.gameObject);
    }

}
