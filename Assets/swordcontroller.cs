using UnityEngine;

public class swordcontroller : MonoBehaviour
{
    public GameObject Sword;
    public GameObject HitParticle;
    [SerializeField] AudioSource ac;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "archer")
        {
            ac.Play();
            other.GetComponent<Animator>().SetTrigger("Hit");
            Instantiate(HitParticle,new Vector3(other.transform.position.x,
                transform.position.y, other.transform.position.z), 
                other.transform.rotation);
        }
    }
}
