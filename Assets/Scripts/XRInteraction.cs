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
    bool isblack = false;
    float color = 0;
    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Ball")
        {
            GameObject.Find("Images").SetActive(true);
            isNext = true;
            image.color = new Color(image.color.r, image.color.g, image.color.b, color);
            Destroy(other.gameObject);
            Invoke("Loading", 2.0f);
        }
        if (other.transform.name == "Shoes")
        {
            GameObject.Find("Images").SetActive(true);
            isNext = true;
            if(!isblack)
            {
                image.color = new Color(0, 0, 0, 0);
                isblack = true;
            }
            image.color = new Color(image.color.r, image.color.g, image.color.b, color);
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
        color = Mathf.Clamp(color, 0, 1);
        image.transform.position = gameObject.transform.position + new Vector3(0, 0, 0.5f);
        if (isNext) color += Time.deltaTime;
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
