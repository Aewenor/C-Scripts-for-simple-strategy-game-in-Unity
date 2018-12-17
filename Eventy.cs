using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Eventy : MonoBehaviour {

	public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;
	public Text txt;
	private string temp;

	private void Clear(){
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
	
	void Start () {
		Time.timeScale = 0;
		Clear();
		btn4.gameObject.SetActive(true);
        btn4.GetComponent<Button>().onClick.AddListener(delegate { Back(); });
        btn4.GetComponentInChildren<Text>().text = "Odejdź";

		if (GeneratorZmienne.Event == -1)
        {
			Clear();
			Muzyka.instance.GetComponent<AudioSource>().Stop ();
            btn4.gameObject.SetActive(true);
			btn4.GetComponent<Button>().onClick.AddListener(delegate { Application.Quit(); });
			btn4.GetComponentInChildren<Text>().text = "Wyjdź";
			temp = "Nadzedł czas...<br><br>";
			temp += "Wybuchła wojna pomiędzy Irderal oraz Moreth. Nasz bohater zdecydował nie opowiadać się po żadnej ze stron.";
			temp += " Obie armie starły się ze sobą w wielu bitwach, pustosząc większość wyspy. Nasz bohater utrzymał swój gród pomimo ataków i wraz ze swoją drużyną kontroluje on wyspę.";
			temp += " Gdy armie najeźdźców zostały robite, nasz bohater poprowadził ocalałych mieszkańców, odbudowując wyspę. Nasz bohater został szanowanym władcą dzięki tobie!<br><br>Grautlacje!<br>Ukończyłeś Kroniki Lavandotu!";
			txt.text = temp.Replace("<br>", "\n");
        }
		
        if (GeneratorZmienne.Event == 0)
        {
            btn4.GetComponentInChildren<Text>().text = "Kontynuuj";
			temp = "WItaj w Kronikach Lavandoru<br><br>";
			temp += "Przedstawiona historia dzieje się na wyspie Iliath w krainie Lavandor. Dwa potężne mocarstwa: Irderal oraz Moreth konkurują ze sobą w każdym aspekcie.";
			temp += " Pokój jeszcze trwa ale każdy czuje, że wojna jest nieunikniona, a położenie wyspy Ilath czyni ją znakomitą bazą dla obu mocarstw, dlatego oba kraje starają się ją zająć.";
			temp += " Tutaj pojawia się nasz bohater. Jest on odkrywcą, który za ostatnie pieniądze popłynął na Ilath i wybudował tam małe gospodarstwo. Co będzie celem naszego bohatera? Zdobycie bogactwa? A może pomoże on któremuś mocarstwu w zdobyciu wyspy? Wkrótce się przekonamy...";
			txt.text = temp.Replace("<br>", "\n");
        }
		
		if (GeneratorZmienne.Event == 1)
        {
            btn4.GetComponentInChildren<Text>().text = "Kontynuuj";
			txt.text = "Nasz bohater podróżuje przez sielską krainę. Słońce świeci, kilka saren przebiega w oddali. Nasz bohater uśmiechnął się i zaczął się zastanawiać co się dzisiaj wydarzy...";
        }
		
		if (GeneratorZmienne.Event == 2)
        {
            btn4.GetComponentInChildren<Text>().text = "Kontynuuj";
			txt.text = "Nasz bohater podczas podróży natknął się na rannego człowieka! Nasz bohater poświęcił chwilę czasu na opatrzenie go. Wdzięczny człowiek dołączył do gospodarstwa naszego bohatera.";
            if (Zasoby.instancja.ludzie < GeneratorZmienne.LudzieMax) Zasoby.instancja.ludzie++;
        }
		
		if (GeneratorZmienne.Event == 3)
        {
            btn4.GetComponentInChildren<Text>().text = "Kontynuuj";
			txt.text = "Nasz bohater był zmęczony i przysnął na moment w karczmie. Gdy się obudził to zauważył że nie ma jego sakiewki!";
            Zasoby.instancja.zloto -= 20;
            if(Zasoby.instancja.zloto < 0) Zasoby.instancja.zloto = 0;
        }
        
	}
	
	private void Back()
    {
		if (GeneratorZmienne.Quest != 0) Time.timeScale = 1;
        SceneManager.UnloadSceneAsync("Eventy");
    }

}
