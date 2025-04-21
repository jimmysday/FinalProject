using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textscore;
    private float playerscore = 0;
    private float playerlevel = 1;

    [SerializeField] private TextMeshProUGUI textplayer;
    private float playerhealth = 100f;
    private float maxhealth = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private Image healthFill;
    [SerializeField] private Image levelFill;
    [SerializeField] private Inventory inventory;
    [SerializeField] private bloodpot bloodPot;
    void Start()
    {
        UpdateScore(playerscore);
        UpdateHealth(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!inventory.IsActive())
            {
                //SetGameActive(false);
                inventory.Open();
            }
            else
            {
                inventory.Close();
                //SetGameActive(true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (bloodPot.IsActive() )
            {
                bloodPot.playaudio();
                StartCoroutine(CloseAfterDelay());
            }
        }
    }

    private IEnumerator CloseAfterDelay()
    {
        yield return new WaitForSeconds(0.5f); // adjust based on your audio length
        bloodPot.Close();
        UpdateHealth(-50);
    }

    public void UpdateHealth(float newHealth)
    {
        playerhealth -= newHealth;
        if(playerhealth > 100)
        {
            playerhealth = 100;
        }
        textplayer.text = playerhealth.ToString() + "%";
        healthFill.fillAmount = playerhealth / maxhealth;
    }

    // update score display
    public void UpdateScore(float newScore)
    {
        playerscore += newScore;
        float nextlevelscore = playerlevel * playerlevel * 100;
        if (playerscore >= nextlevelscore)
        {
            playerlevel++;
            maxhealth *= playerlevel;
            UpdateHealth(0);
            nextlevelscore = playerlevel * playerlevel * 100;
        }
        textscore.text = playerscore.ToString() + "/" + nextlevelscore.ToString();
        levelFill.fillAmount = playerscore / nextlevelscore;
    }

    public void updateinventory()
    {
        bloodPot.gameObject.SetActive(true);
    }

    public void SetGameActive(bool active)
    {
        if (active)
        {
            Time.timeScale = 1; // unpause the game
            //Cursor.lockState = CursorLockMode.Locked; // lock cursor at center
            //Cursor.visible = false; // hide cursor
          //  crossHair.gameObject.SetActive(true); // show the crosshair
        }
        else
        {
            Time.timeScale = 0; // pause the game
            //Cursor.lockState = CursorLockMode.None; // let cursor move freely
            //Cursor.visible = true; // show the cursor
        //    crossHair.gameObject.SetActive(false); // turn off the crosshair
        }
    }
}
