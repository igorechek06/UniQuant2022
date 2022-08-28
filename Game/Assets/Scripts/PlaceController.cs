using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlaceController : MonoBehaviour , IDropHandler , IPointerEnterHandler , IPointerExitHandler
{
    public Transform StayPoint;
    public PlaceController plc;

    public Color defaultColor;
    public Color pointedColor;

    void Start()
    {
        GetComponent<Image>().color = defaultColor;
    }

    public void OnDrop(PointerEventData eventData)
    {

        
        var plane = eventData.pointerDrag.GetComponent<PlaneCont>();

        if (plane == null)
            return;

        plane.SetNewSpawnPoint(StayPoint);
        plane.fff = this.gameObject;
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;

        PlanePlaced?.Invoke(this, null);

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().color = pointedColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = defaultColor;
    }

    public System.EventHandler PlanePlaced;

}
