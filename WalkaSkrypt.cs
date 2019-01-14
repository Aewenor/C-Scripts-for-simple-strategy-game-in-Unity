using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WalkaSkrypt : MonoBehaviour {

    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;
    public Text txt;
    private GameObject gracz;
    private int tmp;
    private string temp;
    private float maxHP;
    private float attack;

    private void Clear() {
        btn1.interactable = true;
        btn2.interactable = true;
        btn3.interactable = true;
        btn4.interactable = true;
        btn1.gameObject.SetActive(false);
        btn2.gameObject.SetActive(false);
        btn3.gameObject.SetActive(false);
        btn4.gameObject.SetActive(false);
        btn1.GetComponent<Button>().onClick.RemoveAllListeners();
        btn2.GetComponent<Button>().onClick.RemoveAllListeners();
        btn3.GetComponent<Button>().onClick.RemoveAllListeners();
        btn4.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    void Start() {
        Time.timeScale = 0;
        Clear();
		if(GeneratorZmienne.Quest != 7){
        btn4.gameObject.SetActive(true);
        btn4.GetComponent<Button>().onClick.AddListener(delegate { Back(); });
        btn4.GetComponentInChildren<Text>().text = "Odejdź";
		}

        if (GeneratorZmienne.Scena == 1)
        {
            maxHP = GeneratorZmienne.WalkaZmienne[0] * GeneratorZmienne.WalkaZmienne[3];
            btn1.gameObject.SetActive(true);
            btn1.GetComponentInChildren<Text>().text = "Atakuj";
            btn1.GetComponent<Button>().onClick.AddListener(delegate { Fight(); });
            if (GeneratorZmienne.Kondycja < 50 || GeneratorZmienne.PZ == 0) btn1.interactable = false;
            if(GeneratorZmienne.Quest != 7)btn4.GetComponentInChildren<Text>().text = "Uciekaj";
            txt.text = GeneratorZmienne.Opis;
        }
        if (GeneratorZmienne.Scena == 2)
        {
            btn1.gameObject.SetActive(true);
            btn1.GetComponentInChildren<Text>().text = "Praca";
            btn1.GetComponent<Button>().onClick.AddListener(delegate { Drewno(); });
            if (GeneratorZmienne.Kondycja < 30 || GeneratorZmienne.PZ == 0) btn1.interactable = false;
            btn2.gameObject.SetActive(true);
            btn2.GetComponentInChildren<Text>().text = "Tartak";
            if (GeneratorZmienne.Kondycja < 60 || Zasoby.instancja.drewno < 100 || Zasoby.instancja.zywnosc < 200) btn2.interactable = false;
            btn2.GetComponent<Button>().onClick.AddListener(delegate { DrewnoAuto(); });
            txt.text = "Przed naszym bohaterem znajduje się mały las, w sam raz na wycinkę drewna. Nasz bohater może sam pracować lub założyć tartak (60 Kondycji, 100 Drewna oraz 200 Żywności).";
        }
        if (GeneratorZmienne.Scena == 3)
        {
            btn1.gameObject.SetActive(true);
            btn1.GetComponentInChildren<Text>().text = "Praca";
            btn1.GetComponent<Button>().onClick.AddListener(delegate { ZelZl(); });
            if (GeneratorZmienne.Kondycja < 40 || GeneratorZmienne.PZ == 0) btn1.interactable = false;
            btn2.gameObject.SetActive(true);
            btn2.GetComponentInChildren<Text>().text = "Kopalnia";
            if (GeneratorZmienne.Kondycja < 80 || Zasoby.instancja.drewno < 200 || Zasoby.instancja.zelazo < 100 || Zasoby.instancja.zywnosc < 300 || Zasoby.instancja.zloto < 50) btn2.interactable = false;
            btn2.GetComponent<Button>().onClick.AddListener(delegate { ZelZlAuto(); });
            txt.text = "Przed naszym bohaterem piętrzą się wysokie góry, w których mogą znajdować się żyły żelaza lub złota. Nasz bohater może sam wydobywać rudę lub założyć kopalnię (80 Kondycji, 200 Drewna, 100 Żelaza, 300 Żywności oraz 50 Złota).";
        }
        if (GeneratorZmienne.Scena == 5)
        {
            btn1.gameObject.SetActive(true);
            btn1.GetComponentInChildren<Text>().text = "Farma";
            btn1.GetComponent<Button>().onClick.AddListener(delegate { Farma(); });
            if (GeneratorZmienne.Kondycja < 80 || Zasoby.instancja.drewno < 200 || Zasoby.instancja.zelazo < 50 || Zasoby.instancja.zywnosc < 100) btn1.interactable = false;
            txt.text = "Nasz bohater znalazł połać żyznej ziemi nadającą się pod uprawy. Nasz bohater może tutak założyć farmę (80 Kondycji, 200 Drewna, 50 Żelaza oraz 100 Żywności).";
        }
        if (GeneratorZmienne.Scena == 4)
        {
            btn1.gameObject.SetActive(true);
            btn1.GetComponentInChildren<Text>().text = "Rozbuduj";
            if (GeneratorZmienne.Kondycja < 30 || GeneratorZmienne.PZ == 0) btn1.interactable = false;
            btn1.GetComponent<Button>().onClick.AddListener(delegate { Buduj(); });
            btn2.gameObject.SetActive(true);
            btn2.GetComponentInChildren<Text>().text = "Najmij ludzi";
            if (GeneratorZmienne.Kondycja < 10 || GeneratorZmienne.PZ == 0) btn2.interactable = false;
            btn2.GetComponent<Button>().onClick.AddListener(delegate { Najmij(); });
            btn3.gameObject.SetActive(true);
            btn3.GetComponentInChildren<Text>().text = "Odpocznij";
            btn3.GetComponent<Button>().onClick.AddListener(delegate { Odpocznij(); });
            txt.text = "Bohater przybył do swojego gospodarstwa. Jest jeszcze dużo do zrobienia...";
        }
        if (GeneratorZmienne.Scena == 22)
        {
            txt.text = "Nasz bohater został powitany w obozie drwali, którzy wycinają dla niego drewno. Nasz bohater nie ma tu nic do zrobienia.";
        }
        if (GeneratorZmienne.Scena == 33)
        {
            txt.text = "Do uszu naszego bohatera doszły uderzenia kilofów i krzyki górników pracujących pod ziemią. Nasz bohater nie ma tu nic do zrobienia.";
        }
        if (GeneratorZmienne.Scena == 55)
        {
            txt.text = "Pola uprawne rozciągają się po horyzont. Naszego bohatera pozdrawiają jego rolnicy. Nasz bohater nie ma tu nic do zrobienia.";
        }
        if (GeneratorZmienne.Scena == 999)
        {
            btn1.gameObject.SetActive(true);
            btn1.GetComponentInChildren<Text>().text = "Statystyki drużyny";
            btn1.GetComponent<Button>().onClick.AddListener(delegate { Party(); });
            btn3.gameObject.SetActive(true);
            btn3.GetComponentInChildren<Text>().text = "Wyjdź z gry";
            btn3.GetComponent<Button>().onClick.AddListener(delegate { Application.Quit(); });
            btn4.GetComponentInChildren<Text>().text = "Wróć";
            txt.text = "Menu Główne";
        }
    }

    private void Buduj() {
        Clear();
        temp = "Co nasz bohater powinien rozbudować?<br><br>";
        btn1.gameObject.SetActive(true);
        if (GeneratorZmienne.Glowny == 0) {
            btn1.GetComponentInChildren<Text>().text = "Wioska";
            if (Zasoby.instancja.zywnosc < 2000 || Zasoby.instancja.zloto < 500 || Zasoby.instancja.drewno < 1500) btn1.interactable = false;
            temp += "Wioska<br>Koszt: 2000 żywności, 1500 drewna i 500 złota.<br>Zwiększa limit mieszkańców.<br><br>";
            btn1.GetComponent<Button>().onClick.AddListener(delegate { BudBud(2); });
        }
        if (GeneratorZmienne.Glowny == 1) {
            btn1.GetComponentInChildren<Text>().text = "Miasteczko";
            if (Zasoby.instancja.zywnosc < 5000 || Zasoby.instancja.zloto < 750 || Zasoby.instancja.drewno < 2000 || Zasoby.instancja.zelazo < 500) btn1.interactable = false;
            temp += "Miasteczko<br>Koszt: 5000 żywności, 2000 drewna, 500 żelaza i 750 złota.<br>Zwiększa limit mieszkańców i pozwala na budowę koszar.<br><br>";
            btn1.GetComponent<Button>().onClick.AddListener(delegate { BudBud(2); });
        }
        if (GeneratorZmienne.Glowny == 2) {
            btn1.GetComponentInChildren<Text>().text = "Gród";
            if (Zasoby.instancja.zywnosc < 10000 || Zasoby.instancja.zloto < 2000 || Zasoby.instancja.drewno < 5000 || Zasoby.instancja.zelazo < 1000) btn1.interactable = false;
            temp += "Gród<br>Koszt: 10000 żywności, 5000 drewna, 1000 żelaza i 2000 złota.<br>Zwiększa limit mieszkańców i pozwala na budowę koszar i budynków specjalnych.<br><br>";
            btn1.GetComponent<Button>().onClick.AddListener(delegate { BudBud(2); });
        }
        if (GeneratorZmienne.Glowny == 3) {
            btn1.GetComponentInChildren<Text>().text = "Najwyższy poziom";
            btn1.interactable = false;
        }
        btn2.gameObject.SetActive(true);
        if (GeneratorZmienne.Baraki == 0) {
            btn2.GetComponentInChildren<Text>().text = "Baraki";
            if (Zasoby.instancja.zywnosc < 300 || Zasoby.instancja.zloto < 100 || Zasoby.instancja.drewno < 300) btn2.interactable = false;
            temp += "Baraki<br>Koszt: 300 żywności, 200 drewna i 100 złota.<br>Pozwala na rekrutację robotników.<br><br>";
            btn2.GetComponent<Button>().onClick.AddListener(delegate { BudBud(1); });
        }
        if (GeneratorZmienne.Baraki == 1) {
            btn2.GetComponentInChildren<Text>().text = "Koszary";
            if (Zasoby.instancja.zywnosc < 500 || Zasoby.instancja.zloto < 250 || Zasoby.instancja.drewno < 300 || Zasoby.instancja.zelazo < 250 || GeneratorZmienne.Glowny < 2) btn2.interactable = false;
            temp += "Koszary<br>Koszt: 500 żywności, 300 drewna, 250 żelaza i 100 złota. Wymaga miasteczka.<br>Pozwala na rekrutację żołnierzy.<br><br>";
            btn2.GetComponent<Button>().onClick.AddListener(delegate { BudBud(1); });
        }
        if (GeneratorZmienne.Baraki == 2) {
            btn2.GetComponentInChildren<Text>().text = "Szkoła Rycerska";
            if (Zasoby.instancja.zywnosc < 1500 || Zasoby.instancja.zloto < 750 || Zasoby.instancja.drewno < 1000 || Zasoby.instancja.zelazo < 500 || GeneratorZmienne.Glowny < 3) btn2.interactable = false;
            temp += "Szkoła Rycerska<br>Koszt: 1500 żywności, 1000 drewna, 500 żelaza i 500 złota. Wymaga grodu.<br>Pozwala na rekrutację rycerzy i jednostek specjalnych.<br><br>";
            btn2.GetComponent<Button>().onClick.AddListener(delegate { BudBud(1); });
        }
        if (GeneratorZmienne.Baraki == 3) {
            btn2.GetComponentInChildren<Text>().text = "Najwyższy poziom";
            btn2.interactable = false;
        }
        btn3.gameObject.SetActive(true);
        btn3.GetComponentInChildren<Text>().text = "Dalej";
        btn3.GetComponent<Button>().onClick.AddListener(delegate { Buduj2(); });
        btn4.gameObject.SetActive(true);
        btn4.GetComponent<Button>().onClick.AddListener(delegate { Start(); });
        btn4.GetComponentInChildren<Text>().text = "Wróć";
        txt.text = temp.Replace("<br>", "\n");
    }

    private void Buduj2()
    {
        Clear();
        temp = "Co nasz bohater powinien rozbudować?<br><br>";
        btn1.gameObject.SetActive(true);
        btn1.GetComponentInChildren<Text>().text = "Rynek";
        if (Zasoby.instancja.zywnosc < 1000 || Zasoby.instancja.zloto < 500 || Zasoby.instancja.drewno < 1500 || GeneratorZmienne.Glowny < 2) btn1.interactable = false;
        temp += "Rynek<br>Koszt: 1000 żywności, 1500 drewna i 500 złota. Wymaga miasteczka.<br>Zwiększa przyrost złota.<br><br>";
        btn1.GetComponent<Button>().onClick.AddListener(delegate { BudBud(3); });
        btn2.gameObject.SetActive(true);
        btn2.GetComponentInChildren<Text>().text = "Chata Myśliwego";
        if (Zasoby.instancja.zywnosc < 200 || Zasoby.instancja.drewno < 100 || GeneratorZmienne.Glowny < 1) btn2.interactable = false;
        temp += "Chata Myśliwego<br>Koszt: 200 żywności, 100 drewna. Wymaga wioski.<br>Zwiększa przyrost żywności.<br><br>";
        btn2.GetComponent<Button>().onClick.AddListener(delegate { BudBud(4); });
        btn3.gameObject.SetActive(true);
        btn3.GetComponentInChildren<Text>().text = "Dalej";
        btn3.GetComponent<Button>().onClick.AddListener(delegate { Buduj3(); });
        btn4.gameObject.SetActive(true);
        btn4.GetComponent<Button>().onClick.AddListener(delegate { Start(); });
        btn4.GetComponentInChildren<Text>().text = "Wróć";
        txt.text = temp.Replace("<br>", "\n");
    }

    private void Buduj3()
    {
        Clear();
        temp = "Co nasz bohater powinien rozbudować?<br><br>";
        btn1.gameObject.SetActive(true);
        btn1.GetComponentInChildren<Text>().text = "Kuźnia";
        if (Zasoby.instancja.zywnosc < 1200 || Zasoby.instancja.zloto < 200 || Zasoby.instancja.zelazo < 500 || Zasoby.instancja.drewno < 300 || GeneratorZmienne.Glowny < 3) btn1.interactable = false;
        temp += "Kuźnia<br>Koszt: 1200 żywności, 300 drewna, 500 żelaza i 200 złota. Wymaga grodu.<br>Zwiększa przyrost żelaza.<br><br>";
        btn1.GetComponent<Button>().onClick.AddListener(delegate { BudBud(5); });
        btn3.gameObject.SetActive(true);
        btn3.GetComponentInChildren<Text>().text = "Dalej";
        btn3.GetComponent<Button>().onClick.AddListener(delegate { Buduj(); });
        btn4.gameObject.SetActive(true);
        btn4.GetComponent<Button>().onClick.AddListener(delegate { Start(); });
        btn4.GetComponentInChildren<Text>().text = "Wróć";
        txt.text = temp.Replace("<br>", "\n");
    }

    private void BudBud(int i) {

        if (i == 1) {
            if (GeneratorZmienne.Baraki == 2) {
                Zasoby.instancja.zywnosc -= 1500;
                Zasoby.instancja.drewno -= 1000;
                Zasoby.instancja.zloto -= 750;
                Zasoby.instancja.zelazo -= 500;
                GeneratorZmienne.Baraki = 3;
            }
            if (GeneratorZmienne.Baraki == 1) {
                Zasoby.instancja.zywnosc -= 500;
                Zasoby.instancja.drewno -= 300;
                Zasoby.instancja.zloto -= 250;
                Zasoby.instancja.zelazo -= 250;
                GeneratorZmienne.Baraki = 2;
            }
            if (GeneratorZmienne.Baraki == 0) {
                Zasoby.instancja.zywnosc -= 300;
                Zasoby.instancja.drewno -= 200;
                Zasoby.instancja.zloto -= 100;
                GeneratorZmienne.Baraki = 1;
            }
        }
        if (i == 2) {
            if (GeneratorZmienne.Glowny == 2) {
                Zasoby.instancja.zywnosc -= 10000;
                Zasoby.instancja.drewno -= 5000;
                Zasoby.instancja.zloto -= 2000;
                Zasoby.instancja.zelazo -= 1000;
                GeneratorZmienne.Glowny = 3;
                GeneratorZmienne.LudzieMax = 200;
            }
            if (GeneratorZmienne.Glowny == 1) {
                Zasoby.instancja.zywnosc -= 5000;
                Zasoby.instancja.drewno -= 2000;
                Zasoby.instancja.zloto -= 500;
                Zasoby.instancja.zelazo -= 750;
                GeneratorZmienne.Glowny = 2;
                GeneratorZmienne.LudzieMax = 100;
            }
            if (GeneratorZmienne.Glowny == 0) {
                Zasoby.instancja.zywnosc -= 2000;
                Zasoby.instancja.drewno -= 1500;
                Zasoby.instancja.zloto -= 500;
                GeneratorZmienne.Glowny = 1;
                GeneratorZmienne.LudzieMax = 50;
            }
        }

        if (i == 3) {
            Zasoby.instancja.zywnosc -= 1000;
            Zasoby.instancja.drewno -= 1500;
            Zasoby.instancja.zloto -= 500;
            Zasoby.instancja.zlotoprzyr += 5;
        }

        if (i == 4)
        {
            Zasoby.instancja.zywnosc -= 200;
            Zasoby.instancja.drewno -= 100;
            Zasoby.instancja.zywnoscprzyr += 5;
        }

        if (i == 5)
        {
            Zasoby.instancja.zywnosc -= 1200;
            Zasoby.instancja.drewno -= 300;
            Zasoby.instancja.zloto -= 500;
            Zasoby.instancja.zelazo -= 200;
            Zasoby.instancja.zelazoprzyr += 5;
        }
        GeneratorZmienne.Czas += 24;
        Buduj();
    }

    private void Party() {
        Clear();
        btn1.gameObject.SetActive(true);
        btn1.GetComponentInChildren<Text>().text = "Wróc";
        btn1.GetComponent<Button>().onClick.AddListener(delegate { Start(); });
        gracz = GameObject.Find("Gracz");
        temp = "Statystyki drużyny<br><br>";
        temp += "Atak bohatera: " + gracz.GetComponent<GraczRuch>().atak + "<br>";
        temp += "Obrona bohatera: " + gracz.GetComponent<GraczRuch>().obrona + "<br>";
        temp += "Kondycja bohatera: " + gracz.GetComponent<GraczRuch>().kondycja + "<br>";
        temp += "Życie bohatera: " + gracz.GetComponent<GraczRuch>().hp + "<br><br>";
        temp += "Liczba Robotników: " + GeneratorZmienne.Robotnik.Liczba + "<br>";
        temp += "Liczba Żołnierzy: " + GeneratorZmienne.Zolnierz.Liczba + "<br>";
        temp += "Liczba Rycerzy: " + GeneratorZmienne.Rycerz.Liczba + "<br><br>";
        temp += "Kondycja: " + GeneratorZmienne.Kondycja + "/" + (gracz.GetComponent<GraczRuch>().kondycja + GeneratorZmienne.MaxKon()) + "<br>";
        temp += "Punkty Życia: " + GeneratorZmienne.PZ + "/" + (gracz.GetComponent<GraczRuch>().hp + GeneratorZmienne.MaxPZ());
        txt.text = temp.Replace("<br>", "\n");
    }

    private void Odpocznij() {

        Clear();
        gracz = GameObject.Find("Gracz");
        btn1.gameObject.SetActive(true);
        btn1.GetComponentInChildren<Text>().text = "Kontynuuj";
        btn1.GetComponent<Button>().onClick.AddListener(delegate { Start(); });
        txt.GetComponentInChildren<Text>().text = "Nasz bohater i jego drużyna są wypoczęci i gotowi na dalsze przygody!";
        GeneratorZmienne.Czas += 10f;
        GeneratorZmienne.Kondycja = System.Convert.ToInt32(gracz.GetComponent<GraczRuch>().kondycja + GeneratorZmienne.MaxKon());
        GeneratorZmienne.PZ = System.Convert.ToInt32(gracz.GetComponent<GraczRuch>().hp + GeneratorZmienne.MaxPZ());
    }

    private void Najmij()
    {
        Clear();
        btn1.gameObject.SetActive(true);
        btn1.GetComponentInChildren<Text>().text = "Robotnik";
        if (Zasoby.instancja.zywnosc < 200 || Zasoby.instancja.zloto < 50 || GeneratorZmienne.Baraki < 1 || GeneratorZmienne.MaxLudzie() == GeneratorZmienne.LudzieMax || GeneratorZmienne.MaxLudzie() + 1 > Zasoby.instancja.ludzie) btn1.interactable = false;
		btn1.GetComponent<Button>().onClick.AddListener(delegate { KupJedn(1); });
		btn2.gameObject.SetActive(true);
        btn2.GetComponentInChildren<Text>().text = "Żołnierz";
		if (Zasoby.instancja.zelazo < 100 || Zasoby.instancja.zywnosc < 500 || Zasoby.instancja.zloto < 150 || GeneratorZmienne.Baraki < 2 || GeneratorZmienne.MaxLudzie() == GeneratorZmienne.LudzieMax || GeneratorZmienne.MaxLudzie() + 1 > Zasoby.instancja.ludzie) btn2.interactable = false;
		btn2.GetComponent<Button>().onClick.AddListener(delegate { KupJedn(2); });
		btn3.gameObject.SetActive(true);
        btn3.GetComponentInChildren<Text>().text = "Rycerz";
		if (Zasoby.instancja.zelazo < 500 || Zasoby.instancja.zywnosc < 1000 || Zasoby.instancja.zloto < 300 || GeneratorZmienne.Baraki < 3 || GeneratorZmienne.MaxLudzie() == GeneratorZmienne.LudzieMax || GeneratorZmienne.MaxLudzie() + 1 > Zasoby.instancja.ludzie) btn3.interactable = false;
		btn3.GetComponent<Button>().onClick.AddListener(delegate { KupJedn(3); });
		btn4.gameObject.SetActive(true);
        btn4.GetComponent<Button>().onClick.AddListener(delegate { Start(); });
        btn4.GetComponentInChildren<Text>().text = "Wróć";
		temp = "Kogo nasz bohater powinien nająć?<br><br>";
		temp += "Robotnik<br>Koszt: 200 żywności i 10 złota.<br>Statystyki: Atak 2, Obrona 2, PZ 10, Kondycja 50<br>Wymaga wybudowanych baraków.<br>";
		temp += "Żołnierz<br>Koszt: 500 żywności, 100 żelaza i 150 złota.<br>Statystyki: Atak 6, Obrona 3, PZ 30, Kondycja 20<br>Wymaga wybudowanych koszar.<br>";
		temp += "Rycerz<br>Koszt: 1000 żywności, 500 żelaza i 300 złota.<br>Statystyki: Atak 5, Obrona 10, PZ 80, Kondycja 10<br>Wymaga wybudowanej szkoły rycerskiej.";
		txt.text = temp.Replace("<br>", "\n");
    }
	
	private void KupJedn(int i){
		if (i==1) {
			GeneratorZmienne.Robotnik.Liczba++;
			Zasoby.instancja.zywnosc -= 200;
			Zasoby.instancja.zloto -= 50;
			GeneratorZmienne.Kondycja += System.Convert.ToInt32(GeneratorZmienne.Robotnik.Kondycja);
			GeneratorZmienne.PZ += System.Convert.ToInt32(GeneratorZmienne.Robotnik.PZ);
			}
		if (i==2) {
			GeneratorZmienne.Zolnierz.Liczba++;
			Zasoby.instancja.zelazo -= 100;
			Zasoby.instancja.zywnosc -= 500;
			Zasoby.instancja.zloto -= 150;
			GeneratorZmienne.Kondycja += System.Convert.ToInt32(GeneratorZmienne.Zolnierz.Kondycja);
			GeneratorZmienne.PZ += System.Convert.ToInt32(GeneratorZmienne.Zolnierz.PZ);
			}
		if (i==3) {
			GeneratorZmienne.Rycerz.Liczba++;
			Zasoby.instancja.zelazo -= 500;
			Zasoby.instancja.zywnosc -= 1000;
			Zasoby.instancja.zloto -= 300;
			GeneratorZmienne.Kondycja += System.Convert.ToInt32(GeneratorZmienne.Rycerz.Kondycja);
			GeneratorZmienne.PZ += System.Convert.ToInt32(GeneratorZmienne.Rycerz.PZ);
			}
		Najmij();
	}
	
    private void Drewno()
    {
		Clear();
		btn1.gameObject.SetActive(true);
		btn1.GetComponentInChildren<Text>().text = "Kontynuuj";
		btn1.GetComponent<Button>().onClick.AddListener(delegate { Start(); });
        tmp = Random.Range(10, 35);
        Zasoby.instancja.drewno += tmp;
        txt.GetComponentInChildren<Text>().text = "Po kilku godzinach ciężkiej pracy nasz bohater uzbierał " + tmp + " jednostek drewna.";
        GeneratorZmienne.Czas += 4f;
		GeneratorZmienne.Kondycja -= 30;
    }

    private void ZelZl()
    {
		Clear();
		btn1.gameObject.SetActive(true);
		btn1.GetComponentInChildren<Text>().text = "Kontynuuj";
		btn1.GetComponent<Button>().onClick.AddListener(delegate { Start(); });
        tmp = Random.Range(5, 20);
        if (Random.Range(0, 100) <= 65)
        {
            Zasoby.instancja.zelazo += tmp;
            txt.GetComponentInChildren<Text>().text = "Nasz bohater znalazł żyłę żelaza i wydobył " + tmp + " jednostek.";
            GeneratorZmienne.Czas += 8f;
			GeneratorZmienne.Kondycja -= 40;
        }
        else
        {
            Zasoby.instancja.zloto += tmp;
            txt.GetComponentInChildren<Text>().text = "Bohater miał szczęście i znalazł żyłę złota! Wydobył on " + tmp + " jednostek.";
            GeneratorZmienne.Czas += 8f;
			GeneratorZmienne.Kondycja -= 40;
        }
    }

    private void DrewnoAuto()
    {
		Clear();
		btn1.gameObject.SetActive(true);
        Zasoby.instancja.drewno -= 100;
        Zasoby.instancja.zywnosc -= 200;
        Zasoby.instancja.drewnoprzyr += 15;
		GeneratorZmienne.Czas += 12f;
		GeneratorZmienne.Kondycja -= 60;
        GeneratorZmienne.trigger.name = "Tartak";
        GeneratorZmienne.trigger.GetComponent<SpriteRenderer>().sprite = Zasoby.instancja.tartak;
        GameObject.Find("Gen").GetComponent<Main>().tartaki.Add(GeneratorZmienne.trigger);
        txt.text = "W ciągu kilkunastu godzin nasz bohater najął ludzi i wybudował tartak. Od teraz nasz bohater będzie miał stały przychód drewna.";
		btn1.GetComponentInChildren<Text>().text = "Kontynuuj";
		btn1.GetComponent<Button>().onClick.AddListener(delegate { Back(); });
    }

	private void Farma()
    {
		Clear();
		btn1.gameObject.SetActive(true);
        Zasoby.instancja.drewno -= 200;
        Zasoby.instancja.zelazo -= 50;
        Zasoby.instancja.zywnosc -= 100;
		GeneratorZmienne.Czas += 12f;
		GeneratorZmienne.Kondycja -= 80;
        Zasoby.instancja.zywnoscprzyr += 15;
        GeneratorZmienne.trigger.name = "Uprawa";
        GeneratorZmienne.trigger.gameObject.GetComponent<SpriteRenderer>().sprite = Zasoby.instancja.uprawa;
        GameObject.Find("Gen").GetComponent<Main>().pola.Add(GeneratorZmienne.trigger);
        txt.text = "Po godzinach ciężkiej pracy nasz bohater wybudował farmę. Jego rolnicy wzięli się do obsiewania pól.";
		btn1.GetComponentInChildren<Text>().text = "Kontynuuj";
		btn1.GetComponent<Button>().onClick.AddListener(delegate { Back(); });
    }
	
    private void ZelZlAuto()
    {
		Clear();
		btn1.gameObject.SetActive(true);
        Zasoby.instancja.drewno -= 200;
        Zasoby.instancja.zelazo -= 100;
        Zasoby.instancja.zywnosc -= 300;
        Zasoby.instancja.zloto -= 50;
		GeneratorZmienne.Czas += 12f;
		GeneratorZmienne.Kondycja -= 80;
        if (Random.Range(0, 100) <= 65)
        {
            Zasoby.instancja.zelazoprzyr += 10;
        }
        else
        {
            Zasoby.instancja.zlotoprzyr += 5;          
        }
        GeneratorZmienne.trigger.name = "Kopalnia";
        GeneratorZmienne.trigger.gameObject.GetComponent<SpriteRenderer>().sprite = Zasoby.instancja.kopalnia;
        GameObject.Find("Gen").GetComponent<Main>().kopalnie.Add(GeneratorZmienne.trigger);
        txt.text = "Nasz bohater i jego ludzie trudzili się aby wybudować kopalnię. Nasz bohater będzie miał stały dopływ złota lub żelaza.";
		btn1.GetComponentInChildren<Text>().text = "Kontynuuj";
		btn1.GetComponent<Button>().onClick.AddListener(delegate { Back(); });
    }

	private void Fight()
    {
        Clear();
		gracz = GameObject.Find("Gracz");
		btn1.gameObject.SetActive(true);
		btn1.GetComponentInChildren<Text>().text = "Atakuj";
		btn1.GetComponent<Button>().onClick.AddListener(delegate { FightAtak(); });
		btn4.gameObject.SetActive(true);
		btn4.GetComponent<Button>().onClick.AddListener(delegate { Back(); });
        btn4.GetComponentInChildren<Text>().text = "Uciekaj";
		FightWypisz();
    }
	
	private void FightWypisz(){
		
		temp = "Nasz bohater walczy z " + GeneratorZmienne.Nazwa + ".<br>";
		temp += "Statystyki jednego z przeciwników<br>";
		temp += "Atak: " + GeneratorZmienne.WalkaZmienne[1] + "<br>";
		temp += "Obrona: " + GeneratorZmienne.WalkaZmienne[2] + "<br>";
		temp += "Punkty Życia: " + GeneratorZmienne.WalkaZmienne[0] + "<br><br>";
		temp += "Liczba przeciwników: " + GeneratorZmienne.WalkaZmienne[3] + "<br>";
		temp += "Pozostałe życie przeciwników: " + maxHP + "<br><br><br>";
		
		temp += "Statystyki bohatera<br>";
		temp += "Atak: " + gracz.GetComponent<GraczRuch>().atak + "<br>";
		temp += "Obrona: " + gracz.GetComponent<GraczRuch>().obrona + "<br>";
		temp += "Punkty Życia: " + gracz.GetComponent<GraczRuch>().hp + "<br><br>";
		temp += "Liczba dostępnych ludzi: " + (GeneratorZmienne.Robotnik.Liczba + GeneratorZmienne.Zolnierz.Liczba + GeneratorZmienne.Rycerz.Liczba) +"<br>";
		temp += "Pozostałe życie: " + GeneratorZmienne.PZ;
		
		txt.text = temp.Replace("<br>", "\n");
	}
	
	private void FightAtak(){
		
		Clear();
		btn1.gameObject.SetActive(true);
		btn1.GetComponentInChildren<Text>().text = "Kontynuuj";
		attack = (gracz.GetComponent<GraczRuch>().atak * Random.Range(1,5) + GeneratorZmienne.Rycerz.Atak() + GeneratorZmienne.Robotnik.Atak() + GeneratorZmienne.Zolnierz.Atak()) - (GeneratorZmienne.WalkaZmienne[3] * GeneratorZmienne.WalkaZmienne[2] * Random.Range(1,5));
		if (attack >= 0)maxHP -= attack;
		else maxHP -= 1;
		if(attack<=0) attack=1;
		temp = "Nasz bohater atakuje przeciwnika, zadając " + attack + " punktów obrażeń. ";
		if(maxHP<0) maxHP=0;
		if(maxHP==0) btn1.GetComponent<Button>().onClick.AddListener(delegate { FightWin(); });
		else btn1.GetComponent<Button>().onClick.AddListener(delegate { Fight(); });
		if((GeneratorZmienne.WalkaZmienne[0] * GeneratorZmienne.WalkaZmienne[3]) - maxHP >= GeneratorZmienne.WalkaZmienne[0]) {
			attack = System.Convert.ToSingle(System.Math.Floor(((GeneratorZmienne.WalkaZmienne[0] * GeneratorZmienne.WalkaZmienne[3]) - maxHP)/GeneratorZmienne.WalkaZmienne[0]));
			if(attack>0)temp += "Zginęło " + attack + " przeciwników.<br><br>";
			else temp += "<br><br>";
			GeneratorZmienne.WalkaZmienne[3] -= attack;
		}
		if(GeneratorZmienne.PZ>gracz.GetComponent<GraczRuch>().hp + GeneratorZmienne.MaxPZ()) System.Convert.ToInt32(gracz.GetComponent<GraczRuch>().hp + GeneratorZmienne.MaxPZ());
		attack = (GeneratorZmienne.WalkaZmienne[3] * GeneratorZmienne.WalkaZmienne[1] * Random.Range(1,5)) - (gracz.GetComponent<GraczRuch>().obrona * Random.Range(1,5) + GeneratorZmienne.Rycerz.Obrona() + GeneratorZmienne.Robotnik.Obrona() + GeneratorZmienne.Zolnierz.Obrona());
		if (attack >= 0) GeneratorZmienne.PZ -= System.Convert.ToInt32(attack);
		else GeneratorZmienne.PZ -= 1;
		if(attack<=0) attack=1;				
		temp += GeneratorZmienne.Nazwa + " kontratakują, zadając " + attack + " punktów obrażeń. ";
		if(GeneratorZmienne.Robotnik.MaxPZ() - System.Math.Round(attack / 3) >= GeneratorZmienne.Robotnik.PZ && GeneratorZmienne.Robotnik.Liczba!=0) {
			if(System.Math.Floor((GeneratorZmienne.Robotnik.MaxPZ() - System.Math.Round(attack / 3)/GeneratorZmienne.Robotnik.PZ))>0) temp += "Zginęło " + System.Math.Floor((GeneratorZmienne.Robotnik.MaxPZ() - System.Math.Round(attack / 3)/GeneratorZmienne.Robotnik.PZ)) + " robotników.<br>";
			GeneratorZmienne.Robotnik.Liczba -= System.Convert.ToSingle(System.Math.Floor((GeneratorZmienne.Robotnik.MaxPZ() - System.Math.Round(attack / 3)/GeneratorZmienne.Robotnik.PZ)));
		}
		if(GeneratorZmienne.Zolnierz.MaxPZ() - System.Math.Round(attack / 3) >= GeneratorZmienne.Zolnierz.PZ && GeneratorZmienne.Zolnierz.Liczba!=0) {
			if(System.Math.Floor((GeneratorZmienne.Zolnierz.MaxPZ() - System.Math.Round(attack / 3)/GeneratorZmienne.Zolnierz.PZ))>0) temp += "Zginęło " + System.Math.Floor((GeneratorZmienne.Zolnierz.MaxPZ() - System.Math.Round(attack / 3)/GeneratorZmienne.Zolnierz.PZ)) + " żołnierzy.<br>";
			GeneratorZmienne.Zolnierz.Liczba -= System.Convert.ToSingle(System.Math.Floor((GeneratorZmienne.Zolnierz.MaxPZ() - System.Math.Round(attack / 3)/GeneratorZmienne.Zolnierz.PZ)));
		}
		if(GeneratorZmienne.Rycerz.MaxPZ() - System.Math.Round(attack / 3) >= GeneratorZmienne.Rycerz.PZ && GeneratorZmienne.Rycerz.Liczba!=0) {
			if(System.Math.Floor((GeneratorZmienne.Rycerz.MaxPZ() - System.Math.Round(attack / 3)/GeneratorZmienne.Rycerz.PZ))>0) temp += "Zginęło " + System.Math.Floor((GeneratorZmienne.Rycerz.MaxPZ() - System.Math.Round(attack / 3)/GeneratorZmienne.Rycerz.PZ)) + " rycerzy.<br>";
			GeneratorZmienne.Rycerz.Liczba -= System.Convert.ToSingle(System.Math.Floor((GeneratorZmienne.Rycerz.MaxPZ() - System.Math.Round(attack / 3)/GeneratorZmienne.Rycerz.PZ)));
		}
		if(GeneratorZmienne.PZ <= 0){
			GeneratorZmienne.PZ=0;
			btn1.GetComponent<Button>().onClick.RemoveAllListeners();
			btn1.GetComponent<Button>().onClick.AddListener(delegate { FightLost(); });
		}
		if(GeneratorZmienne.Robotnik.Liczba < 0)GeneratorZmienne.Robotnik.Liczba = 0;
		if(GeneratorZmienne.Zolnierz.Liczba < 0)GeneratorZmienne.Zolnierz.Liczba = 0;
		if(GeneratorZmienne.Rycerz.Liczba < 0)GeneratorZmienne.Rycerz.Liczba = 0;
		txt.text = temp.Replace("<br>", "\n");
	}
	
	private void FightWin(){
		
		Clear();
		btn1.gameObject.SetActive(true);
		btn1.GetComponentInChildren<Text>().text = "Kontynuuj";
		btn1.GetComponent<Button>().onClick.AddListener(delegate { Back(); });
		txt.text = "Przeciwnicy zostali pokonani! Ich łupy należą teraz do naszego bohatera.";
		Zasoby.instancja.drewno += Random.Range(0,200) * GeneratorZmienne.WalkaZmienne[4];
        Zasoby.instancja.zelazo += Random.Range(0,100) * GeneratorZmienne.WalkaZmienne[4];
        Zasoby.instancja.zywnosc += Random.Range(100,500) * GeneratorZmienne.WalkaZmienne[4];
        Zasoby.instancja.zloto += Random.Range(0,200) * GeneratorZmienne.WalkaZmienne[4];
		GeneratorZmienne.Zmiana = 1;
		if (GeneratorZmienne.Quest == 7) GeneratorZmienne.Zwyciestwo=1;
	}
	
	private void FightLost(){
		
		Clear();
		btn1.gameObject.SetActive(true);
		btn1.GetComponentInChildren<Text>().text = "Kontynuuj";
		btn1.GetComponent<Button>().onClick.AddListener(delegate { Back(); });
		txt.text = "Nasz bohater stracił wszystkich ludzi i ledwo przeżył. Musiał on zapłacić zasobami aby ocalić życie...";
		attack = Random.Range(50,500);
		if (attack >= Zasoby.instancja.drewno) Zasoby.instancja.drewno = 0;
		else Zasoby.instancja.drewno -= attack;
		attack = Random.Range(50,500);
		if (attack >= Zasoby.instancja.zelazo) Zasoby.instancja.zelazo = 0;
		else Zasoby.instancja.zelazo -= attack;
		attack = Random.Range(50,500);
		if (attack >= Zasoby.instancja.zywnosc) Zasoby.instancja.zywnosc = 0;
		else Zasoby.instancja.zywnosc -= attack;
		attack = Random.Range(50,500);
		if (attack >= Zasoby.instancja.zloto) Zasoby.instancja.zloto = 0;
		else Zasoby.instancja.zloto -= attack;
		GeneratorZmienne.Robotnik.Liczba = 0;
		GeneratorZmienne.Zolnierz.Liczba = 0;
		GeneratorZmienne.Rycerz.Liczba = 0;
	}
	
    private void Back()
    {
		Time.timeScale = 1;
        Zasoby.instancja.UpdateZasoby();
        SceneManager.UnloadSceneAsync("Walka");
    }
}
