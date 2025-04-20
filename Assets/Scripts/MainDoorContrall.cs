using UnityEngine;

public class MainDoorContrall : MonoBehaviour
{
    private bool doorIsOpen = false;
    private Vector3 homePos;
    private Vector3 closeOffset = new Vector3(-1.5f, 0, 0);

    //private Quaternion closedRotation;
    //private Quaternion openRotation;
    private float moveTime = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        homePos = transform.position;
        //closedRotation = transform.rotation;
        //openRotation = Quaternion.Euler(0, 90, 0) * closedRotation; // Rotate door 90 degrees on Y-axis
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Operate()
    {
        //if (doorIsOpen)
        //{
        //    Debug.Log("Closing door");
        //    iTween.RotateTo(this.gameObject, closedRotation.eulerAngles, moveTime);
        //}
        //else
        //{
        //    Debug.Log("Opening door");
        //    iTween.RotateTo(this.gameObject, openRotation.eulerAngles, moveTime);
        //}
        //doorIsOpen = !doorIsOpen;

        if (doorIsOpen)
        {
        //    Debug.Log("close door");
            iTween.MoveTo(this.gameObject, homePos, moveTime);
        }
        else
        {
       //     Debug.Log("open door");
            iTween.MoveTo(this.gameObject, homePos + closeOffset, moveTime);
        }
        doorIsOpen = !doorIsOpen;
    }
}
