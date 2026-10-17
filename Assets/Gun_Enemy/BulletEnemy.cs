using Unity.VisualScripting;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 5;
        this.transform.position += new Vector3(0, -5f, 0) * speed * Time.deltaTime;
        DestroyBullet();
    }
    void DestroyBullet()
    {
        Camera cam = Camera.main;
        // Lấy góc Dưới-Trái và Trên-Phải của Camera
        float distance = Mathf.Abs(transform.position.z - cam.transform.position.z);
        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(1, 1, distance));
        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(0, 0, distance));

        if (this.transform.position.y < topRight.y)
        {
            Destroy(this.gameObject);
        }
    }
}
