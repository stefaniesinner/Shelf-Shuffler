using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to handle the Bookshelf Window
public class BookshelfController : MonoBehaviour
{
    [SerializeField]
    private GameObject bookshelfWindow;
    [SerializeField]
    private GameObject buttonIndicator; // To inform the player which button to press to open/close the bookshelf window
    [SerializeField]
    private KeyCode windowKey = KeyCode.E;

    private bool isDetectingPlayer;
    private bool isOpen;

    private void Start()
    {
        ActivateBookshelfWindow(false);
        ActivateButtonIndicator(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(windowKey))
        {
            OpenAndCloseBookshelfWindow();
        }
    }

    private void OpenAndCloseBookshelfWindow()
    {
        if (!isOpen && isDetectingPlayer)
        {
            isOpen = true;
            bookshelfWindow.SetActive(true);
        }
        else
        {
            isOpen = false;
            bookshelfWindow.SetActive(false);
        }
    }

    private void ActivateBookshelfWindow(bool isShowing)
    {
        bookshelfWindow.SetActive(isShowing);
    }

    private void ActivateButtonIndicator(bool isShowing)
    {
        buttonIndicator.SetActive(isShowing);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDetectingPlayer = true;
            ActivateButtonIndicator(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDetectingPlayer = false;
            ActivateButtonIndicator(false);
        }
    }

    private void OnDestroy()
    {
        bookshelfWindow = null;
        buttonIndicator = null;
    }

}
