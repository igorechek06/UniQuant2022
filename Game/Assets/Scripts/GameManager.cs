using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] private PlaceController _nodePrefab;
    [SerializeField] private PlaneCont _planePrefab;
    [SerializeField] private int _width = 4;
    [SerializeField] private int _heigth = 4;
    [SerializeField] private enem_spavn e_s;
    [SerializeField] private EnemController enemy1;
    [SerializeField] private EnemController enemy2;
    [SerializeField] private EnemController enemy3;
    private List<EnemController> enemies = new List<EnemController>();

    [SerializeField] private Transform _canvasTransform;
    static  public Transform canvasTransform;
    [SerializeField] private Transform _f_for_arr;
    static public Transform f_for_arr;
    [SerializeField] private Transform fieldTransform;
    [SerializeField] private PlaneSpavner[] planeSpavners;
    public AudioSource source;
    private List<PlaceController> _nodes = new List<PlaceController>();
    private List<enem_spavn> enem_spawn_list = new List<enem_spavn>();
    public GameObject ee;
    [SerializeField] private TextMeshProUGUI coins;
    private bool is_boss_spawned = false;

    
    static public int CurrCoins;
    static public int Frames = 0;

    // Start is called before the first frame update
    void Start()
    {

        enemies.Add(enemy1);
        enemies.Add(enemy2);
        enemies.Add(enemy3);
        canvasTransform = _canvasTransform;
        f_for_arr = _f_for_arr;
        coins.text = "0";
        CurrCoins = Mode.money;

        GenerateGrid();
        GenetateEnem_sp();

        foreach (var spawner in planeSpavners)
        {
            spawner.SpawnPlane();
        }

    }

    private void FixedUpdate()
    {
        Frames += 1;
        CurrCoins += Frames % 100 == 0 ? 1 : 0;
        coins.text = CurrCoins.ToString();
        Debug.Log((Mode.frfr - Frames / 10));
        if (Mode.frfr - Frames / 10 >= -500)
        {
            if ((Mode.frfr - Frames / 10) > 5)
            {
                if (Frames % (Mode.frfr - Frames / 10) == 0)
                {
                    var e = Instantiate(enemies[Random.Range(0, 3)], enem_spawn_list[Random.Range(0, 6)].transform.position, Quaternion.identity);
                    e.transform.SetParent(canvasTransform);
                    e.transform.localScale = new Vector3(1, 1, 1);
                }
            }
            else
            {
                if (Frames % 5 == 0)
                {
                    var e = Instantiate(enemies[Random.Range(0, 3)], enem_spawn_list[Random.Range(0, 6)].transform.position, Quaternion.identity);
                    e.transform.SetParent(canvasTransform);
                    e.transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }
        else
        {
            if (!is_boss_spawned)
            {
                var e = Instantiate(enemies[Random.Range(0, 3)], enem_spawn_list[Random.Range(1, 5)].transform.position, Quaternion.identity);
                e.transform.SetParent(canvasTransform);
                e.transform.localScale = new Vector3(3, 3, 3);
                e.hp *= 10;
                e.hb.maxValue = e.hp *= 10;
                e.hb.value = e.hp;
                is_boss_spawned = true;
                ee = e.gameObject;

            }
            else
            {
                if(ee == null)
                {
                    SceneManager.LoadScene("Victory");
                    Frames = 0;
                }
            }

        }
    }

    void GenerateGrid()
    {

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _heigth; y++)
            {
                var node = Instantiate(_nodePrefab, new Vector2(1.005f * x - 5, 1.005f * y - 3.2f), Quaternion.identity);
                node.transform.SetParent(fieldTransform);
                node.transform.localScale = new Vector3(1, 1, 1);
                _nodes.Add(node);

              
                
            }
        }
    }
    void GenetateEnem_sp()
    {
        for (int i = 0; i < _heigth; i++)
        {
            var en_sp = Instantiate(e_s, new Vector2(9.4f, 1.005f * i - 3.2f), Quaternion.identity);
            en_sp.transform.SetParent(canvasTransform);
            en_sp.transform.localScale = new Vector3(1, 1, 1);
            enem_spawn_list.Add(en_sp);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }


}
