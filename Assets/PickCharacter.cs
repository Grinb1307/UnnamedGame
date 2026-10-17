using UnityEngine;
using UnityEngine.SceneManagement;

public class PickCharacter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static GameObject ChosenCharacterObject;

    public void SelectCharacterObject(GameObject characterObj)
    {
        ChosenCharacterObject = characterObj;

        // Giữ GameObject này không bị xóa khi load sang MainGame
        DontDestroyOnLoad(characterObj);

        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");
    }
}
