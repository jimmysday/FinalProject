using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class enemyhealthbar : MonoBehaviour
{
    [SerializeField] private Image healthFill; // Drag the Fill Image here in the Inspector
    [SerializeField] private Enemy archor;

    private float maxHealth = 100f;
    private float currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth <= 0)
        {
            archor.GetComponent<Animator>().SetTrigger("death");
            Messenger.Broadcast(GameEvent.DEATH_ARCHOR);
        }

        if (healthFill != null)
        {
            Debug.Log("tackeDamage 2" + currentHealth);
            healthFill.fillAmount = currentHealth / maxHealth;
        }
    }
}
