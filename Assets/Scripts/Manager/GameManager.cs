using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Game Start!");

        // 임시로 한거고 카메라 매니저 만들듯?
        CameraManager camMng = FindAnyObjectByType<CameraManager>();
        camMng.Init();

        PlayerManager playerMng = FindAnyObjectByType<PlayerManager>();
        playerMng.Init();
    }

}
