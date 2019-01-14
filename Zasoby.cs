using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zasoby : MonoBehaviour {

    public static Zasoby instancja;

    void Awake()
    {
        if (instancja == null)
        {
            instancja = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(this);
    }

    public Sprite kopalnia, tartak, uprawa;
    public float drewno;
    public float zelazo;
    public float zloto;
    public float zywnosc;
    public float ludzie;
    public double cel;
    public int drewnoprzyr;
    public int zelazoprzyr;
    public int zlotoprzyr;
    public int zywnoscprzyr;
    public Text drewnoUI;
    public Text zelazoUI;
    public Text zlotoUI;
    public Text zywnoscUI;
    public Text ludzieUI;
    public Text celUI;

    public void UpdateZasoby()
    {
        drewnoUI.text = "Drewno: " + System.Math.Floor(drewno) + " + " + drewnoprzyr;
        zywnoscUI.text = "Żywność: " + System.Math.Floor(zywnosc) + " + " + zywnoscprzyr;
        zelazoUI.text = "Żelazo: " + System.Math.Floor(zelazo) + " + " + zelazoprzyr;
        zlotoUI.text = "Złoto: " + System.Math.Floor(zloto) + " + " + zlotoprzyr;
        ludzieUI.text = "Mieszkańcy: " + System.Math.Floor(ludzie) + " / " + GeneratorZmienne.LudzieMax;
        celUI.text = "Do bazy: " + cel;
    }
}
