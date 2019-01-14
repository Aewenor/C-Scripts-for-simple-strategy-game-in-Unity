using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZasobyPole : MonoBehaviour {

    private bool boolAktyw=false;
	
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.name == "Gracz") boolAktyw = false;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name == "Gracz") {boolAktyw = true;
            GeneratorZmienne.trigger = this.gameObject;
        }
    }

    void Update () { 
		
        if (boolAktyw && Input.GetKeyDown(KeyCode.F)) {
            if (this.name == "Zasób(Clone)") GeneratorZmienne.Scena = 2;
            if (this.name == "Zelazo-Zloto(Clone)") GeneratorZmienne.Scena = 3;
            if (this.name == "Budynek_Glowny(Clone)") GeneratorZmienne.Scena = 4;
			if (this.name == "Ziemia(Clone)") GeneratorZmienne.Scena = 5;
			if (this.name == "Tartak") GeneratorZmienne.Scena = 22;
			if (this.name == "Kopalnia") GeneratorZmienne.Scena = 33;
			if (this.name == "Uprawa") GeneratorZmienne.Scena = 55;
            SceneManager.LoadSceneAsync("Walka", LoadSceneMode.Additive);
        }

	}
}
