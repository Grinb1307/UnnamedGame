using UnityEngine;

public class EnemyFlyToPosition : BaseEnemy
{
    [SerializeField] private float flySpeed = 7f; // Tốc độ bay vào đội hình
    private Vector3 targetLocalPosition;
    private bool isInPosition = false;

    public void SetTargetPosition(Vector3 localTarget)
    {
        targetLocalPosition = localTarget;
        isInPosition = false;
    }

    protected override void Move()
    {
        if (!isInPosition)
        {
            // 1. Bay mượt vào vị trí
            transform.localPosition = Vector3.MoveTowards(
                transform.localPosition,
                targetLocalPosition,
                flySpeed * Time.deltaTime
            );

            if (Vector3.Distance(transform.localPosition, targetLocalPosition) < 0.01f)
            {
                transform.localPosition = targetLocalPosition;
                isInPosition = true;
            }
        }
        else
        {
            // 2. Đã vào vị trí -> Gọi lại logic Move() mặc định của Class Cha (VD: lắc ngang theo đội hình)
            base.Move();
        }
    }
}