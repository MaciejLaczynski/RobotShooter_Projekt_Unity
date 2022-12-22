using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public GameObject GameOver;

    [SerializeField]
    public int startingHealth = 5;

    public int currentHealth;
    
    private void OnEnable()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        Cursor.lockState = CursorLockMode.None;
        gameObject.SetActive(false);
        Time.timeScale = 0;
        GameOver.SetActive(true);
    }
}
