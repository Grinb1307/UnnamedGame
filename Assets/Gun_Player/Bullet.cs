using Unity.VisualScripting;
using UnityEngine;

public class BulletTest : MonoBehaviour
{
    public int dmg = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 5;
        this.transform.position += new Vector3(0,1f,0) * speed * Time.deltaTime;
        DestroyBullet();
    }
    void DestroyBullet()
    {
        Camera cam = Camera.main;
        // Lấy góc Dưới-Trái và Trên-Phải của Camera
        float distance = Mathf.Abs(transform.position.z - cam.transform.position.z);
        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, distance));

        if(this.transform.position.y > topRight.y)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra xem va chạm có phải là Kẻ địch/Target không 
        if (collision.CompareTag("Enemy"))
        {
            // Gây sát thương cho kẻ địch

            // QUAN TRỌNG: Hủy ngay viên đạn tại đây để không bay tiếp sang con đằng sau
            Destroy(gameObject);
        }
    }
}
