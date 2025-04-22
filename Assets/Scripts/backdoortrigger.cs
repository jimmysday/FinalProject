using UnityEngine;

public class backdoortrigger : MonoBehaviour
{
    [SerializeField] private backdoorcontroll backdoor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter");
        if (other.tag == "Player")
        {
            Debug.Log("enter trigger");
            backdoor.Operate();
        }
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("trigger Exit");
        if (other.tag == "Player")
        {
            Debug.Log("exit trigger");
            backdoor.Operate();
        }
    }
}
