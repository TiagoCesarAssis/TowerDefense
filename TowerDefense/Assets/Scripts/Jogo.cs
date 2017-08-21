using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogo : MonoBehaviour {
  [SerializeField] private GameObject torrePrefab;
  [SerializeField] private GameObject gameOver;
  [SerializeField] private Jogador jogador;

	// Use this for initialization
	void Start () 
    {
    gameOver.SetActive(false);		
	}
	
	// Update is called once per frame
	void Update () {

    if (JogoAcabou())
      {
        //Constrói a torre... Em qual posição?
        gameOver.SetActive(true);
      } 
      else
      {
        if (ClicouComBotaoPrimario())
          {
            ConstroiTorre();
          }
      }
		
	}

  private bool JogoAcabou()
  {
    return !jogador.EstaVivo();
  }

  public void RecomecaJogo()
  {
      Application.LoadLevel(Application.loadedLevel);
  }

  private bool ClicouComBotaoPrimario()
    {
    return Input.GetMouseButtonDown(0);
    }

  private void ConstroiTorre()
  {
    Vector3 posicaoDoClique = Input.mousePosition;
    RaycastHit elementoAtingidoPeloRaio = DisparaRaioDaCameraAteUmPonto(posicaoDoClique);
    if (elementoAtingidoPeloRaio.collider != null)
      {
        Vector3 posicaoDoElemento = elementoAtingidoPeloRaio.point;
        Instantiate(torrePrefab, posicaoDoElemento, Quaternion.identity);
      }
  }

  private RaycastHit
  DisparaRaioDaCameraAteUmPonto(Vector3 ponto)
    {
      Ray raio = Camera.main.ScreenPointToRay (ponto);
      RaycastHit elementoAtingidoPeloRaio;
      float comprimentoMaximoDoRaio = 100.0f;
      Physics.Raycast(raio, out elementoAtingidoPeloRaio, comprimentoMaximoDoRaio);
      return elementoAtingidoPeloRaio;
    }
  
}
