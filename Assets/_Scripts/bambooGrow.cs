using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class bambooGrow : MonoBehaviour
{
    [SerializeField] private GameObject bamboo1, bamboo2, bamboo3;
    private float timeToGrow = 10f;
    private float currentTime;
    private string bambooState = "phase1";
    private bool canCollect = false;
    [SerializeField] private int bambooCounter;
    [SerializeField] private TextMeshProUGUI bambooText;
    public int bambooHealth = 3;
    

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timeToGrow && bambooState =="phase1")
        {
            bamboo1.SetActive(true);
            bamboo2.SetActive(false);
            bamboo3.SetActive(false);
            bambooState = "phase2";
            currentTime = 0;
        }
        if (currentTime >= timeToGrow && bambooState == "phase2")
        {
            bamboo1.SetActive(false);
            bamboo2.SetActive(true);
            bamboo3.SetActive(false);
            bambooState = "phase3";
            currentTime = 0;
        }
        if (currentTime >= timeToGrow && bambooState == "phase3")
        {
            bamboo1.SetActive(false);
            bamboo2.SetActive(false);
            bamboo3.SetActive(true);
            bambooState = "wait";
            currentTime = 0;
        }
        if(bambooState == "wait" && canCollect == true)
        {
            if(Input.GetMouseButtonDown(1))
            {
                bamboo3.SetActive(false);
                bambooCounter += 2;
                bambooText.text = bambooCounter.ToString();
                StartCoroutine(WaitForRespawn());

            }


        }
        if (bambooHealth <= 0)
            Destroy(gameObject);

    }
    IEnumerator WaitForRespawn()
    {
        yield return new WaitForSeconds(10f);
        bambooState = "phase1";
        

    }
    private void OnMouseOver()
    {
        canCollect = true;
    }
    private void OnMouseExit()
    {
        canCollect = false;
    }
}
