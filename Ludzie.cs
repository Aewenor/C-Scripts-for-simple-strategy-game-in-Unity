using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ludzie {

	private float atak, obrona, liczba, kondycja, hp;
	private string nazwa;
	
	public Ludzie(string a, float b,float c,float d,float e,float f){
		atak=b;
		obrona=c;
		liczba=d;
		kondycja=e;
		hp=f;
		nazwa=a;
	}
	
	public float Liczba
    {
        get
        {
            return liczba;
        }
        set
        {
            liczba = value;
        }
    }
	
	public float PZ
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }
	
	public float Kondycja
    {
        get
        {
            return kondycja;
        }
        set
        {
            kondycja = value;
        }
    }
	
	public string Nazwa
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
	
	public float MaxPZ(){
		return liczba * hp;
	}
	
	public float MaxKon(){
		return liczba * kondycja;
	}
	
	public float Atak(){
		return atak * Random.Range(1,5) * liczba;
	}
	
	public float Obrona(){
		return obrona * Random.Range(1,5) * liczba;
	}
}
