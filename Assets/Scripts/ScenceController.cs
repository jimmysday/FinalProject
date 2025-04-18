using UnityEngine;

public class ScenceController : MonoBehaviour
{
    [SerializeField] private enemyhealthbar enemybar;

    private float damageEnemy = 30;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        Messenger.AddListener(GameEvent.SWORD_ARCHOR, OnSwordArchor);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.SWORD_ARCHOR, OnSwordArchor);
    }
    private void Start()
    {
        //ui.UpdateScore(score);
        // other initializations that already exist
    }
    private void OnSwordArchor()
    {
          enemybar.TakeDamage(damageEnemy);
    }
}
