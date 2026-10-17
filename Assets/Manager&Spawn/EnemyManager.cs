using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static float count_number_Map1 = 11f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckEnemyMap1();
    }

    public void CheckEnemyMap1()
    {
        if (count_number_Map1 == 0f)
        {
            GameManager._i.isWin = true;
        }
    }
}
