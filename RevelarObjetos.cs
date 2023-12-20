using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Linq;
using UnityEditor;
using System;
using UnityEngine.UIElements;
using System.Drawing;
using System.Net;

public class RevelarObjetos : MonoBehaviour
{
    // se um objeto que deve ser oculto estiver no raio da lanterna deve-se mostralo;
    // o objeto como ele fica invisivel deve-se desativar o mesh render deles;
    /* 
      este script vai verificar os objetos os objetos que estiverem na tela e que tiverem na Layer de "ObjetoOculto",
    caso ele esteja sendo ativado pela camera ativa o mesh render se não desativa.

     */

    public LayerMask layerObjetoOculto;
    public Camera cam;
    public GameObject Lanterna;
    public Light lanterna_;


    public float AbiasOffSet;
    public float tamanhoHorizontal, distanciaDaLanterna, anguloLanterna;
    private void Start()
    {
      //  cam = Camera.main;

        lanterna_ = Lanterna.GetComponent<Light>();

    }

    public void segundaForma()
    {

        List<RaycastHit> hits = Physics.BoxCastAll(Lanterna.transform.position,
            Vector3.one * (tamanhoHorizontal / 2),
            Lanterna.transform.forward, Lanterna.transform.rotation,
            distanciaDaLanterna, layerObjetoOculto).ToList();
            
        foreach(var a in hits)
        {

            if (a.collider == null)
                continue;
            float angl = Vector3.Angle(Lanterna.transform.forward, a.collider.transform.position - Lanterna.transform.position);

            Debug.Log(angl);

            if(angl+ AbiasOffSet < anguloLanterna/2 && Vector3.Distance(Lanterna.transform.position , a.collider.transform.position)+ AbiasOffSet < distanciaDaLanterna )
            {
                a.collider.GetComponent<MeshRenderer>().enabled = true;
            }
            else { a.collider.GetComponent<MeshRenderer>().enabled = false; }
        }

    }

  
    private void Update()
    {

        lanterna_.range = distanciaDaLanterna;
        anguloLanterna = MathF.Atan(tamanhoHorizontal / distanciaDaLanterna) * 180 / 3.14f;
        lanterna_.spotAngle = anguloLanterna;
      //    primeiraForma();
        segundaForma();

    }
 
    public  List<RaycastHit> FindCommonRaycastHits(List<RaycastHit> list1, List<RaycastHit> list2)
    {
        List<RaycastHit> commonHits = new List<RaycastHit>();

        for (int i = 0; i < list1.Count; i++)
        {
            for (int j = 0; j < list2.Count; j++)
            {
                if (list1[i].collider == null)
                    continue;
                if (list1[i].collider == list2[j].collider)
                {
              
                  
                   
                    commonHits.Add(list1[i]);
                  
                    break;
                }
            }
        }

        return commonHits;
    }
    public static List<RaycastHit> FindOnlyInA(List<RaycastHit> listA, List<RaycastHit> listB)
    {
        List<RaycastHit> onlyInA = new List<RaycastHit>();

        for (int i = 0; i < listA.Count; i++)
        {
            bool foundInB = false;

            for (int j = 0; j < listB.Count; j++)
            {
                if (listA[i].collider == null)
                    continue;
                if (listA[i].collider == listB[j].collider)
                {
                    foundInB = true;
                    break;
                }
            }

            if (!foundInB)
            {
                onlyInA.Add(listA[i]);
            }
        }

        return onlyInA;
    }

}
[CustomEditor(typeof(RevelarObjetos))]
public class editorRevelarObjetos : Editor {

    public SerializedProperty 
        layerObjetoOculto, cam, Lanterna, AnguloOffSet, DensidadeDaLampada,
        tamanhoHorizontal, distanciaDaLanterna, anguloLanterna;
    void OnEnable()
    {
        layerObjetoOculto = serializedObject.FindProperty("layerObjetoOculto");
        cam = serializedObject.FindProperty("cam");
        Lanterna = serializedObject.FindProperty("Lanterna");
        AnguloOffSet = serializedObject.FindProperty("AnguloOffSet");
        DensidadeDaLampada = serializedObject.FindProperty("DensidadeDaLampada");

        tamanhoHorizontal = serializedObject.FindProperty("tamanhoHorizontal");
        distanciaDaLanterna = serializedObject.FindProperty("distanciaDaLanterna");
        anguloLanterna = serializedObject.FindProperty("anguloLanterna");
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        RevelarObjetos meuScript = (RevelarObjetos)target;
        EditorGUI.BeginChangeCheck();
        serializedObject.Update();
        
        if (GUILayout.Button("calcular pontos spot"))
        {
          
        }
            /*


            EditorGUILayout.PropertyField(layerObjetoOculto, new GUIContent("layerDaFloresta da floresta"));
            EditorGUILayout.PropertyField(cam, new GUIContent("cam"));
            EditorGUILayout.PropertyField(Lanterna, new GUIContent("Lanterna"));
            EditorGUILayout.PropertyField(AnguloOffSet, new GUIContent("AnguloOffSet"));
            EditorGUILayout.PropertyField(DensidadeDaLampada, new GUIContent("DensidadeDaLampada"));

            EditorGUILayout.PropertyField(tamanhoHorizontal, new GUIContent("tamanhoHorizontal"));
            EditorGUILayout.PropertyField(distanciaDaLanterna, new GUIContent("distanciaDaLanterna"));
            EditorGUILayout.PropertyField(anguloLanterna, new GUIContent("anguloLanterna"));
            */
        }

        private void OnSceneGUI()
    {
        RevelarObjetos meuscript = (RevelarObjetos)target;
        Handles.DrawLine(meuscript.Lanterna.transform.position, meuscript.Lanterna.transform.position +
            (meuscript.Lanterna.transform.forward * meuscript.distanciaDaLanterna));
        Handles.DrawWireCube(meuscript.Lanterna.transform.position +
                 (meuscript.Lanterna.transform.forward * meuscript.distanciaDaLanterna), Vector3.one * meuscript.tamanhoHorizontal/2);
   
    }

}

