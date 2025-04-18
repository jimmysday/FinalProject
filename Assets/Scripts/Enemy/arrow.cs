using UnityEngine;

public class arrow : MonoBehaviour
{
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
        //Debug.Log("OnTriggerEnter arrow");
        Player_NM player = other.GetComponent<Player_NM>();
        if (player != null)
        {
            player.Hit();
            Destroy(this.gameObject);
        }
        
    }
}
