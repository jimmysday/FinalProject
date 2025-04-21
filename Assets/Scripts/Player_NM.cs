using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Player_NM : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private NavMeshAgent agent;    // for moving on the NavMesh
    [SerializeField] private Camera cam;            // for shooting a ray into the 3D world
                                                    //[SerializeField] AudioSource ac;

    [SerializeField] private BottleRotate bottle;

    public LayerMask ground;
    public LayerMask playobject;

    private float actionRange = 2.0f;

    private int health;

    private void Start()
    {
        //agent.SetDestination(Vector3.zero);  // go to [0,0,0]
        health = 100;
    }

    private void Update()
    {
        CalculateAnimVelocity();
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))      // did we left click with the mouse?
        {
           // Debug.Log("mouse down");
            // extend a ray from the camera into the 3D world that points at the mouse click location
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            // check if the ray hits any world colliders
            RaycastHit hit;

    
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~0))
            {
                if (Input.GetMouseButton(0))
                {
                    //     Debug.Log(hit.point);
                    agent.SetDestination(hit.point);    // set the agent's destination to the ray's hit point
                    transform.LookAt(hit.point);
                    return ;
                }

                if (Input.GetMouseButton(1))
                {
                    GameObject clickedObject = hit.collider.gameObject;
  //                  Debug.Log("Hit object: " + hit.collider.gameObject.name + " Layer: " + hit.collider.gameObject.layer);

                    //if (((1 << clickedObject.layer) & playobject) != 0)
                    {
   //                     Debug.Log("Clicked on a layer: "+ clickedObject.layer +" playobject: "+playobject.value +" name:"+ clickedObject.name);
                        float distance = Vector3.Distance(transform.position, clickedObject.transform.position);

                        if (clickedObject.CompareTag("knight"))
                        {
                            Debug.Log("Clicked on a person: " + clickedObject.name);
     

                            Debug.Log("distance: " + distance);

                            if (distance < actionRange)
                            {
                                anim.SetTrigger("attack");
                                //Attack(clickedObject);
                            }
                        }
                        else if (clickedObject.CompareTag("Boss"))
                        {
                            Debug.Log("Clicked on an boss: " + clickedObject.name);
                            // Add item interaction logic here
                            if (distance < actionRange)
                            {
                                transform.LookAt(clickedObject.transform.position);
                                //        Debug.Log("attack on archer");
                                //        clickedObject.GetComponent<Animator>().SetTrigger("Hit");
                                anim.SetTrigger("attack");
                                // ac.Play();
                                //Attack(clickedObject);
                            }
                        }
                        else if (clickedObject.CompareTag("archer")){
                            if (distance < actionRange)
                            {
                                transform.LookAt(clickedObject.transform.position);
                        //        Debug.Log("attack on archer");
                        //        clickedObject.GetComponent<Animator>().SetTrigger("Hit");
                                anim.SetTrigger("attack");
                               // ac.Play();
                                //Attack(clickedObject);
                            }
                        }
                        else if (clickedObject.CompareTag("Bottle"))
                        {
                            Debug.Log("Found Bottle");
                            bottle.gameObject.SetActive(false);
                            Messenger.Broadcast(GameEvent.PICKUP_BOTTLE);
                        }
                    }

                    if (((1 << clickedObject.layer) & ground) != 0)
                    {
                        //Debug.Log("Clicked on the ground, do nothing.");
                        return;
                    }
                }

            }
            

        }


        if (Input.GetKeyDown(KeyCode.Space)) {
            anim.SetTrigger("attack");
        }
    }

    // Unused for now, but if later, you want to add animations, call this to determine velocity param for a 1D blend tree.
    void CalculateAnimVelocity()
    {
        anim.SetFloat("velocity", agent.velocity.magnitude / agent.speed);  // calculate % of full speed agent is moving
    }
    private void OnDrawGizmos()
    {
        if (cam != null)  // Ensure the camera reference exists
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);  // Get the ray from the camera
            Gizmos.color = Color.red;
            Gizmos.DrawLine(ray.origin, ray.origin + ray.direction * 100f);  // Extend the ray in the scene
        }
    }

    public void Hit()
    {
        
        health -= 5;
        //Debug.Log("Health: " + health);
        if (health == 0)
        {
            //Debug.Break();
            Debug.Log("Player dead");
        }
    }
}
