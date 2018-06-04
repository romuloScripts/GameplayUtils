using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour{
    public const int maxHealth = 100;
    public int currentHealth = maxHealth;
    public bool destroyOnDeath;
	public Slider healthBar;

   	public void TakeDamage(int amount){
        currentHealth -= amount;
        if (currentHealth <= 0){
            if (destroyOnDeath){
                Destroy(gameObject);
            }else{
                currentHealth = maxHealth;
            }
        }
		healthBar.value = currentHealth;
    }

    void OnChangeHealth (int currentHealth){
        healthBar.value = currentHealth;
    }
}