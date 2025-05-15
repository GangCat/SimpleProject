using System.Collections;
using UnityEngine;

public class TempMissile : MonoBehaviour
{
    private float disappearTime = 0f;
    private float moveSpeed = 0f;
    private float dmg = 0;
    private int enemyLayerMask = -1;

    public void Init(float _dmg, float _disappearTime, float _moveSpeed)
    {
        enemyLayerMask = LayerMask.GetMask("Enemy");
        disappearTime = _disappearTime;
        moveSpeed = _moveSpeed;
        dmg = _dmg;
        gameObject.SetActive(false);
    }

    public void Upgrade(float _dmg, float _disappearTime, float _moveSpeed)
    {
        if(_dmg <= 0 || _disappearTime <= 0 || _moveSpeed <= 0)
        {
            Debug.LogError("미사일 업그레이드 매개변수 값이 음수입니다.");
            return;
        }    
        dmg = _dmg;
        disappearTime = _disappearTime;
        moveSpeed = _moveSpeed;
    }

    public void Launch(Vector2 _startPos, Vector2 _dir)
    {
        Debug.Log($"{gameObject.name} : Launch!");
        gameObject.SetActive(true);
        transform.position = _startPos;
        transform.up = _dir;
        StartCoroutine(nameof(MoveCoroutine));
    }

    private IEnumerator MoveCoroutine()
    {
        float elapsedTime = 0f;
        while(elapsedTime < disappearTime)
        {
            transform.position += transform.up * moveSpeed * Time.deltaTime;

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        _collision.GetComponent<IDamagable>().Damaged(dmg);
    }
}
