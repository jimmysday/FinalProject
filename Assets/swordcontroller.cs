using UnityEngine;

public class swordcontroller : MonoBehaviour
{
    public GameObject Sword;
    public GameObject HitParticle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "archer")
        {
            other.GetComponent<Animator>().SetTrigger("Hit");
        }
    }
}
