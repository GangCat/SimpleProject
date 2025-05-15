using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool devMode;

    private void Start()
    {
        Debug.Log("Game Start!");
        Application.targetFrameRate = 60;

        InitManagers();
    }

    private void InitManagers()
    {
        ObjectPoolManager poolMng = FindAnyObjectByType<ObjectPoolManager>();

        CameraManager camMng = FindAnyObjectByType<CameraManager>();
        camMng.Init();

        PlayerManager playerMng = FindAnyObjectByType<PlayerManager>();
        playerMng.Init(camMng, devMode);

        EnemyManager enemyMng = FindAnyObjectByType<EnemyManager>();
        enemyMng.Init(poolMng);

    }
}
