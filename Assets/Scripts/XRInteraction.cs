using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class XRInteraction : MonoBehaviour
{
    [SerializeField] GameObject Panel1;
    [SerializeField] Image image;
    bool Active1 = false;
    bool isNext = false;
    Color color;
    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Ball")
        {
            isNext = true;
            color = image.color;
            Destroy(other.gameObject);
            Invoke("Loading", 2.0f);
        }
        if (other.transform.name == "Shoes")
        {
            isNext = true;
            image.color = Color.black;
            color = image.color;
            Destroy(other.gameObject);
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
    private void Update()
    {
        if (isNext) color.a += Time.deltaTime;
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
