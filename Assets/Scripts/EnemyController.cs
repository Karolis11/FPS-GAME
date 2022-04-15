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

    private const int maxHealth = 3;
    private const int bossMaxHealth = 7;

    private static int enemiesKilled = 0;

    private int currentHealth;

    private float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = this.GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        if(gameObject.tag == "Boss")
        {
            currentHealth = bossMaxHealth;
            healthBar.SetMaxHealth(bossMaxHealth);
        }
        else
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerMovement>().isGameActive)
        {
            Vector3 lookDir = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDir * speed);
        }

        if(gameObject.transform.position.y <= -1)
        {
            Die();
        }
    }

    public int GetEnemiesKiled()
    {
        return enemiesKilled;
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
        ++enemiesKilled;
        if (enemiesKilled == GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>().GetAmountOfEnemies() + 1)
        {
            player.GetComponent<PlayerMovement>().WinGame();
        }
        Destroy(transform.parent.gameObject);
        
    }

}
