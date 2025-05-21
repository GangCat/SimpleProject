using UnityEngine;

public class CanvasManager : MonoBehaviour
{

    [SerializeField]
    private CanvasDamageText canvasDamageText = null;

    public void Init()
    {
        canvasDamageText.Init();
    }

    public CanvasDamageText GetCanvasDamageText => canvasDamageText;
}
