using System.Collections;
using UnityEngine;

public class TreasureCotroller : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private BottleRotate bottle;
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
        Debug.Log("OnTriggerEnter");
        if (other.tag == "Player")
        {
            anim.SetTrigger("treasureOpen");
            StartCoroutine(Showbottle());
        }
    }

    private IEnumerator Showbottle()
    {
        // Enemy falls over and disappears after two seconds
        //iTween.RotateAdd(this.gameObject, new Vector3(-75, 0, 0), 1);

        yield return new WaitForSeconds(0.5f);
       // Destroy(this.gameObject);
        bottle.gameObject.SetActive(true);
    }
}
