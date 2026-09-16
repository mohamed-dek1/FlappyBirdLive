using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    private int playerOneScore = 0;
    private int playerTwoScore = 0;
    private bool playerOneAlive = true;
    private bool playerTwoAlive = true;

    public static GameControl instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    public TextMeshProUGUI playerOneScoreText;
    public TextMeshProUGUI playerTwoScoreText;
    public GameObject instructions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instructions.SetActive(false);
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
       if (gameOver && (Mouse.current.leftButton.wasPressedThisFrame || Keyboard.current.spaceKey.wasPressedThisFrame))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            instructions.SetActive(false);
        } 
    }

    public void BirdScored(int ID)
    {
        if (gameOver)
        {
            return;
        }

        if (ID == 1)
        {
            playerOneScore++;
            playerOneScoreText.text = "Player 1 Score: " + playerOneScore.ToString();
        } else if (ID == 2)
        {
            playerTwoScore++;
            playerTwoScoreText.text = "Player 2 Score: " + playerTwoScore.ToString();
        }
        
    }

    public void BirdDied(int ID)
    {
        if (ID == 1)
        {
            playerOneAlive = false;
        } else if (ID == 2)
        {
            playerTwoAlive = false;
        }
        if (!playerOneAlive && !playerTwoAlive)
        {
            gameOverText.SetActive(true);
            gameOver = true;
            instructions.SetActive(true);
        }
    }
}
