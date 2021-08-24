using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
    PlayerUI playerUI;
   // GameOver gameOver;
    private void Start()
    {
        playerUI = GetComponent<PlayerUI>();
       // gameOver = GetComponent<GameOver>();
        maxHealth = 100;
        currhealth = maxHealth;

        Setstats();
    }
    public override void die()
    {
        Debug.Log("YOu died!");
        SceneManager.LoadScene("Game Over");
    }
    void Setstats()
    {
        playerUI.healthPlayer.text =  currhealth.ToString();
    }

    public override void CheckHealth()
    {
        base.CheckHealth();
        Setstats();
    }
}
