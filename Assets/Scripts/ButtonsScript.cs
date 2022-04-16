using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private ScreensManager screenManager;

    private int maxHealth;
    private int bossMaxHealth;
    private float speed;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void EasyMode()
    {
        maxHealth = 2;
        bossMaxHealth = 5;
        speed = 1.5f;
        EnemyController.SetDifficulty(maxHealth, bossMaxHealth, speed);
        EnemyController.ResetKilledEnemies();
        screenManager.SetActiveStartScreen(false);
        player.SetGameActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MediumMode()
    {
        maxHealth = 3;
        bossMaxHealth = 7;
        speed = 2;
        EnemyController.SetDifficulty(maxHealth, bossMaxHealth, speed);
        EnemyController.ResetKilledEnemies();
        screenManager.SetActiveStartScreen(false);
        player.SetGameActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void HardMode()
    {
        maxHealth = 4;
        bossMaxHealth = 10;
        speed = 2.5f;
        EnemyController.SetDifficulty(maxHealth, bossMaxHealth, speed);
        EnemyController.ResetKilledEnemies();
        screenManager.SetActiveStartScreen(false);
        player.SetGameActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

}
