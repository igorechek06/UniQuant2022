using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaneSpavner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private PlaneCont _plane;
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        
         text.text = _plane.cost.ToString();
    }

    public void SpawnPlane()
    {
        var plane = Instantiate(_plane, spawnPoint.position, Quaternion.identity);
        plane.Init(spawnPoint);
        plane.transform.SetParent(spawnPoint);

        plane.transform.localScale = new Vector3(1, 1, 1);

        plane.PlanePlaced = (sender, args) => { SpawnPlane(); };

    }
}
