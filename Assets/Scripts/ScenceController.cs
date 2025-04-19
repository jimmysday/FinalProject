using UnityEngine;

public class ScenceController : MonoBehaviour
{
    [SerializeField] private Enemy archor;
    [SerializeField] private Player_NM player;
    [SerializeField] private UIManager manager;
    private float damageEnemy = 30;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        Messenger.AddListener(GameEvent.SWORD_ARCHOR, OnSwordArchor);
        Messenger.AddListener(GameEvent.ARROW_PLAYER, OnArrowPlayer);
        Messenger.AddListener(GameEvent.DEATH_ARCHOR, OnArrowPlayer);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.SWORD_ARCHOR, OnSwordArchor);
        Messenger.RemoveListener(GameEvent.ARROW_PLAYER, OnArrowPlayer);
        Messenger.RemoveListener(GameEvent.DEATH_ARCHOR, OnArchorDead);
    }
    private void Start()
    {
        //ui.UpdateScore(score);
        // other initializations that already exist
    }
    private void OnSwordArchor()
    {
        archor.TakeDamage(damageEnemy);
    }
    private void OnArrowPlayer()
    {
        //player.Hit();
        manager.UpdateHealth(1);
    }
    private void OnArchorDead()
    {
        //player.Hit();
        //manager.UpdateHealth(1);
    }
}
