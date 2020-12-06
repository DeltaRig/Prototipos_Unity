using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{

    public string texto;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>(); // pega componente animator do obj que o code pertence
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision) {
	    if(collision.gameObject.tag == "Player"){
            Debug.Log(texto);
            animator.SetBool("canOpen", true);
        }
	}
}
