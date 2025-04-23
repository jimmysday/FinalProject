using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceController : MonoBehaviour
{
   // [SerializeField] private Enemy archor;
    [SerializeField] private Player_NM player;
    [SerializeField] private UIManager manager;
    [SerializeField] private Enemy_NM boss;
    private float damageEnemy = 40;
    private float damageBoss = 30;

    [SerializeField] private GameObject enemyPrefab;
    //private GameObject enemy;
    private Vector3 spawnPoint = new Vector3(-1, 0, 4);

    private int enemyNumber = 2;
    private GameObject[] enemies; // Array to hold enemy instances

    private void Start()
    {
        enemies = new GameObject[enemyNumber];
        // Loop through the array and instantiate enemies at the start
        for (int i = 0; i < enemyNumber; i++)
        {
            SpawnEnemy(i);
        }
    }

    // Helper function to spawn an enemy
    private void SpawnEnemy(int index)
    {
        enemies[index] = Instantiate(enemyPrefab) as GameObject;
        enemies[index].transform.position = spawnPoint;
      //  float angle = Random.Range(0, 360); // Random rotation angle
      //  enemies[index].transform.Rotate(0, angle, 0); // Apply rotation
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        Messenger<Enemy>.AddListener(GameEvent.SWORD_ARCHOR, OnSwordArchor);
        Messenger.AddListener(GameEvent.SWORD_BOSS, OnSwordBoss);
        Messenger.AddListener(GameEvent.ARROW_PLAYER, OnArrowPlayer);
        Messenger.AddListener(GameEvent.DEATH_ARCHOR, OnArchorDead);
        Messenger.AddListener(GameEvent.DEATH_BOSS, OnBossDead);
        Messenger.AddListener(GameEvent.PICKUP_BOTTLE, OnPickupBottle);
        Messenger.AddListener(GameEvent.NEXT_LEVEL, OnNextLevel);
        Messenger.AddListener(GameEvent.CHAT_KNIGHT, OnChatKnight);
    }
    private void OnDestroy()
    {
        Messenger<Enemy>.RemoveListener(GameEvent.SWORD_ARCHOR, OnSwordArchor);
        Messenger.RemoveListener(GameEvent.SWORD_BOSS, OnSwordBoss);
        Messenger.RemoveListener(GameEvent.ARROW_PLAYER, OnArrowPlayer);
        Messenger.RemoveListener(GameEvent.DEATH_ARCHOR, OnArchorDead);
        Messenger.RemoveListener(GameEvent.DEATH_BOSS, OnBossDead);
        Messenger.RemoveListener(GameEvent.PICKUP_BOTTLE, OnPickupBottle);
        Messenger.RemoveListener(GameEvent.NEXT_LEVEL, OnNextLevel);
        Messenger.RemoveListener(GameEvent.CHAT_KNIGHT, OnNextLevel);
    }
    private void OnSwordArchor(Enemy ar)
    {
        for (int i = 0; i < enemyNumber; i++)
        {
            if (enemies[i])
            {
                if (enemies[i].GetComponent<Enemy>() == ar)
                    ar.TakeDamage(damageEnemy);
            }
        }
        
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

    private void OnBossDead()
    {
        manager.UpdateScore(100);
    }

    private void OnPickupBottle()
    {
        Debug.Log("OnPickupBottle");
        manager.updateinventory();
    }

    private void OnNextLevel()
    {
        SceneManager.LoadScene("NextLevel_Scene");
    }

    private void OnChatKnight() 
    {
        manager.updateDialog();
    }
}
