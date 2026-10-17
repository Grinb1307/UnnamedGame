using UnityEngine;
using UnityEngine.UI; // Bắt buộc khai báo để đọc UI Image

public class PlayerSetup : MonoBehaviour
{
    void Start()
    {
        // 1. Kiểm tra máy bay đã được chọn từ Scene PickCharacter chưa
        if (PickCharacter.ChosenCharacterObject != null)
        {
            // 2. Lấy component Image từ máy bay UI đã chọn
            Image chosenImage = PickCharacter.ChosenCharacterObject.GetComponent<Image>();

            if (chosenImage != null && chosenImage.sprite != null)
            {
                // 3. Tìm SpriteRenderer ở GameObject con (chính là 'Plane' trong Hierarchy)
                SpriteRenderer playerRenderer = GetComponentInChildren<SpriteRenderer>();

                if (playerRenderer != null)
                {
                    // 4. Gán Sprite mới
                    playerRenderer.sprite = chosenImage.sprite;
                }
            }

            // 5. Xóa GameObject trung gian cho sạch bộ nhớ
            Destroy(PickCharacter.ChosenCharacterObject);
        }
    }
}