using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScript : MonoBehaviour {

    public Button btn;
    public Button btn2;

    void Start () {

		GeneratorZmienne.Pola = 500;
		GeneratorZmienne.Zasoby = 100;
		GeneratorZmienne.Przeciwnicy = 50;
		GeneratorZmienne.Czas = 36;
		GeneratorZmienne.Zmiana = 0;
		GeneratorZmienne.LastId = -1;
		GeneratorZmienne.Kondycja = 100;
		GeneratorZmienne.PZ = 100;
        GeneratorZmienne.LudzieMax = 10;
		GeneratorZmienne.Zwyciestwo=0;
        btn.GetComponent<Button>().onClick.AddListener(delegate { NowaGra(); });
		btn2.GetComponent<Button>().onClick.AddListener(delegate { Opcje(); });
	}
	
    private void NowaGra()
    {
        SceneManager.LoadScene("Generator");
    }

    private void Opcje()
    {
        SceneManager.LoadScene("Opcje", LoadSceneMode.Additive);
    }
}
