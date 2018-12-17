using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpcjeSkrypt : MonoBehaviour {

    public Button btn;
    public InputField zasoby;
    public InputField pola;
    public InputField przeciwnicy;

    void Start () {
        zasoby.text = GeneratorZmienne.Zasoby.ToString();
        pola.text = GeneratorZmienne.Pola.ToString();
        przeciwnicy.text = GeneratorZmienne.Przeciwnicy.ToString();
        btn.GetComponent<Button>().onClick.AddListener(delegate { Accept(); });
    }

    private void Accept()
    {
        GeneratorZmienne.Zasoby = Convert.ToInt32(zasoby.text);
        GeneratorZmienne.Pola = Convert.ToInt32(pola.text);
        GeneratorZmienne.Przeciwnicy = Convert.ToInt32(przeciwnicy.text);
        SceneManager.UnloadSceneAsync("Opcje");
    }

}
