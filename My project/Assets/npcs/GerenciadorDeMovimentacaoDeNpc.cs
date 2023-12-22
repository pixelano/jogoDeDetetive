using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class GerenciadorDeMovimentacaoDeNpc : MonoBehaviour
{
    public NavMeshAgent agente;
    public Vector3 target;
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        if(agente == null)
        {
            agente = gameObject.AddComponent<NavMeshAgent>();
        }
    }
    private void Update()
    {
        agente.destination = target; 
    }


}
[CustomEditor(typeof(GerenciadorDeMovimentacaoDeNpc))]
public class EditorGerenciadorDeMovimentacaoDeNpc : Editor
{
    private void OnSceneGUI()
    {
        GerenciadorDeMovimentacaoDeNpc meuScript = (GerenciadorDeMovimentacaoDeNpc)target;
        meuScript.target = Handles.PositionHandle(meuScript.target, Quaternion.identity);
    }

    }
