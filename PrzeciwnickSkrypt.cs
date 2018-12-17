using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PrzeciwnickSkrypt : MonoBehaviour
{
    private Animator anim;
    public float hp,atak,obrona,liczba, mult;
	public string nazwa, opis;
	public int identp;
    private bool boolAktyw = false;
	private GameObject tmp;

    void Start()
    {
        anim = GetComponent<Animator>();
		anim.Play("Idle");
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.name == "Gracz") boolAktyw = false;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name == "Gracz") {boolAktyw = true;
		GeneratorZmienne.LastId = this.identp;}
    }

    void Update()
    {
		if (this.identp == GeneratorZmienne.LastId && GeneratorZmienne.Zmiana == 1) {
			
			GeneratorZmienne.Zmiana = 0;
			if (this.name == "Przeciwnik(Clone)") {
				anim.Play("Dead");
				boolAktyw = false;
				GeneratorZmienne.LastId = -1;
				tmp = GameObject.Find("Gen");
				foreach(GameObject obj in tmp.GetComponent<Main>().stworzonePolaObiekt){
					if(this.transform.position == obj.transform.position) obj.GetComponent<PustePole>().puste = true;
				}
				Destroy(this.gameObject,4.0f);
				}		
		}
		
        if(boolAktyw && Input.GetKeyDown(KeyCode.F))
        {
			GeneratorZmienne.WalkaZmienne[0] = this.hp;
			GeneratorZmienne.WalkaZmienne[1] = this.atak;
			GeneratorZmienne.WalkaZmienne[2] = this.obrona;
			GeneratorZmienne.WalkaZmienne[3] = this.liczba;
            GeneratorZmienne.WalkaZmienne[4] = this.mult;
            GeneratorZmienne.Nazwa = this.nazwa;
			GeneratorZmienne.Opis = this.opis;
            GeneratorZmienne.Scena = 1;
            SceneManager.LoadSceneAsync("Walka", LoadSceneMode.Additive);
        }
    }

}
