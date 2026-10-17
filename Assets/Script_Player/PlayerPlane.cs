using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class PlayerPlane : MonoBehaviour
{

    public static PlayerPlane plane;

    private void Awake()
    {
        plane = GetComponent<PlayerPlane>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Bullet1_Player;
    public float speed = 5f;
    public int CurrentHP =1;
    private float halfWidth;
    private float halfHeight;

    float timer_ban = 0;
    void Start()
    {
        Application.targetFrameRate = 60;

        
        // Lấy kích thước của Sprite máy bay (lấy từ con nếu có) để không bị lòi cánh ra ngoài viền
        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        if (sr != null)
        {
            halfWidth = sr.bounds.extents.x;
            halfHeight = sr.bounds.extents.y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager._i.isPause == true)
        {
            return;
        }
        Move();
        Shoot();

    }
    void Shoot()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            timer_ban += Time.deltaTime;
            if (timer_ban >= 0.5f)
            {
                Instantiate(Bullet1_Player, transform.position, Quaternion.identity);
                timer_ban = 0;
            }
        }
    }

    void Move()
    {
        if(!(Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow)))
        {
            Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
            transform.position += direction * speed * Time.deltaTime;
        }

        // Lock không cho Character di chuyển ra khỏi Screen (Dùng Camera.main Bound feature)
        ClampToScreen();
       
    }


    /// <summary>
    /// Tính toán Bound của Camera.main để khóa nhân vật luôn nằm trong khung hình Screen
    private void ClampToScreen()
    {
        Camera cam = Camera.main;
        if (cam == null) return;

        // Khoảng cách Z từ Camera đến máy bay
        float distance = Mathf.Abs(transform.position.z - cam.transform.position.z);

        // Lấy góc Dưới-Trái và Trên-Phải của Camera
        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, distance));

        // Khóa vị trí tâm máy bay không vượt quá viền màn hình
        float clampedX = Mathf.Clamp(transform.position.x, bottomLeft.x + halfWidth, topRight.x - halfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, bottomLeft.y + halfHeight, topRight.y - halfHeight);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            CurrentHP = 0;
            Destroy(this.gameObject);
        }
        else if(collision.CompareTag("Pegasus"))
        {
            Destroy(this.gameObject);
        }
        GameManager._i.LoseGame();
    }
    private void Oke()
    {
    }
}
