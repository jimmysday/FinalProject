using UnityEngine;
using UnityEngine.EventSystems;

public class bloodpot : baseUI, IPointerClickHandler
{
    [SerializeField] private AudioSource au;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playaudio()
    {
        au.Play();
    }
    public void OnItemClicked()
    {
        Debug.Log("Image clicked via Event Trigger!");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Item clicked: " + gameObject.name);
    }
}
