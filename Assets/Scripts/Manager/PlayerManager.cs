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

    private IMouseAttack[] mouseAttackArr = null;

    private IMouseWorldPosProvider mouseWorldPosProvider = null;

    private bool devMode = false;

    public void Init(IMouseWorldPosProvider _mouseWorldPosProvider, bool _devMode)
    {
        mouseWorldPosProvider = _mouseWorldPosProvider;
        devMode = _devMode;
        mouseAttackArr = new IMouseAttack[(int)EMouseAttackTypes.LENGTH];
        mouseAttackArr[(int)EMouseAttackTypes.EXPLOSION] = explosion;
        mouseAttackArr[(int)EMouseAttackTypes.SPREAD_MISSILE] = spreadMissile;

        castle.Init();
        explosion?.Init();
        spreadMissile?.Init();
        StartCoroutine(nameof(AttackCoroutine));
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
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
