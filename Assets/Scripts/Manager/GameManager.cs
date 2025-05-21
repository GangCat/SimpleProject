using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool devMode;

    ObjectPoolManager poolMng = null;
    CameraManager camMng = null;
    PlayerManager playerMng = null;
    EnemyManager enemyMng = null;
    CanvasManager canvasMng = null;

    private void Start()
    {
        Debug.Log("Game Start!");
        Application.targetFrameRate = 60;

        Findmanagers();

        var command = new CommandShowDamageText(canvasMng.GetCanvasDamageText);

        InitManagers(command);
    }

    private void Findmanagers()
    {
        camMng = FindAnyObjectByType<CameraManager>();
        playerMng = FindAnyObjectByType<PlayerManager>();
        enemyMng = FindAnyObjectByType<EnemyManager>();
        canvasMng = FindAnyObjectByType<CanvasManager>();
    }

    private void InitManagers(ICommand _cmd)
    {
        camMng.Init();
        playerMng.Init(camMng, devMode);
        enemyMng.Init(_cmd);
        canvasMng.Init();
    }
}
