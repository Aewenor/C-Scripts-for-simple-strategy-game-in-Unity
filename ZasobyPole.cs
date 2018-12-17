using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZasobyPole : MonoBehaviour {

    private bool boolAktyw=false;
	public int ident;
	public Sprite kopalnia, tartak, uprawa;
	
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.name == "Gracz") boolAktyw = false;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name == "Gracz") {boolAktyw = true;
			GeneratorZmienne.LastId = this.ident;}
    }

    void Update () { 

		if (this.ident == GeneratorZmienne.LastId && GeneratorZmienne.Zmiana == 1) {
			
			GeneratorZmienne.Zmiana = 0;
			if (this.name == "Zasób(Clone)") {
				this.name="Tartak";
				this.gameObject.GetComponent<SpriteRenderer>().sprite = tartak;
				GameObject.Find("Gen").GetComponent<Main>().tartaki.Add(this.gameObject);
				}
            if (this.name == "Zelazo-Zloto(Clone)") {
				this.name="Kopalnia";
				this.gameObject.GetComponent<SpriteRenderer>().sprite = kopalnia;
				GameObject.Find("Gen").GetComponent<Main>().kopalnie.Add(this.gameObject);				
			}
			if (this.name == "Ziemia(Clone)") {
				this.name="Uprawa";
				this.gameObject.GetComponent<SpriteRenderer>().sprite = uprawa;	
				GameObject.Find("Gen").GetComponent<Main>().pola.Add(this.gameObject);				
			}
		}
		
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
