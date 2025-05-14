using System.Collections;
using UnityEngine;

public class TempCastle : MonoBehaviour, IDamagable
{
    [SerializeField]
    private float maxHp = 100;
    [SerializeField]
    private float curHp = 100;
    [SerializeField]
    private float invincibleTime = 0.5f;
    [SerializeField]
    private bool isInvincible = false;

    private WaitForSeconds invincibleDelay = null;

    public void Init()
    {
        curHp = maxHp;
        invincibleDelay = new WaitForSeconds(invincibleTime);
    }

    public void Damaged(float _dmg)
    {
        if (isInvincible)
            return;

        curHp -= _dmg;
        if(curHp <= 0)
        {
            Debug.Log("Ä³½½ÀÌ ÆÄ±«µÊ.");
            GetComponent<Collider2D>().enabled = false;
        }
        StartCoroutine(nameof(InvincibleCoroutine));
    }

    private IEnumerator InvincibleCoroutine()
    {
        isInvincible = true;
        yield return invincibleDelay;
        isInvincible = false;
    }
}
