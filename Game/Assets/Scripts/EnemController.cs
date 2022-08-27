using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemController : MonoBehaviour
{
    public bool flag_to_move = true;
    public int hp = 3;
    public Slider hb;
    public GameObject go;
    // Start is called before the first frame update

    public Vector3 defaultSpeed;
    private Vector3 currSpeed;

    void Start()
    {
        go.gameObject.SetActive(false);
        currSpeed = defaultSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (flag_to_move)
        {
            this.transform.position -= currSpeed;
        }
        else
        {
            Debug.Log(flag_to_move);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("1");

        var arrow = collision.GetComponent<Arrow>();
        var l = collision.GetComponent<lose>();
        var las = collision.GetComponent<Laser>();
        var bul = collision.GetComponent<bullet>();

        if (arrow != null)
        {
            hp -= 1;
            go.gameObject.SetActive(true);
            hb.value -= 1;
            if (hp <= 0)
            {
                Destroy(this.gameObject);
            }
            Destroy(arrow.gameObject);
        }
        if (l != null)
        {
            SceneManager.LoadScene("gg");
            GameManager.Frames = 0;
        }
        if (las != null)
        {
            hp -= 2;
            go.gameObject.SetActive(true);
            hb.value -= 1;
            if (hp <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        if (bul != null)
        {
            Destroy(this.gameObject);
            Destroy(bul.gameObject);

        }
    }
    public AudioSource source;

    private void OnTriggerStay2D(Collider2D collision)
    {
        var plane = collision.GetComponent<PlaneCont>();


        if (plane != null)
        {
            currSpeed = new Vector3(0, 0, 0);
            if (plane.IsStay)
            {
                plane.hitpoint -= 1;
                plane.slid.value = plane.hitpoint;
                plane.hh.gameObject.SetActive(true);
                if (plane.hitpoint <= 0)
                {
                    Destroy(plane.gameObject);
                    PlaceController._plc.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
            }
        }

    }

    public void NormWidht()
    {
        var size = go.GetComponent<RectTransform>().sizeDelta;

        size.y = 100;
        go.GetComponent<RectTransform>().sizeDelta = size;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currSpeed = defaultSpeed;
    }
}
