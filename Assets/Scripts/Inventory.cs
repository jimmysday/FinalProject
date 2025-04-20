using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
    //public void OnSettingsButton()
    //{
    //    Debug.Log(“settings clicked”);
    //}
    //public void OnExitGameButton()
    //{
    //    Debug.Log(“exit game”);
    //    Application.Quit();
    //}
    public void OnReturnToGameButton()
    {
        Debug.Log("return to game");
        Close();
    }
}
