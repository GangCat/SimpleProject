using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mousePosIndiGo = null;
    [SerializeField]
    private GameObject explosionIndiGo = null;

    private Camera cam = null;
    private Transform myTr = null;
    private Coroutine mousePointIndiCor = null;
    private Coroutine explosionIndiCor = null;

    private WaitForSeconds explosionDelay = null;

    private Vector3 curMouseWorldPos = Vector3.zero;

    public void Init()
    {
        cam = GetComponent<Camera>();
        myTr = GetComponent<Transform>();

        explosionDelay = new WaitForSeconds(1f);
        mousePointIndiCor = StartCoroutine(nameof(mousePointIndiCoroutine));
        explosionIndiCor = StartCoroutine(nameof(explosionIndiCoroutine));
    }

    public float GetZPos()
    {
        return myTr.position.z;
    }

    public Vector3 ScreenToWorldPoint(Vector3 _mousePos)
    {
        return cam.ScreenToWorldPoint(_mousePos);
    }

    private IEnumerator mousePointIndiCoroutine()
    {
        while(true)
        {
            curMouseWorldPos = ScreenToWorldPoint(Input.mousePosition);
            curMouseWorldPos.z -= GetZPos();
            mousePosIndiGo.GetComponent<Transform>().position = curMouseWorldPos;
            yield return null;
        }
    }

    private IEnumerator explosionIndiCoroutine()
    {
        while(true)
        {
            yield return explosionDelay;

            explosionIndiGo.GetComponent<Transform>().position = curMouseWorldPos;
        }
    }

}
