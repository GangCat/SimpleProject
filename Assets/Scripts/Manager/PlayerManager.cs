using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mousePosIndiGo = null;

    [SerializeField]
    private CameraManager cam;

    public void Init()
    {
        
    }

    void Update()
    {
        var newPos = cam.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("mousePos " + Input.mousePosition);
        Debug.Log("worldPos " + newPos);
        newPos.z -= cam.getZPos();
        mousePosIndiGo.GetComponent<Transform>().position = newPos;
    }
}
