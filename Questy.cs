using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Questy : MonoBehaviour
{

    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;
    public Text txt;
    private GameObject gen;
    private string temp;
    private int aktualny;

    private void Clear()
    {
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

    void Start()
    {
        gen = GameObject.Find("Gen");
        Time.timeScale = 0;
        Clear();
        btn4.gameObject.SetActive(true);
        btn4.GetComponent<Button>().onClick.AddListener(delegate { Back(); });
        btn4.GetComponentInChildren<Text>().text = "Wróć";
        if (GeneratorZmienne.Quest == 0)
        {
            btn4.GetComponentInChildren<Text>().text = "Kontynuuj";
            temp = "Nowe zadanie<br><br>";
            temp += "Nasz bohater jest sam z małym gospodarstwem i niemal zerowymi zasobami. Od czegoś trzeba zacząć. Nasz bohater musi wybudować farmę, tartak oraz kopalnię aby posiadać stały dopływ surowców.";
            txt.text = temp.Replace("<br>", "\n");
            temp = "Początki<br><br>";
            temp += "Wybuduj farmę, tartak oraz kopalnię.";
            gen.GetComponent<Main>().QuestTXT.text = temp.Replace("<br>", "\n");
        }
        if (GeneratorZmienne.Quest == 1)
        {
            temp = "Nowe zadanie<br><br>";
            temp += "Nasz bohater wykonał pierwszy krok ku rozwojowi! Pierwsze dostawy nadjechały. Teraz nasz bohater musi nająć ludzi do pomocy. Trzeba wybudować baraki i nająć robotników.";
            Zasoby.instancja.zywnosc += 1000;
            Zasoby.instancja.drewno += 500;
            Zasoby.instancja.zloto += 300;
            Zasoby.instancja.zelazo += 150;
            txt.text = temp.Replace("<br>", "\n");
            temp = "Pierwszy pomocnik<br><br>";
            temp += "Zrekrutuj Robotnika.";
            gen.GetComponent<Main>().QuestTXT.text = temp.Replace("<br>", "\n");
        }
        if (GeneratorZmienne.Quest == 2)
        {
            temp = "Nowe zadanie<br><br>";
            temp += "Pierwszy z wielu pomocników jakiego będzie potrzebować nasz bohater. Czas na zwiększenie pojemności gospodarstwa. Rozbuduj gospodarstwo do Wioski.";
            Zasoby.instancja.zywnosc += 50;
            Zasoby.instancja.drewno += 30;
            Zasoby.instancja.zloto += 20;
            Zasoby.instancja.zelazo += 10;
            txt.text = temp.Replace("<br>", "\n");
            temp = "Miejsce do życia<br><br>";
            temp += "Rozbuduj gospodatstwo do Wioski.";
            gen.GetComponent<Main>().QuestTXT.text = temp.Replace("<br>", "\n");
        }
        if (GeneratorZmienne.Quest == 3)
        {
            temp = "Nowe zadanie<br><br>";
            temp += "Wioska została wybudowana, kilka osób osiedliło się obok gospodarstwa naszego bohatera. Jednak im więcej ludzi to tym większe zapotrzebowanie na zasoby. Wybudduj po 4 farmy, tartaki i kopalnie.";
            Zasoby.instancja.zywnosc += 1000;
            Zasoby.instancja.drewno += 500;
            Zasoby.instancja.zloto += 300;
            Zasoby.instancja.zelazo += 150;
            Zasoby.instancja.ludzie += 4;
            txt.text = temp.Replace("<br>", "\n");
            temp = "Większa infrastruktura<br><br>";
            temp += "Wybuduj po 4 farmy, tartaki oraz kopalnie.";
            gen.GetComponent<Main>().QuestTXT.text = temp.Replace("<br>", "\n");
        }
        if (GeneratorZmienne.Quest == 4)
        {
            temp = "Nowe zadanie<br><br>";
            temp += "Nasz bohater staje się coraz bardziej bogatszy i wpływowy. Przydałaby mu się ochrona. Zrekrutuj 3 Żołnierzy.";
            Zasoby.instancja.zywnosc += 500;
            Zasoby.instancja.drewno += 300;
            Zasoby.instancja.zloto += 100;
            Zasoby.instancja.zelazo += 50;
            txt.text = temp.Replace("<br>", "\n");
            temp = "Ochrona<br><br>";
            temp += "Zrekrutuj 3 Żołnierzy.";
            gen.GetComponent<Main>().QuestTXT.text = temp.Replace("<br>", "\n");
        }
        if (GeneratorZmienne.Quest == 5)
        {
            temp = "Nowe zadanie<br><br>";
            temp += "Wieść niesie, że mocarstwa szykują się do wojny. Nasz bohater musi być przygotowany. Rozbuduj gospodarstwo do Grodu, zrekrutuj 5 Rycerzy i zgromadź żywność potrzebną do utrzymania oblężenia.";
		    Zasoby.instancja.zywnosc += 500;
            Zasoby.instancja.drewno += 300;
            Zasoby.instancja.zloto += 100;
            Zasoby.instancja.zelazo += 50;
            txt.text = temp.Replace("<br>", "\n");
            temp = "Ostatnia bitwa<br><br>";
            temp += "Zrekrutuj 5 Rycerzy i zgromadź 10000 żywności.";
            gen.GetComponent<Main>().QuestTXT.text = temp.Replace("<br>", "\n");
        }
    }

    private void Back()
    {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync("Questy");
    }
}
