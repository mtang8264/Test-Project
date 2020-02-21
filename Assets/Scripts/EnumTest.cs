using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumTest : MonoBehaviour
{
    public enum Food {Chicken_Parm, Soup_Dumplings, Burger, Potato, Shepards_Pie}
    public enum Games {Portal, League_of_Legends, Pokemon, Magic, Monsoon}

    void Start()
    {
        Food f = Food.Soup_Dumplings;
        Games g = Games.Magic;

        Debug.Log((int)f + " - " + f.ToString());
        Debug.Log((int)g + " - " + g.ToString());

        f = (Food)g;

        Debug.Log((int)f + " - " + f.ToString());
        Debug.Log((int)g + " - " + g.ToString());
    }
}
