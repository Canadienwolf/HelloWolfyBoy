using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Texture2D cur_Default;
    public Texture2D cur_Alt;
    public Texture2D cur_Pointer;
    public Texture2D cur_Rotate;

    private CursorMode curMode = CursorMode.ForceSoftware;
    private Vector2 hotSpot = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor (cur_Default, hotSpot, curMode);
    }

    public void CurPointer()
    {
        Cursor.SetCursor(cur_Pointer, hotSpot, curMode);
    }

    public void CurRotate()
    {
        Cursor.SetCursor(cur_Rotate, hotSpot, curMode);
    }

    public void CurDefault()
    {
        Cursor.SetCursor(cur_Default, hotSpot, curMode);
    }
    public void CurAlt()
    {
        Cursor.SetCursor(cur_Alt, hotSpot, curMode);
    }
}
