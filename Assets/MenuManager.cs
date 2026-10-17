using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame

    public void LoadSceneMainGame()
    {
        // Đã thay “MainGame” thành "MainGame"
        UnityEngine.SceneManagement.SceneManager.LoadScene("PickCharacter");
    }
}
