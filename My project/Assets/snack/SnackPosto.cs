using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SnackPosto : MonoBehaviour
{
    [SerializeField]
    public List<locaisNaFila> fila_ = new List<locaisNaFila>();
    [System.Serializable]
    public class locaisNaFila {
        public GerenciadorDeNpc npc_;
        public Vector3 local;
    }
    public bool automatico;
    bool temGente;
    private void Update()
    {
        if (temGente)
        {
            if (fila_[0].npc_ == null)
            {

                foreach(var a in fila_)
                {
                    if (a == fila_[0])
                        continue;

                    if(a.npc_ != null)
                    {
                        fila_[0].npc_ = a.npc_;
                        break;
                    }
                }
                for(int x= 1; x <fila_.Count-1; x++)
                {
                    fila_[x].npc_ = fila_[x+1].npc_;
                }
                fila_[fila_.Count-1].npc_ = null;

            }
        }
    }
    public void entrarnafila(GerenciadorDeNpc a)
    {
        temGente = true;
        for(int x = 0; x < fila_.Count; x++)
        {
            if (fila_[x].npc_ == null)
            {
                fila_[x].npc_ = a;
                break;
            }
        }
    }

}

[CustomEditor(typeof(SnackPosto))]

public class EditorSnacPosto : Editor {
    private void OnSceneGUI()
    {
        SnackPosto meuScript = (SnackPosto)target;
        for(int x = 0; x < meuScript.fila_.Count; x++)
        {
            meuScript.fila_[x].local = Handles.PositionHandle(meuScript.fila_[x].local + meuScript.transform.position, Quaternion.identity) - meuScript.transform.position;

            if(x < meuScript.fila_.Count - 1)
            {
                Handles.ArrowHandleCap(0, meuScript.fila_[x].local + meuScript.transform.position,
                    Quaternion.LookRotation(
                   meuScript.fila_[x+1].local - meuScript.fila_[x].local,Vector3.up),
                   Vector3.Distance(meuScript.fila_[x].local, meuScript.fila_[x+1].local),
                   EventType.Repaint);
            }
        }
       
    }

}

