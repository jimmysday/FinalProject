using UnityEditor.VersionControl;
using UnityEngine;

public class swordcontroller : MonoBehaviour
{
    //public GameObject Sword;
    public GameObject HitParticle;
    [SerializeField] AudioSource ac;
    [SerializeField] Player_NM player;
    [SerializeField] Enemy_NM boss;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "archer")
        {
     //       Animator anim = player.GetComponent<Animator>();
            // Get the current Animator state
      //      AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0); // 0 is the base layer
      //      Debug.Log("sword: " + stateInfo.ToString());
            // Check if the current state is "Idle"
     //       if (stateInfo.IsName("Slash"))
            {
                
                //other.GetComponent<Animator>().SetTrigger("Hit");
                Messenger<Enemy>.Broadcast(GameEvent.SWORD_ARCHOR, (Enemy)(other.GetComponent<Enemy>()));
                ac.Play();
                HitParticle.GetComponent<ParticleSystem>().Play();
                //Instantiate(HitParticle,new Vector3(other.transform.position.x,
                //    transform.position.y, other.transform.position.z), 
                //    other.transform.rotation);

            }
        }
        else if(other.tag == "Boss")
        {
            Debug.Log("attack boss");
            Messenger.Broadcast(GameEvent.SWORD_BOSS);
            ac.Play();
            HitParticle.GetComponent<ParticleSystem>().Play();
           // boss.TakeDamage(50);           
        }
    }
}
