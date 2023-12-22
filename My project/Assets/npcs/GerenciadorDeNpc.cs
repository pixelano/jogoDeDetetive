using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeNpc : MonoBehaviour
{
    public ScriptableTabelaNpc config = new ScriptableTabelaNpc();
    public objetivos snack, podio, filme;

    [System.Serializable]
    public struct objetivos {
        public Vector3 local;
        public bool completado;
    }
    public bool iniciar;
    private void Update()
    {

        
        if (iniciar)
        {
            iniciar = false;

            config.pipoca = new List<snack_>();
            config.refrigerante = new List<snack_>();
            int QP = Random.Range(0, ValoresUniversais.configNpc.QuantidadeMaximaDePipocas);
            for(int x = 0; x < QP; x++)
            {
                snack_ auxS = new snack_();
                auxS.tamanho = new tamanhos();
                int RT = Random.Range(0,4); 
                switch (RT) {
                    case 0: auxS.tamanho.pequeno = true; break;
                    case 1: auxS.tamanho.medio = true; break;
                    default : auxS.tamanho.grande= true; break;
                }
                auxS.sabor = new sabor();
                int RS = Random.Range(0,4);
                switch (RS)
                {
                    case 0: auxS.sabor.A= true; break;
                    case 1: auxS.sabor.B = true; break;
                    default: auxS.sabor.C = true; break;
                }
                config.pipoca.Add(auxS);
                Debug.Log(config.pipoca.Count);
            }
            
            // -------------
            int QR = Random.Range(0, ValoresUniversais.configNpc.QuantidadeMaximaDeBebidas); ;
            for (int x = 0; x < QR; x++)
            {
                snack_ auxS = new snack_();
                auxS.tamanho = new tamanhos();
                int RT = 4;
                switch (RT)
                {
                    case 0: auxS.tamanho.pequeno = true; break;
                    case 1: auxS.tamanho.medio = true; break;
                    default: auxS.tamanho.grande = true; break;
                }
                auxS.sabor = new sabor();
                int RS = Random.Range(0,4);
                switch (RS)
                {
                    case 0: auxS.sabor.A = true; break;
                    case 1: auxS.sabor.B = true; break;
                    default: auxS.sabor.C = true; break;
                }
                config.refrigerante.Add(auxS);
            }
        
            int QD = Random.Range(0,ValoresUniversais.configNpc.QuantidadeMaximaDeDoces);

            config.doces = new List<sabor>();
            for (int x = 0; x <QD; x++)
            {
                sabor sb = new sabor();
                int RS = Random.Range(0,4);

                switch (RS)
                {
                    case 0: sb.A = true; break;
                    case 1: sb.B = true; break;
                    default: sb.C = true; break;
                }
               
                config.doces.Add(sb);

            }
        

           


        }
     
    }
    /*
     * spawnar
     * ir para o snack
     *  entrar na fila
     *  ser atendido
     *  pegar o pedido
     *  caso falhe, ir embora - end
     *  
     * ir para o podio
     *  ser liberado ou recusado
     *  caso a recusa seja por causa da sala deve esperar
     *  caso espere muito ir embora - end
     *  
     * ir para a sala
     *  caso a sala esteja suja ir embora - end
     *  saia quando o filme acabar
     *  
     */
}
