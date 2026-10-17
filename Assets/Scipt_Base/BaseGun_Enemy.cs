using UnityEngine;

public class BaseGun_Enemy : BaseGun
{



    protected override void Move()
    {

        float speed = 1f;
        Vector3 DirectionGun = new Vector3(0, -5f, 0);
        transform.position += speed * DirectionGun * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
