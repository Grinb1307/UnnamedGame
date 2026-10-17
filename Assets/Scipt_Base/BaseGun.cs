using UnityEngine;

public class BaseGun : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int base_dmg = 2;

    public int MaxDMG = 100;

    public int Current_dmg;
    void Start()
    {
        Current_dmg = base_dmg;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        float speed = 5f;
        Vector3 DirectionGun = new Vector3(0, 5f, 0);
        transform.position += speed * DirectionGun * Time.deltaTime;
    }


}
