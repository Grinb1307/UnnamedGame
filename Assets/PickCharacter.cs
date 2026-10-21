using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PickCharacter : MonoBehaviour
{
    // Biến static để giữ ảnh máy bay xuyên qua Scene mới
    public static Sprite PlaneSprite;

    public void ChooseThisPlane()
    {
        // Vì script đã gắn TRỰC TIẾP lên nút First, 
        // GetComponent<Image>() sẽ lấy đúng Image của nút First!
        Image img = GetComponent<Image>();

        if (img != null && img.sprite != null)
        {
            PlaneSprite = img.sprite; // Lưu lại Sprite của máy bay này
            Debug.Log("Đã chọn máy bay: " + PlaneSprite.name);

            // Chuyển sang MainGame (Lưu ý: Tên Scene phải chính xác)
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");
        }
    }
}