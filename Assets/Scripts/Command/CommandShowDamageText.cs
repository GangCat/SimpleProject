using UnityEngine;

public class CommandShowDamageText : ICommand
{
    private ICanvasDamageText canvas = null;
    public CommandShowDamageText(ICanvasDamageText _canvas)
    {
        canvas = _canvas;
    }

    public void Execute(params object[] _values)
    {
        canvas.ShowDamageText((Vector2)_values[0]);
    }
}
