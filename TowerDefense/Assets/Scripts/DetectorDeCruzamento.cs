using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorDeCruzamento : MonoBehaviour {

  [SerializeField] private Jogador jogador = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  void OnTriggerEnter (Collider collider)
    {
    if (collider.CompareTag("Inimigo"))
      {
        Debug.Log("Chegou no fim do caminho!");
        Destroy(collider.gameObject);
        jogador.PerdeVida ();
      }
    }
}
