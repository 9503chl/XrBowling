using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class XRInteraction : MonoBehaviour
{
    [SerializeField] GameObject Panel1;
    [SerializeField] GameObject Images;
    [SerializeField] Image image;
    [SerializeField] Image image1;
    [SerializeField] Image image2;
    bool Active1 = false;
    bool isNext = false;
    float color = 0;
    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Ball")
        {
            isNext = true;
            Images.SetActive(true);
            image.color = new Color(image.color.r, image.color.g, image.color.b, color);
            image1.color = new Color(image1.color.r, image1.color.g, image1.color.b, color);
            image2.color = new Color(image2.color.r, image2.color.g, image2.color.b, color);
            Destroy(other.gameObject);
            Invoke("Loading", 2.0f);
        }
        if (other.transform.name == "Shoes")
        {
            isNext = true;
            Images.SetActive(true);
            image.color = Color.black; image1.color = Color.black; image2.color = Color.black;
            image.color = new Color(image.color.r, image.color.g, image.color.b, color);
            image1.color = new Color(image1.color.r, image1.color.g, image1.color.b, color);
            image2.color = new Color(image2.color.r, image2.color.g, image2.color.b, color);
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
        color = Mathf.Clamp(color, 0, 1.0f);
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
