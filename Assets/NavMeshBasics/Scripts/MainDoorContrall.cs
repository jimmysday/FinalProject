using UnityEngine;

public class MainDoorContrall : MonoBehaviour
{
    private bool doorIsOpen = false;
    private Vector3 homePos;
    private Vector3 closeOffset = new Vector3(-2, 0, 0);
    private float moveTime = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        homePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Operate()
    {
        Debug.Log("trigger door");
        if (doorIsOpen)
        {
            iTween.MoveTo(this.gameObject, homePos, moveTime);
        }
        else
        {
            iTween.MoveTo(this.gameObject, homePos + closeOffset, moveTime);
        }
        doorIsOpen = !doorIsOpen;
    }
}
