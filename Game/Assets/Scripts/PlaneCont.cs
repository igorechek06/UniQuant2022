using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class PlaneCont : MonoBehaviour, IDragHandler , IBeginDragHandler , IEndDragHandler
{
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] public Arrow arr;
    [SerializeField] public Slider slid;
    [SerializeField] public Transform hh;
    static public Transform hhh;
    [SerializeField] public Laser las;
    [SerializeField] public bullet bul;
    [SerializeField] public int hitpoint;
    public int cost;
    public bool IsStay = false;
    private bool IsMoving = false;

    private IPlaneFunc func;

    [SerializeField] PlaneType type;





    public void SetNewSpawnPoint(Transform newSpawnPoint)
    {
        SpawnPoint = newSpawnPoint;
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
        IsStay = true;
    }
    void Start()
    {
        hh.gameObject.SetActive(false);
        hhh = hh;
    }

    public void Init(Transform SpawnPoint )
    {
        this.SpawnPoint = SpawnPoint;


        switch (type)
        {
            case PlaneType.CoinSpawer:
                func = new CoinSpawnerFunc();
                break;
            case PlaneType.AttackerOne:
                AttackeOneFunc f = new AttackeOneFunc();
                func = f;
                f.arrow = arr;
                f.point_ = this.transform;
                f.c = GameManager.f_for_arr;
                break;
            case PlaneType.LaserGun:
                LaserGunFunc g = new LaserGunFunc();
                func = new LaserGunFunc();
                func = g;
                g.laser = las;
                g.point_ = this.transform;
                g.c = GameManager.f_for_arr;
                break;
            case PlaneType.Sniper:
                SniperFunc h = new SniperFunc();
                func = h;
                h.bullet = bul;
                h.point_ = this.transform;
                h.c = GameManager.f_for_arr;

                break;
            default:
                break;
        }

    }

    void FixedUpdate()
    {
        if (!IsMoving)
            this.GetComponent<CanvasGroup>().blocksRaycasts = cost <= GameManager.CurrCoins;

        if (IsStay)
            func.Func();
        slid.value = hitpoint;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
        IsMoving = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(eventData.position);
        newPos.z = transform.position.z;

        transform.position = newPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!IsStay)
            this.GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (IsStay)
        {
            PlanePlaced.Invoke(this, null);
            GameManager.CurrCoins -= cost;
        }
        transform.position = SpawnPoint.position;
    }

    public System.EventHandler PlanePlaced;


}

public enum PlaneType
{
    CoinSpawer,
    AttackerOne,
    LaserGun,
    Sniper
}