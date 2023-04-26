using System;
using UnityEngine.UI;

using UnityEngine;
using UnityEngine.EventSystems;


public class UIPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Vector2 pos;
    public Snake Snake;

    public void OnPointerDown(PointerEventData eventData)
    {
        float right = pos.x - eventData.position.x; // right
        float up = pos.y - eventData.position.y; // up

        if (Math.Abs(right) - Math.Abs(up) > 0)
        {

            if (right < 0)
            {
                Snake.Right();
            }
            else
            {
                Snake.Left();
            }
        }
        else
        {

            if (up < 0)
            {
                Snake.Up();
            }
            else
            {
                Snake.Down();
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pos = eventData.position;
    }
}
