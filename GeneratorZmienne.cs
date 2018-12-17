using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GeneratorZmienne {

	public static float[] WalkaZmienne = new float[5];
	public static Ludzie Robotnik = new Ludzie("Robotnik",2,2,0,50,10);//nazwa,atak,obrona,liczba,kondycja,hp
	public static Ludzie Zolnierz = new Ludzie("Żołnierz",6,3,0,20,30);//nazwa,atak,obrona,liczba,kondycja,hp
	public static Ludzie Rycerz = new Ludzie("Rycerz",5,10,0,10,80);//nazwa,atak,obrona,liczba,kondycja,hp
	public static int Zwyciestwo;
    private static int lPol, lZas, lPrz, scena, zmiana, lastid, kond, pz, evnt, baraki, glowny, ludziemax, quest;
    private static float czas;
	private static string nazwa, opis;
	
	public static float MaxKon()
    {
        return GeneratorZmienne.Robotnik.MaxKon() + GeneratorZmienne.Zolnierz.MaxKon() + GeneratorZmienne.Rycerz.MaxKon();
    }
		
	public static float MaxPZ()
    {
        return GeneratorZmienne.Robotnik.MaxPZ() + GeneratorZmienne.Zolnierz.MaxPZ() + GeneratorZmienne.Rycerz.MaxPZ();
    }

    public static float MaxLudzie()
    {
        return GeneratorZmienne.Robotnik.Liczba + GeneratorZmienne.Zolnierz.Liczba + GeneratorZmienne.Rycerz.Liczba;
    }

    public static int Pola
    {
        get
        {
            return lPol;
        }
        set
        {
            lPol = value;
        }
    }

    public static int LudzieMax
    {
        get
        {
            return ludziemax;
        }
        set
        {
            ludziemax = value;
        }
    }

    public static int Glowny
    {
        get
        {
            return glowny;
        }
        set
        {
            glowny = value;
        }
    }

    public static int Zasoby
    {
        get
        {
            return lZas;
        }
        set
        {
            lZas = value;
        }
    }

    public static int Przeciwnicy
    {
        get
        {
            return lPrz;
        }
        set
        {
            lPrz = value;
        }
    }

	public static int Baraki
    {
        get
        {
            return baraki;
        }
        set
        {
            baraki = value;
        }
    }
	
    public static int Scena
    {
        get
        {
            return scena;
        }
        set
        {
            scena = value;
        }
    }

    public static int Quest
    {
        get
        {
            return quest;
        }
        set
        {
            quest = value;
        }
    }

    public static float Czas
    {
        get
        {
            return czas;
        }
        set
        {
            czas = value;
        }
    }

    public static int Zmiana
    {
        get
        {
            return zmiana;
        }
        set
        {
            zmiana = value;
        }
    }
	
	public static int LastId
    {
        get
        {
            return lastid;
        }
        set
        {
            lastid = value;
        }
    }
	
	public static int Kondycja
    {
        get
        {
            return kond;
        }
        set
        {
            kond = value;
        }
    }
	
	public static int PZ
    {
        get
        {
            return pz;
        }
        set
        {
            pz = value;
        }
    }
	
	public static int Event
    {
        get
        {
            return evnt;
        }
        set
        {
            evnt = value;
        }
    }
	
	public static string Nazwa //przeciwnik
    {
        get
        {
            return nazwa;
        }
        set
        {
            nazwa = value;
        }
    }
	
	public static string Opis //przeciwnik
    {
        get
        {
            return opis;
        }
        set
        {
            opis = value;
        }
    }
}
