using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Main : MonoBehaviour {

	public GameObject pole;
	public GameObject sciana;
	public GameObject gracz;
	public GameObject drewno;
    public GameObject zelzl;
	public GameObject ziemia;
    public GameObject[] przeciwnicy;
    public GameObject budynek;
	public Button menu;
    public Text czas;
    public Text QuestTXT;
    public List<Vector3> stworzonePola;
	public List<GameObject> stworzonePolaObiekt;
    public List<GameObject> kopalnie;
	public List<GameObject> tartaki;
	public List<GameObject> pola;
    private int liczPrzec = GeneratorZmienne.Przeciwnicy;
    private int liczZas = GeneratorZmienne.Zasoby;
    private int liczbaPol = GeneratorZmienne.Pola;
	private int odstep = 96;
    private GameObject przeciwnik;
    private GameObject target;
    private float szGora = 0.25f;
	private float szLewo = 0.5f;
	private float szPrawo = 0.75f;
    private float minY = 999999999;
	private float maxY = 0;
	private float minX = 999999999;
	private float maxX = 0;
	private float liczX;
	private float liczY;
	private float scianaX = 16;
	private float scianaY = 16;

    void Start () {
		menu.GetComponent<Button>().onClick.AddListener(delegate { Menu(); });
        StworzPoziom();
		GeneratorZmienne.Event = 0;
        GeneratorZmienne.Quest = 0;
        SceneManager.LoadSceneAsync("Questy", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("Eventy", LoadSceneMode.Additive);
        InvokeRepeating("Eventy", 5.0f, 30.0f);
		InvokeRepeating("Czas", 0.0f, 5.0f);
		InvokeRepeating("Zas", 0.0f, 2.0f);
        InvokeRepeating("LudzieP", 60.0f, 60.0f);
    }
	
	private void Menu(){
		GeneratorZmienne.Scena = 999;
		SceneManager.LoadSceneAsync("Walka", LoadSceneMode.Additive);
	}
	
	private void Eventy(){

		if(Random.Range(0, 100) <= 10){			
			GeneratorZmienne.Event = Random.Range(1, 3);			
			SceneManager.LoadSceneAsync("Eventy", LoadSceneMode.Additive);
		}
	}
	
	private void Czas(){

		GeneratorZmienne.Czas ++;
        czas.text = "Dzień " + System.Math.Floor(GeneratorZmienne.Czas / 24) + ", " + System.Math.Floor(GeneratorZmienne.Czas % 24) + ".00";
	}
	
	private void Zas(){

        Zasoby.instancja.drewno += Zasoby.instancja.drewnoprzyr;
        Zasoby.instancja.zelazo += Zasoby.instancja.zelazoprzyr;
        Zasoby.instancja.zywnosc += Zasoby.instancja.zywnoscprzyr;
        Zasoby.instancja.zloto += Zasoby.instancja.zlotoprzyr;
	}

    private void LudzieP()
    {
        if(Zasoby.instancja.ludzie < GeneratorZmienne.LudzieMax) Zasoby.instancja.ludzie++;
    }

    private void StworzPoziom(){

		for(int i=0;i<liczbaPol;i++){
			float x = Random.Range(0f,1f);
			stworzPole();
			Szanse(x);
			if(i == liczbaPol -1) Zakoncz();
		}
		
	}

    private void Szanse(float dir){
		if(dir < szGora) Ruch(0);
		else if(dir < szLewo) Ruch(3);
		else if(dir <szPrawo) Ruch(2);
		else Ruch(1);
	}

    private void Ruch(int x){
		switch(x){
			case 0:
			transform.position = new Vector3(transform.position.x, transform.position.y + odstep,0);
			break;
			case 1:
			transform.position = new Vector3(transform.position.x, transform.position.y - odstep,0);
			break;
			case 2:
			transform.position = new Vector3(transform.position.x + odstep, transform.position.y,0);
			break;
			case 3:
			transform.position = new Vector3(transform.position.x - odstep, transform.position.y,0);
			break;
		}
	}
	
	private void stworzPole(){
		GameObject tmp;
		if(!stworzonePola.Contains(transform.position)){
		tmp = Instantiate(pole,transform.position,transform.rotation) as GameObject;
		tmp.GetComponent<PustePole>().puste = true;
		stworzonePola.Add(tmp.transform.position);
		stworzonePolaObiekt.Add(tmp);
		}else liczbaPol++;
	}
	
	void Zakoncz(){
		ScianaWar();
		StworzSciane();
		StworzObiekty();
	}
	
	private void StworzObiekty(){
        int tmp;
		gracz.GetComponent<GraczRuch>().hp=100;
		gracz.GetComponent<GraczRuch>().atak=10;
		gracz.GetComponent<GraczRuch>().obrona=10;
		gracz.GetComponent<GraczRuch>().kondycja=100;
        tmp =Random.Range(0, stworzonePolaObiekt.Count);
        Destroy(Instantiate(gracz, stworzonePolaObiekt[tmp].transform.position, Quaternion.identity));
        target = Instantiate(budynek, gracz.transform.position, Quaternion.identity);
		foreach(GameObject obj in stworzonePolaObiekt){
			if(obj.transform.position == Vector3.zero) obj.GetComponent<PustePole>().puste = false;
		}      
        
        for (int i=0;i<liczPrzec;i++){
            tmp = Random.Range(0, przeciwnicy.Length);
            przeciwnik = przeciwnicy[tmp];
            przeciwnik.name = "Przeciwnik";
            if (tmp == 0) {
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().nazwa = "Wilki";
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().atak = 2;
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().obrona = 1;
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().hp = 10;
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().mult = 1;
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().liczba = Random.Range(3, 10);
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().opis = "Wataha wilków krąży wokół zniszczonej karawany. Nie zwęszyły jeszcze naszego bohatera więc jest jeszcze czas na ucieczkę.";
            }

            if (tmp == 1)
            {
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().nazwa = "Minotaury";
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().atak = 15;
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().obrona = 6;
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().hp = 120;
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().mult = 3;
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().liczba = Random.Range(1, 4);
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().opis = "Nasz bohater znalazł jaskinię minotaurów. Walka będzie ciężka...";
            }

            if (tmp == 2)
            {
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().nazwa = "Patrol Moreth";
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().atak = 20;
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().obrona = 15;
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().hp = 200;
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().mult = 5;
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().liczba = Random.Range(1, 7);
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().opis = "Nasz bohater natknął się na patrol z Moreth. Nasz bohater musi mieć duże siły aby ich pokonać...";
            }

            if (tmp == 3)
            {
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().nazwa = "Patrol Irderal";
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().atak = 15;
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().obrona = 20;
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().hp = 200;
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().mult = 5;
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().liczba = Random.Range(1, 7);
                przeciwnik.GetComponent<PrzeciwnickSkrypt>().opis = "Nasz bohater natknął się na patrol z Irderal. Nasz bohater musi mieć duże siły aby ich pokonać...";
            }

            tmp = Random.Range(0, stworzonePolaObiekt.Count);
			if(stworzonePolaObiekt[tmp].GetComponent<PustePole>().puste){
				przeciwnik.GetComponent<PrzeciwnickSkrypt>().identp=i;
                Instantiate(przeciwnik, stworzonePolaObiekt[tmp].transform.position, Quaternion.identity);
				stworzonePolaObiekt[tmp].GetComponent<PustePole>().puste = false;
				}else i--;				
	    }
		
		liczPrzec = GeneratorZmienne.Przeciwnicy;
		
		for(int i=0;i< System.Math.Floor(0.5*liczZas);i++){
            tmp = Random.Range(0, stworzonePola.Count);
			if(stworzonePolaObiekt[tmp].GetComponent<PustePole>().puste){
				Instantiate(ziemia, stworzonePolaObiekt[tmp].transform.position, Quaternion.identity);
				stworzonePolaObiekt[tmp].GetComponent<PustePole>().puste = false;			
				}else i--;
        }
		
		liczZas = GeneratorZmienne.Zasoby;
		
	    for(int i=System.Convert.ToInt32(System.Math.Floor(0.5*liczZas));i< System.Math.Floor(0.8*liczZas);i++){
            tmp = Random.Range(0, stworzonePola.Count);
			if(stworzonePolaObiekt[tmp].GetComponent<PustePole>().puste){
				Instantiate(drewno, stworzonePolaObiekt[tmp].transform.position, Quaternion.identity);
				stworzonePolaObiekt[tmp].GetComponent<PustePole>().puste = false;			
				}else i--;
        }
		
		liczZas = GeneratorZmienne.Zasoby;
		
        for (int i = System.Convert.ToInt32(System.Math.Floor(0.8*liczZas)); i < liczZas; i++)
        {
            tmp = Random.Range(0, stworzonePola.Count);
			if(stworzonePolaObiekt[tmp].GetComponent<PustePole>().puste){
				Instantiate(zelzl, stworzonePolaObiekt[tmp].transform.position, Quaternion.identity);
				stworzonePolaObiekt[tmp].GetComponent<PustePole>().puste = false;				
				}else i--;
        }
    }	

	private void ScianaWar(){
		for(int i=0;i<stworzonePola.Count;i++){
			if(stworzonePola[i].y < minY) minY = stworzonePola[i].y;
			if(stworzonePola[i].y > maxY) maxY = stworzonePola[i].y;
			if(stworzonePola[i].x < minX) minX = stworzonePola[i].x;
			if(stworzonePola[i].x > maxX) maxX = stworzonePola[i].x;
			
			liczX = ((maxX - minX) / odstep) + scianaX;
			liczY = ((maxY - minY) / odstep) + scianaY;
		}
	}

	private void StworzSciane(){
		for(int x=0;x<liczX;x++)
		{
			for(int y=0;y<liczY;y++)
			{
				if (!stworzonePola.Contains(new Vector3((minX - (scianaX * odstep)/2) + (x*odstep),(minY - (scianaY * odstep)/2) + (y*odstep))))
				{
					Instantiate(sciana,new Vector3((minX - (scianaX * odstep)/2) + (x*odstep),(minY - (scianaY * odstep)/2) + (y*odstep)),transform.rotation);
				}
			}
		}
	}

    void FixedUpdate()
    {
        Zasoby.instancja.cel = System.Math.Floor(Vector3.Distance(gracz.transform.position, target.transform.position) / 50);
        Zasoby.instancja.UpdateZasoby();
            
        if (tartaki.Any() && kopalnie.Any() && pola.Any() && GeneratorZmienne.Quest == 0)
        {
            GeneratorZmienne.Quest = 1;
            SceneManager.LoadSceneAsync("Questy", LoadSceneMode.Additive);
        }
        if (GeneratorZmienne.Robotnik.Liczba > 0 && GeneratorZmienne.Quest == 1)
        {
            GeneratorZmienne.Quest = 2;
            SceneManager.LoadSceneAsync("Questy", LoadSceneMode.Additive);
        }
        if (GeneratorZmienne.Glowny > 0 && GeneratorZmienne.Quest == 2)
        {
            GeneratorZmienne.Quest = 3;
            SceneManager.LoadSceneAsync("Questy", LoadSceneMode.Additive);
        }
        if (tartaki.Count() >= 4 && kopalnie.Count() >= 4 && pola.Count() >= 4 && GeneratorZmienne.Quest == 3)
        {
            GeneratorZmienne.Quest = 4;
            SceneManager.LoadSceneAsync("Questy", LoadSceneMode.Additive);
        }
        if (GeneratorZmienne.Zolnierz.Liczba >= 3 && GeneratorZmienne.Quest == 4)
        {
            GeneratorZmienne.Quest = 5;
            SceneManager.LoadSceneAsync("Questy", LoadSceneMode.Additive);
        }
        if (GeneratorZmienne.Rycerz.Liczba >= 5 && Zasoby.instancja.zywnosc >= 10000 && GeneratorZmienne.Quest == 6)
        {
            GeneratorZmienne.WalkaZmienne[0] = 100;
            GeneratorZmienne.WalkaZmienne[1] = 20;
            GeneratorZmienne.WalkaZmienne[2] = 15;
            GeneratorZmienne.WalkaZmienne[3] = 100;
            GeneratorZmienne.WalkaZmienne[4] = 1;
            GeneratorZmienne.Nazwa = "Armia";
            GeneratorZmienne.Opis = "Nadszedł czas na obronę tego, co nasz bohater zbudował. Nasz bohater powrócił do swego gospodarstwa tuż przed armią najeźdźców. Szykuj się do obrony!";
            GeneratorZmienne.Quest = 7;
            GeneratorZmienne.Scena = 1;
            SceneManager.LoadSceneAsync("Walka", LoadSceneMode.Additive);
        }
        if (GeneratorZmienne.Zwyciestwo == 1) {
			GeneratorZmienne.Event = -1;
			SceneManager.LoadSceneAsync("Eventy");
		}
    }
}
