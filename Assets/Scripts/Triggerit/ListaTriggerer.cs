using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ListaTriggerer : Triggerer
{
    private List<Objekti> vastaanottajat;

    void Start()
    {
        vastaanottajat = new List<Objekti>();
    }

    public override void lahetaViesti(Tapahtuma tapahtuma)
    {
        foreach (Objekti obj in vastaanottajat)
        {
            obj.mainHandler.handle(tapahtuma);
        }
    }

    public void lisaaVastaanottaja(Objekti obj)
    {
        vastaanottajat.Add(obj);
    }

    public void poistaVastaanottaja(Objekti obj)
    {
        vastaanottajat.Remove(obj);
    }
}
