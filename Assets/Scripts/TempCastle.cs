using UnityEngine;

public class TempCastle : MonoBehaviour, IDamagable
{
    [SerializeField]
    private float maxHp = 100;
    [SerializeField]
    private float curHp = 100;

    public void Init()
    {
        curHp = maxHp;
    }

    public void Damaged(float _dmg)
    {
        curHp -= _dmg;
        if(curHp <= 0)
        {
            Debug.Log("Ä³½½ÀÌ ÆÄ±«µÊ.");
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
