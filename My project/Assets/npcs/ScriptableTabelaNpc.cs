using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ScriptableTabelaNpc
{
    public bool NpcManual;
     
    [SerializeField]
    public List<snack_> pipoca;

    [SerializeField]
    public List<snack_> refrigerante;
    [SerializeField]
    public List<sabor> doces;

}
[System.Serializable]
public class snack_
{
    public tamanhos tamanho;
    public sabor sabor;
}
[System.Serializable]
public class sabor
{
    public bool A, B, C;
}


[System.Serializable]
public class tamanhos
{
    public bool pequeno, medio, grande;
}