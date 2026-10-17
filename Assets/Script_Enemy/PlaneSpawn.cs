using UnityEngine;

public class PlaneSpawn : BaseEnemy
{
    float speed = 1.0f;
    Vector3 dir = Vector3.down;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Move()
    {
        if (isDead)
        {
            return;
        }
        transform.position += dir * speed * Time.deltaTime;
        Vector3 CheckPosition = transform.position;
        if (CheckPosition.y <= 0f)
        {
            Debug.Log("Canh bao di vuot qua nua map");
            dir = Vector3.up;
        }
        else if (CheckPosition.y >= 4.6f) {
            dir = Vector3.down;
        }
 
    }
}
