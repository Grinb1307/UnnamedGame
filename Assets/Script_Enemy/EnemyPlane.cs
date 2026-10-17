using UnityEngine;

public class EnemyPlane : MonoBehaviour
{
    public BulletAngle bulletPrefab;

    public float thoi_gian_lan_ban = 2; //2 giây bắn 1 lần
    public float timer_lan_ban = 0; //cái timer đếm giờ giữa các lần bắn
    public float thoi_gian_vien_ban = 0.2f; //2 giây bắn 1 lần
    public float timer_vien_ban = 0; //cái timer đếm giờ giữa các viên bắn
    public int so_vien_can_ban = 6; //cần bắn 6 viên
    public int so_vien_da_ban = 0; // Số viên đã bắn trong đợt hiện tại (0 -> 6)

    // Update is called once per frame
    void Update()
    {
        //Chưa đủ 2s
        if (timer_lan_ban < thoi_gian_lan_ban)
        {
            timer_lan_ban += Time.deltaTime;
        }
        //đã đủ 2s -> bắn từng viên
        else
        {
            //chưa bắn đủ 6 viên
            if (so_vien_da_ban < so_vien_can_ban)
            {
                timer_vien_ban += Time.deltaTime;
                if (timer_vien_ban >= thoi_gian_vien_ban)
                {
                    timer_vien_ban = 0f;

                    // Tính góc bắn: 360 / 6 = 60 độ mỗi viên
                    float angle = so_vien_da_ban * 60f;

                    if (bulletPrefab != null)
                    {
                        BulletAngle bullet = Instantiate(bulletPrefab,
                            transform.position,
                            Quaternion.identity);
                        bullet.angle_ban = angle;
                    }
                    so_vien_da_ban += 1;
                }
            }
            //đã bắn đủ -> reset hết
            else
            {
                so_vien_da_ban = 0;
                timer_lan_ban = 0;
                timer_vien_ban = 0;
            }
        }
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BulletTest>())
        {
             Destroy(this.gameObject);
            
        }
    }
}