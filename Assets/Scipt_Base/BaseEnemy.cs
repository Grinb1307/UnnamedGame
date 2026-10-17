
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BaseEnemy : MonoBehaviour
{
    public int MaxHP = 1;

    public GameObject Bullet;

    public float timer_ban = 0f;
    public int CurrentHP;


    public bool isDead = false;

    public Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        CurrentHP = MaxHP;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(GameManager._i.isPause == true)
        {
            Debug.Log("Stop");
            return;
        }
        Move();
        Shoot();
    }

    protected virtual void Shoot()
    {
        timer_ban += Time.deltaTime;
        if(timer_ban > 4f)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
            timer_ban = 0;
        }

    }

    protected virtual void Move()
    {

    }

    protected virtual void TakeDMG(int take_dmg)
    {
        CurrentHP -= take_dmg;
            
        if(CurrentHP <= 0)
        {
            gameObject.tag = "Untagged";
            Destroy(GetComponent<Collider2D>());
            isDead = true;
            EnemyManager.count_number_Map1--;
            GameManager._i.coin++;
            if (anim != null && HasParameter(anim, "isDead"))
            {
                anim.SetTrigger("isDead");
                Destroy(gameObject, 1.000f);
            }
            else
            {
                // Quái không có animation thì xóa ngay
                Destroy(gameObject);
            }
        }
    }

    // Hàm kiểm tra an toàn: Xem Animator Controller có chứa Parameter tên paramName không
    private bool HasParameter(Animator animator, string paramName)
    {
        if (animator == null) return false;

        foreach (AnimatorControllerParameter param in animator.parameters)
        {
            if (param.name == paramName) return true;
        }
        return false;
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.y <= 4.6f)
        {
            if (collision.CompareTag("Bullet_Player"))
            {
                IntroGun bullet = collision.GetComponent<IntroGun>();
                TakeDMG(bullet.Current_dmg);
            }
        }
    }

    
}
