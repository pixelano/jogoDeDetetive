using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerNpc : MonoBehaviour
{
    public List<SnackPosto> pontosSnack;

    public GameObject modelo;

    //
    public bool instanciarUm;

    private void Update()
    {
        if(instanciarUm)
        {
            instanciarUm = false;

            pontosSnack[0].entrarnafila(modelo.GetComponent<GerenciadorDeNpc>());


        }
    }


}
