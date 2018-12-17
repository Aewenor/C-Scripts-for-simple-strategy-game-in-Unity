using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraczRuch : MonoBehaviour {

    public float hp,atak,obrona,kondycja;
	private Animator anim;
    private float speed = 60f; //normalny ruch
    //private float speed = 200f; //test

    public static GraczRuch instancja;

    void Awake()
    {
        if (instancja == null)
        {
            instancja = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(this);
    }

    void Start()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        var ruch = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += ruch * speed * Time.deltaTime;

        if ((Input.GetAxis("Horizontal") > 0 || (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") > 0) || (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") < 0)))
        {
            anim.Play("RuchPrawo");
        }
        if ((Input.GetAxis("Horizontal") < 0 | (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") > 0) || (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") < 0)))
        {
            anim.Play("RuchLewo");
        }
        if ((Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") == 0))
        {
            anim.Play("RuchGora");
        }
        if ((Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") == 0))
        {
            anim.Play("RuchDol");
        }

        if ((Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0))
        {
            anim.Play("Idle");
        }
        
    }

}
