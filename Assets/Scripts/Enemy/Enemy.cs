using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float IdleTime { get; private set; } = 1.0f;         // time to spend in idle state
    public float ChaseRange { get; private set; } = 10.0f;      // when player is closer than this, chase
    public float AttackRange { get; private set; } = 5.0f;      // when player is closer than this, attack
    public float AttackRangeStop { get; private set; } = 7.0f; // when player is farther than this, chase

    public GameObject Player { get; private set; }
    public NavMeshAgent Agent { get; private set; }

    public List<Transform> Waypoints { get; private set; }      // waypoints for patrol state
    private int waypointIndex = 0;                              // current waypoint index

    [SerializeField] private GameObject projectilePrefab;       // for creating "bullets"
    [SerializeField] public Transform projectileSpawnPt;        // spawn point for bullets    
    private float projectileForce = 35f;                        // force to shoot the projectile with

    //[SerializeField] private enemyhealthbar healthbar;
    [SerializeField] private Image healthFill; // Drag the Fill Image here in the Inspector

    [SerializeField] Animator anim;
    //[SerializeField] private Enemy archor;

    private float maxHealth = 100f;
    private float currentHealth = 100f;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();                   // get a reference to the NavMeshAgent
        Agent.updateUpAxis = false;
        Player = GameObject.FindGameObjectWithTag("Player");    // get a reference to the Player
        currentHealth = maxHealth;

        // Create and populate a list of waypoints
        Waypoints = new List<Transform>();
        GameObject waypointsParent = GameObject.FindGameObjectWithTag("Waypoints");
        foreach (Transform t in waypointsParent.transform)
        {
            Waypoints.Add(t);
        }
    }

    void LateUpdate()
    {
        healthFill.transform.forward = Camera.main.transform.forward;
    }

    private void OnDrawGizmos()
    {
        //Draw a sphere to show chase range in Scene
        Gizmos.DrawWireSphere(transform.position, ChaseRange);
    }

    public float GetDistanceFromPlayer()
    {
        //Get the distance(in units) from the enemy to the player
        return Vector3.Distance(transform.position, Player.transform.position);
    }

    public void DetermineNextWaypoint()
    {
        //pick a random waypoint
        waypointIndex = Random.Range(0, Waypoints.Count);
        Debug.Log("waypointIndex: "+ waypointIndex);
    }

    public Vector3 GetCurrentWaypoint()
    {
        //return the current waypoint
        Debug.Log("CurrentWaypoint: " + Waypoints[waypointIndex].position);
        return Waypoints[waypointIndex].position;
    }

    // This method is triggered by the shooting animation
    public void ShootEvent()
    {
        // spawn a projectile using the spawnPoint
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPt.position, projectileSpawnPt.rotation);
        // move it forward
        // After instantiating, rotate it if needed
        //projectile.transform.Rotate(0, 90, 0); // Adjust value to correct the direction
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(-transform.right * projectileForce, ForceMode.Impulse);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        //currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth <= 0)
        {
            anim.SetTrigger("death");
            Messenger.Broadcast(GameEvent.DEATH_ARCHOR);
        }

        if (healthFill != null)
        {
            Debug.Log("tackeDamage: " + currentHealth);
            healthFill.fillAmount = currentHealth / maxHealth;
        }
    }
    private void DeadEvent()
    {
        Destroy(this.gameObject);
    }
}
