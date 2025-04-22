using UnityEngine;

public class ScenceController : MonoBehaviour
{
    [SerializeField] private Enemy archor;
    [SerializeField] private Player_NM player;
    [SerializeField] private UIManager manager;
    [SerializeField] private Enemy_NM boss;
    private float damageEnemy = 40;
    private float damageBoss = 30;

    //[SerializeField] private GameObject prefabArcher;
    ////private GameObject enemy;
    //private Vector3 spawnPoint = new Vector3(0, 0, 5);

    //private int archorNumber = 3;
    //private GameObject[] enemies; // Array to hold enemy instances



    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        Messenger.AddListener(GameEvent.SWORD_ARCHOR, OnSwordArchor);
        Messenger.AddListener(GameEvent.SWORD_BOSS, OnSwordBoss);
        Messenger.AddListener(GameEvent.ARROW_PLAYER, OnArrowPlayer);
        Messenger.AddListener(GameEvent.DEATH_ARCHOR, OnArchorDead);
        Messenger.AddListener(GameEvent.PICKUP_BOTTLE, OnPickupBottle);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.SWORD_ARCHOR, OnSwordArchor);
        Messenger.RemoveListener(GameEvent.SWORD_BOSS, OnSwordBoss);
        Messenger.RemoveListener(GameEvent.ARROW_PLAYER, OnArrowPlayer);
        Messenger.RemoveListener(GameEvent.DEATH_ARCHOR, OnArchorDead);
        Messenger.RemoveListener(GameEvent.PICKUP_BOTTLE, OnPickupBottle);
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

    private void OnSwordBoss()
    {
        boss.TakeDamage(damageBoss);
    }

    private void OnArrowPlayer()
    {
        //player.Hit();
        manager.UpdateHealth(1);
    }
    private void OnArchorDead()
    {
        //player.Hit();
        Debug.Log("Killed an archer");
        manager.UpdateScore(50);
    }

    private void OnPickupBottle()
    {
        Debug.Log("OnPickupBottle");
        manager.updateinventory();
    }
}
