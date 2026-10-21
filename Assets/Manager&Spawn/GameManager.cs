using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _i;
    public int coin;

    public bool isWin = false;

    public GameObject buttonReset;
    public void Awake()
    {
        _i = this;
        coin= 0;
    }
    void Start()
    {
        buttonReset.SetActive(false);
    }

    public void ResetGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuGame");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            PauseGame();
        }

        else if(PlayerPlane.plane.CurrentHP == 0)
        {
            Debug.Log("Lose");
        }
        else if(EnemyManager.count_number_Map1==0 && PlayerPlane.plane.CurrentHP > 0)
        {
            WinGame();
        }
    }
    public bool isPause = false;
    public bool isLose = false;
    public void WinGame()
    {
        if (isWin == true)
        {
            Debug.Log("Win");
        }
    }

    public void LoseGame()
    {
        buttonReset.SetActive(true);
        isLose = true;
    }
    public void PauseGame()
    {
        isPause = true;
    }
}