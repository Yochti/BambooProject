using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaScript : MonoBehaviour
{
    [SerializeField] int PandaLife; //On d�finit le nombre de vies du panda
    public VignetteIntensity vignetteScript;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Scrap"))
        {
            Debug.Log("Collision !");
            vignetteScript.IncreaseVignetteIntensity();
        }
    }


    public void TakeDamage(int damage) //On d�finit une fonction pour enlever de la vie au panda
    {
        PandaLife -= damage; //On enl�ve de la vie au panda
        if (PandaLife <= 0) //On v�rifie s'il est mort
        {
            Destroy(gameObject); //On d�truit le panda
            GameManager.instance.CountPanda(); //On utilise le GameManger static pour appeler la fonction CountPanda
        }
    }
}
