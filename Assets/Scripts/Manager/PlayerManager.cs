using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mousePosIndiGo = null;

    [SerializeField]
    private CameraManager cam;

    [SerializeField]
    private TempCastle castle = null;

    [SerializeField]
    private TempExplosion explosion = null;

    private IMouseWorldPosProvider mouseWorldPosProvider = null;

    private IMouseAttack[] mouseAttackArr = null;

    private bool isDevMode = false;

    // TODO: 모든 기술을 사용하는 걸 하나의 코루틴으로 해야함
    // 그러니까 뭔 뜻이냐면 플레이어가 사용하는 모든 공격, 마우스로 하는 모든 공격은 동일한 인터페이스로
    // 그 인터페이스에서 뭐 Attack이라던가 하는 함수 호출해서 공격하게 하고
    // 그 각 공격들이 지금 자신이 공격 가능한지 여부 확인해서 인터페이스로 알려주고
    // 그러면 이제 성수라던가 그런거 어떻게 하지?
    // 일단 나타났다 사라지는 그런 애들은 어택일 때 생성되서 공격불가능ㅎ이라고 알려주면 되고
    // 문제는 성수같은 잔여 어택들임.
    // 개들도 일단 어택하면 호출된 위치에서 확 던져지고 던져진 애들은 어택의 자식이고 날아가서 충돌하면 잔여물 남게하고
    // 아니면 그 던진 순간부터 던져진 애들은 던져진 애들이고 쿨타임 돌게 하고
    // 대신에 잔여물 종료되야만 다시 던질 수 있도록 하기
    // 그럼 호출하는 쪽에서는 공격쿨타임 되었나? 되었다면 공격
    // 이거만 하면 됨

    public void Init(IMouseWorldPosProvider _mouseWorldPosProvider, bool _isDevMode)
    {
        mouseWorldPosProvider = _mouseWorldPosProvider;
        isDevMode = _isDevMode;
        mouseAttackArr = new IMouseAttack[(int)EMouseAttackTypes.LENGTH];
        mouseAttackArr[(int)EMouseAttackTypes.EXPLOSION] = explosion;

        castle.Init();
        explosion.Init();
        StartCoroutine(nameof(AttackCoroutine));
    }

    private IEnumerator AttackCoroutine()
    {
        while(true)
        {
            for (int i = 0; i < mouseAttackArr.Length; i++)
            {
                IMouseAttack attack = mouseAttackArr[i];
                if (attack == null)
                    continue;

                if (attack.CanAttack) 
                    attack.Attack(mouseWorldPosProvider.MouseWorldPos);
            }

            yield return null;
        }
    }


}
