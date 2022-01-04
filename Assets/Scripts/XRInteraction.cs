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
        if(other.transform.tag == "Ball")
        {
            Destroy(other.gameObject);
            light1.DOIntensity(1000, 1.5f);
            Invoke("Loading", 2.0f);
        }
        if (other.transform.name == "Shoes")
        {
            Destroy(other.gameObject);
            light1.DOColor(Color.black, 0.1f);
            light1.DOIntensity(1000, 1.5f);
            Invoke("Quiting", 2.0f);
        }
        if (other.transform.name == "Pinp")
        {
            Destroy(other.gameObject);
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
    void Quiting()
    {
        Application.Quit();
    }
}
