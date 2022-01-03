using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class XRInteraction : MonoBehaviour
{
    [SerializeField] GameObject Panel1;
    [SerializeField] Light light1;
    bool Active1 = false;

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.name == "BowlingBall")
        {
            light1.DOIntensity(1000, 0.8f);
            Invoke("Loading", 1.0f);
        }
        if (other.transform.name == "Shoes")
        {
            Application.Quit();
        }
        if (other.transform.name == "Pinp")
        {
            if (!Active1)
            {
                Panel1.SetActive(true);
                Active1 = true;
            }
            else
            {
                Panel1.SetActive(false);
                Active1 = false;
            }
        }
    }
    void Loading()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
