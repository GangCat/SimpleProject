using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mousePosIndiGo = null;

    private Camera cam = null;
    private Transform myTr = null;
    private Coroutine mousePointIndiCor = null;

    public void Init()
    {
        cam = GetComponent<Camera>();
        myTr = GetComponent<Transform>();
        //mousePointIndiCor = StartCoroutine(nameof(mousePointIndiCoroutine));
    }

    public float getZPos()
    {
        return myTr.position.z;
    }

    public Vector3 ScreenToWorldPoint(Vector3 _mousePos)
    {
        return cam.ScreenToViewportPoint(_mousePos);
    }

    private IEnumerator mousePointIndiCoroutine()
    {
        while(true)
        {
            var newPos = ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("mousePos " + Input.mousePosition);
            Debug.Log("worldPos " + newPos);
            newPos.z -= getZPos();
            mousePosIndiGo.GetComponent<Transform>().position = newPos;
            yield return null;
        }
    }

}
