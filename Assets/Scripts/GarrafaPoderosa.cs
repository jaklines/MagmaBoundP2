using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarrafaPoderosa : MonoBehaviour
{

    [SerializeField]
    private Animator crackbottle;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CrackB();
            collision.GetComponent<PlayerMovement>().ActivateShield();
            Debug.Log("Pegou Pot");
        }
    }

    public void CrackB()
    {
        crackbottle.SetBool("CrackBot", true);
    }
}
