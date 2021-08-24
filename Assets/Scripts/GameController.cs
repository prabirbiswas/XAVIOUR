using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public int score;
    public int updScore;
    [SerializeField]
    public Text ScoreCounter;
    [SerializeField]
    public Text LevelCompScore;

    [SerializeField]
    public AudioClip coinPickup;
    public int MoneyAmount;
    public int updateMoney;

    [SerializeField]
    public Text coinCounter;

    [SerializeField]
    public Text LevelCompCoin;



    void Start()
    {
        
        MoneyAmount = PlayerPrefs.GetInt("prefs_coin");
        score = PlayerPrefs.GetInt("pref_Score");

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<coin>())
        {
            MoneyAmount += 1;
            AudioSource.PlayClipAtPoint(coinPickup, transform.position, 1f);
            Destroy(collision.gameObject);
        }
    }

    public void scoreInc()
    {
        score += 25;
        ScoreCounter.text = "" + score.ToString();
        LevelCompScore.text = "" + score.ToString();
    }

    public void money()
    {
        coinCounter.text = "" + MoneyAmount.ToString();
        LevelCompCoin.text = "" + MoneyAmount.ToString();
    }

    

    public void update()
    {
        PlayerPrefs.SetInt("prefs_coin", MoneyAmount);
        PlayerPrefs.SetInt("pref_Score", score);
        
    }
   

}
