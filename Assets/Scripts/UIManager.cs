using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
    void Start()
    {
        UpdateScore(playerscore);
        UpdateHealth(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth(float newHealth)
    {
        playerhealth -= newHealth;
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
}
