using UnityEngine;

public class BulletAngle : MonoBehaviour
{
    public float angle_ban = 90;

    // Update is called once per frame
    void Update()
    {
        float speed = 9;
        // Xoay đạn theo góc angle_ban (xoay quanh trục Z)
        this.transform.rotation = Quaternion.Euler(0, 0, -angle_ban);


        Vector3 di_chuyen = new Vector3(
            x: Mathf.Sin(angle_ban * Mathf.Deg2Rad),
            y: Mathf.Cos(angle_ban * Mathf.Deg2Rad),
            0
        );

        this.transform.position += di_chuyen
            * Time.deltaTime
            * speed;
    }
}