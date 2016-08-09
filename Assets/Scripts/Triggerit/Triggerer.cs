using UnityEngine;
using System.Collections;

public abstract class Triggerer : MonoBehaviour {

    public void trigger(params object[] values)
    {
        Tapahtuma tapahtuma = luoTapahtuma(this, values);
        lahetaViesti(tapahtuma);

        Destroy(tapahtuma); //koska miljoona tapahtumaa hillumassa olisi parast ikin
    }

    public Tapahtuma luoTapahtuma(Triggerer trigger, object[] values)
    {
        Tapahtuma tapahtuma = this.gameObject.AddComponent<Tapahtuma>(); //koska unity
        tapahtuma.initialize(trigger, values); //luodaan tapahtuma oikeasti

        return tapahtuma;
    }

    public abstract void lahetaViesti(Tapahtuma tapahtuma);
}
