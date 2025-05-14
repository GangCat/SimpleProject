using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour, IMouseWorldPosProvider
{
    [SerializeField]
    private Transform mousePosIndiTr = null;

    private Camera cam = null;
    private Coroutine mousePointIndiCor = null;

    public Vector2 MouseWorldPos
    {
        get
        {
            return cam.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public void Init()
    {
        cam = Camera.main;
        mousePointIndiCor = StartCoroutine(MousePointIndiCoroutine());
    }



    private IEnumerator MousePointIndiCoroutine()
    {
        while (true)
        {
            mousePosIndiTr.position = MouseWorldPos;

            yield return null;
        }
    }

}
