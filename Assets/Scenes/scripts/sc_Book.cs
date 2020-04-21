using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_Book : MonoBehaviour
{
    public int actualPage = 0;
    public List<GameObject> bookPages = new List<GameObject>();
    public List<GameObject> bntBook = new List<GameObject>();

    public GameObject book;

    private void Start() {
        disablePages();
        bookPages[actualPage].SetActive(true);
    }

    public void NextPage()
    {
        if(actualPage < bookPages.Count - 1)
        {
            disablePages();
            actualPage++;
            bookPages[actualPage].SetActive(true);
        }
    }

    public void PreviousPage()
    {
        if(actualPage > 0)
        {
            disablePages();
            actualPage--;
            bookPages[actualPage].SetActive(true);
        }
    }

    public void Tab(int i)
    {
        disablePages();
        bookPages[i].SetActive(true);
        actualPage = i;
    }

    public void showBook()
    {
        book.SetActive(true);
        activateBtn();
        bookPages[actualPage].SetActive(true);
    }

    public void disableBook()
    {
        disablePages();
        disableBtn();
    }

    void disablePages()
    {
         for(int i=0; i < bookPages.Count; i++)
         {
            bookPages[i].SetActive(false);
         }
    }

    void activateBtn()
    {
        for(int i=0; i < bntBook.Count; i++)
         {
            bntBook[i].SetActive(true);
         }
    }

    void disableBtn()
    {
        for(int i=0; i < bntBook.Count; i++)
         {
            bntBook[i].SetActive(false);
         }
        
    }
}
