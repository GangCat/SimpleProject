using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Game Start!");

        // �ӽ÷� �ѰŰ� ī�޶� �Ŵ��� �����?
        CameraManager camMng = FindAnyObjectByType<CameraManager>();
        camMng.Init();

        PlayerManager playerMng = FindAnyObjectByType<PlayerManager>();
        playerMng.Init();
    }

}
