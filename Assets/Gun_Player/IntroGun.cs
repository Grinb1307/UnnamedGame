using Unity.VisualScripting;
using UnityEngine;

public class IntroGun : BaseGun
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Move()
    {
          float speed = 5f;
          Vector3 DirectionGun = new Vector3(0, 5f, 0);
          transform.position += speed * DirectionGun * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
