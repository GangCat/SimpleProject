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

    // TODO: ��� ����� ����ϴ� �� �ϳ��� �ڷ�ƾ���� �ؾ���
    // �׷��ϱ� �� ���̳ĸ� �÷��̾ ����ϴ� ��� ����, ���콺�� �ϴ� ��� ������ ������ �������̽���
    // �� �������̽����� �� Attack�̶���� �ϴ� �Լ� ȣ���ؼ� �����ϰ� �ϰ�
    // �� �� ���ݵ��� ���� �ڽ��� ���� �������� ���� Ȯ���ؼ� �������̽��� �˷��ְ�
    // �׷��� ���� ��������� �׷��� ��� ����?
    // �ϴ� ��Ÿ���� ������� �׷� �ֵ��� ������ �� �����Ǽ� ���ݺҰ��ɤ��̶�� �˷��ָ� �ǰ�
    // ������ �������� �ܿ� ���õ���.
    // ���鵵 �ϴ� �����ϸ� ȣ��� ��ġ���� Ȯ �������� ������ �ֵ��� ������ �ڽ��̰� ���ư��� �浹�ϸ� �ܿ��� �����ϰ�
    // �ƴϸ� �� ���� �������� ������ �ֵ��� ������ �ֵ��̰� ��Ÿ�� ���� �ϰ�
    // ��ſ� �ܿ��� ����Ǿ߸� �ٽ� ���� �� �ֵ��� �ϱ�
    // �׷� ȣ���ϴ� �ʿ����� ������Ÿ�� �Ǿ���? �Ǿ��ٸ� ����
    // �̰Ÿ� �ϸ� ��

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
