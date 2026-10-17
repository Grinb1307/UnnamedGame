using UnityEngine;

public class PegasusEnemy : BaseEnemy
{
    public float speed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Shoot()
    {

    }


    protected override void Move()
    {
        if (isDead)
        {
            return;
        }
        Vector3 dir = Vector3.down; // Tương đương new Vector3(0, -1, 0)

        // 2. Cộng vị trí theo hướng * tốc độ * thời gian
        transform.position += dir * speed * Time.deltaTime;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if(transform.position.y <= 4.6f)
        {
            if (collision.CompareTag("Bullet_Player") || collision.CompareTag("Player"))
            {
                TakeDMG(CurrentHP);
            }
        }
    }
}
