using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthed : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public Transform replaceOnDeath; 

    public void Start()
    {
        currentHealth = maxHealth;
    }

    public void RegisterHit(float amount)
    {
        currentHealth = Mathf.Max(0, currentHealth - amount);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            if (replaceOnDeath != null)
            {
                Instantiate(replaceOnDeath, transform.position, transform.rotation);
            }
        }
    }

    public void RegisterHeal(float amount)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + amount);
    }
}
