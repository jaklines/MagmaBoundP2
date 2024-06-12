using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ColetaMoedas : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private int collectedCoins = 0;
    public bool gameOver = false;

    float timer = 90f;

    public GameObject VictoryScene;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Moeda"))
        {
            Destroy(other.gameObject);
            collectedCoins++;

            if (collectedCoins >= 10)
            {
                VictoryScene.SetActive(true);
                Debug.Log("Você coletou todas as moedas!");
            }
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = "Time Left: " + (int)timer;

        if (timer <= 0)
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        if (collectedCoins < 10)
        {
            Debug.Log("Tempo esgotado! Você não coletou todas as moedas a tempo.");
            Destroy(gameObject);
            gameOver = true;

            if (gameOver == true)
            {
                SceneManager.LoadScene("GameOverScene");

            }
        }
    }
}