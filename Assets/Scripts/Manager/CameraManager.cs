using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private Transform mousePosIndiTr = null;
    [SerializeField]
    private Transform explosionIndiTr = null;

    private Camera cam = null;
    private Transform myTr = null;
    private Coroutine mousePointIndiCor = null;
    private Coroutine explosionIndiCor = null;

    private WaitForSeconds explosionDelay = null;

    private Vector3 curMouseWorldPos = Vector3.zero;
    public void Init()
    {
        cam = Camera.main;

        explosionDelay = new WaitForSeconds(1f);
        mousePointIndiCor = StartCoroutine(MousePointIndiCoroutine());
        explosionIndiCor = StartCoroutine(ExplosionIndiCoroutine());
    }

    private IEnumerator MousePointIndiCoroutine()
    {
        while (true)
        {
            Vector3 mouseScreenPos = Input.mousePosition;
            mouseScreenPos.z = 0f; // 2D에서는 z는 보통 0
            curMouseWorldPos = cam.ScreenToWorldPoint(mouseScreenPos);
            curMouseWorldPos.z = 0f; // 확실히 z 고정

            mousePosIndiTr.position = curMouseWorldPos;

            yield return null;
        }
    }

    private IEnumerator ExplosionIndiCoroutine()
    {
        while (true)
        {
            yield return explosionDelay;

            explosionIndiTr.position = curMouseWorldPos;
        }
    }

}
