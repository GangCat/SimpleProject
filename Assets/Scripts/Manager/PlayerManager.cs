using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private TempCastle castle = null;

    [SerializeField]
    private TempExplosion explosion = null;
    [SerializeField]
    private TempSpreadMissile spreadMissile = null;
    [SerializeField]
    private TempCircleDot circleDot = null;

    private IMouseActiveAttack[] mouseActiveAttackArr = null;
    private IMousePassiveAttack[] mousePassiveAttackArr = null;

    private IMouseWorldPosProvider mouseWorldPosProvider = null;

    private bool devMode = false;

    public void Init(IMouseWorldPosProvider _mouseWorldPosProvider, bool _devMode)
    {
        mouseWorldPosProvider = _mouseWorldPosProvider;
        devMode = _devMode;
        mouseActiveAttackArr = new IMouseActiveAttack[(int)EMouseActiveAttackType.LENGTH];
        mouseActiveAttackArr[(int)EMouseActiveAttackType.EXPLOSION] = explosion;
        mouseActiveAttackArr[(int)EMouseActiveAttackType.SPREAD_MISSILE] = spreadMissile;

        mousePassiveAttackArr = new IMousePassiveAttack[(int)EMousePassiveAttackType.LENGTH];
        mousePassiveAttackArr[(int)EMousePassiveAttackType.CIRCLE_DOT] = circleDot;

        castle.Init();
        explosion?.Init();
        spreadMissile?.Init();
        circleDot?.Init(mouseWorldPosProvider);
        StartCoroutine(nameof(AttackCoroutine));
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            for (int i = 0; i < mouseActiveAttackArr.Length; i++)
            {
                IMouseActiveAttack attack = mouseActiveAttackArr[i];
                if (attack == null)
                    continue;

                if (attack.CanAttack)
                    attack.Attack(mouseWorldPosProvider.MouseWorldPos);
            }

            yield return null;
        }
    }


}
