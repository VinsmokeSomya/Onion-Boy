using UnityEngine;
using UnityEngine.EventSystems;

public class UI_ReloadButton : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        UI.instance.AttemptToReload();
        gameObject.SetActive(false);
    }
}
