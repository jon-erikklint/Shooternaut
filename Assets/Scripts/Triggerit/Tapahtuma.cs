using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Tapahtuma : MonoBehaviour {

    public Triggerer triggerer { get { return _triggerer; } }
    private Triggerer _triggerer;

    private Dictionary<string, object> arvoparit;

    public void initialize(Triggerer trigger, object[] arvot)
    {
        this._triggerer = trigger;

        alustaDictionary(arvot);
    }

    private void alustaDictionary(object[] arvot)
    {
        arvoparit = new Dictionary<string, object>();

        for(int i = 0; i < arvot.Length; i += 2)
        {
            string nimi;
            try
            {
                nimi = (string)arvot[i];
            }
            catch (Exception e)
            {
                Debug.Log("joka toinen arvo ei string");
                break;
            }

            object arvo;

            try
            {
                arvo = arvot[i + 1];
            }
            catch(Exception e)
            {
                Debug.Log("pariton määrä arvoja");
                break;
            }

            arvoparit[nimi] = arvo;
        }
    }

    public int? getInt(string nimi)
    {
        if(arvoparit[nimi] == null)
        {
            return null;
        }

        int? arvo;

        try
        {
            arvo = (int) arvoparit[nimi];
        }
        catch(Exception e)
        {
            arvo = null;
        }

        return arvo;
    }

    public string getString(string nimi)
    {
        if (arvoparit[nimi] == null)
        {
            return null;
        }

        string arvo;

        try
        {
            arvo = (string) arvoparit[nimi];
        }
        catch (Exception e)
        {
            arvo = null;
        }

        return arvo;
    }

    public bool? getBool(string nimi)
    {
        if (arvoparit[nimi] == null)
        {
            return null;
        }

        bool? arvo;

        try
        {
            arvo = (bool) arvoparit[nimi];
        }
        catch (Exception e)
        {
            arvo = null;
        }

        return arvo;
    }

    public GameObject getGameObject(string nimi)
    {
        if (arvoparit[nimi] == null)
        {
            return null;
        }

        GameObject arvo;

        try
        {
            arvo = (GameObject) arvoparit[nimi];
        }
        catch (Exception e)
        {
            arvo = null;
        }

        return arvo;
    }

    public Component getComponent(string nimi)
    {
        if (arvoparit[nimi] == null)
        {
            return null;
        }

        Component arvo;

        try
        {
            arvo = (Component) arvoparit[nimi];
        }
        catch (Exception e)
        {
            arvo = null;
        }

        return arvo;
    }
}
