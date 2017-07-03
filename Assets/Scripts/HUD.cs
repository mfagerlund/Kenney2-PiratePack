using UnityEngine;

public class HUD : MonoBehaviour
{
    public Sprite heartFull;
    public Sprite heartHalf;
    public Sprite heartEmpty;


    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;


    public void Update()
    {
        bool halfDead = false;
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            var healthed = player.GetComponent<Healthed>();
            halfDead = healthed.currentHealth < healthed.maxHealth * 0.5f;
        }
        SetHeartStatus(heart3, 3, halfDead);
        SetHeartStatus(heart2, 2, halfDead);
        SetHeartStatus(heart1, 1, halfDead);

    }

    private void SetHeartStatus(GameObject heart, int cutoff, bool halfDead)
    {
        if (GameManager.Instance.livesLeft == cutoff && halfDead)
        {
            heart.GetComponent<SpriteRenderer>().sprite = heartHalf;
        }
        else if (GameManager.Instance.livesLeft >= cutoff)
        {
            heart.GetComponent<SpriteRenderer>().sprite = heartFull;
        }
        else
        {
            heart.GetComponent<SpriteRenderer>().sprite = heartEmpty;
        }
    }
}
