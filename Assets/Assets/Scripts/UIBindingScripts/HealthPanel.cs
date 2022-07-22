using UnityEngine;
using UnityEngine.UI;


public class HealthPanel : MonoBehaviour
{
    /*
    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject panelRoot;
    
    private Health boundHealth;

    private void OnDestroy()
    {
        if (boundHealth != null)
        {
            boundHealth.HealthChanged -= HandleHealthChanged;
        }
    }

    public void Bind(Health entity)
    {
        if (boundHealth != null)
        {
            boundHealth.HealthChanged -= HandleHealthChanged;
        }

        boundHealth = entity;
    
        if (boundHealth != null)
        {
            panelRoot.SetActive(true);
            boundHealth.HealthChanged += HandleHealthChanged;
            HandleHealthChanged(boundHealth.CurrentHealth, boundHealth.MaxHealth);
        }
        else
        {
            panelRoot.SetActive(false);
        }
    }

    private void HandleHealthChanged(int currentHealth, int maxHealth)
    {
        HealthBarObject.value = currentHealth / maxHealth;
    }

    [SerializeField]
    private Slider HealthBarObject;
    */
}