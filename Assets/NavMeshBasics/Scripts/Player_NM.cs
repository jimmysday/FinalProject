using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player_NM : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private NavMeshAgent agent;    // for moving on the NavMesh
    [SerializeField] private Camera cam;            // for shooting a ray into the 3D world

    private void Start()
    {
        //agent.SetDestination(Vector3.zero);  // go to [0,0,0]
    }

    private void Update()
    {
        CalculateAnimVelocity();
        if (Input.GetMouseButton(0))     // did we left click with the mouse?
        {
            Debug.Log("mouse down");
            // extend a ray from the camera into the 3D world that points at the mouse click location
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            // check if the ray hits any world colliders
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);    // set the agent's destination to the ray's hit point
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

}
