using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcentrationManager : MonoBehaviour
{

    public GameObject CardPrefab;

    public List<int> cardValues = new List<int> { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };

    public int numFaceUp = 0;

    public int[] faceUpCards = new int[] {-1, -1}; //Stores index of cards 0-15

    public int[] numCardsPerPlayer = new int[] {0, 0, 0, 0};

    public int[] score = new int[] {0, 0, 0, 0};

    public int matchCount = 0;

    public GameObject[] cards = new GameObject[16];

    void CardSetup() {
        
        float xpos = -3f;
        float zpos = -3f;
        for (int i = 0; i < cardValues.Count; i++) {
            if (xpos == 5) {
                xpos = -3f;
                zpos += 2f;
            }
            cards[i] = Instantiate(CardPrefab, new Vector3(xpos, 0f, zpos), new Quaternion(0f, 0f, 0f, 0f));
            cards[i].GetComponent<CardScript>().cardValue = cardValues[i];
            cards[i].GetComponent<CardScript>().index = i;
            xpos += 2f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CardSetup();
    }

    // Update is called once per frame
    void Update()
    {
        if (matchCount == 8) {
            EndGame();
        }
    }

    public void Flip(GameObject card, int index) {
        if (card.GetComponent<CardScript>().faceUp) {
            return;
        }

        if (numFaceUp == 2) {
            cards[faceUpCards[0]].GetComponent<CardScript>().StartFlip();
            cards[faceUpCards[1]].GetComponent<CardScript>().StartFlip();
            numFaceUp = 0;
            faceUpCards[0] = -1;
            faceUpCards[1] = -1;
        }

        card.GetComponent<CardScript>().StartFlip();
        faceUpCards[numFaceUp] = index;
        numFaceUp += 1;

        CheckMatch();
    }

    public void CheckMatch() {
        if (faceUpCards[0] < 0 || faceUpCards[1] < 0) {
            return;
        }
        if (cards[faceUpCards[0]].GetComponent<CardScript>().cardValue == cards[faceUpCards[1]].GetComponent<CardScript>().cardValue) {
            score[cards[faceUpCards[1]].GetComponent<CardScript>().player - 1] += 1;
            matchCount += 1;
            Destroy(cards[faceUpCards[0]]);
            Destroy(cards[faceUpCards[1]]);
            faceUpCards[0] = -1;
            faceUpCards[1] = -1;
            numFaceUp = 0;
        }
    }

    public void EndGame() {
        Debug.Log("Player " + (Array.IndexOf(score, score.Max())+1).ToString() + " wins");
    }
}
