
using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


public class MainCodeObj : MonoBehaviour
{
    public InputField textInput;
    public InputField textOutput;
    public string inputText;

    public Toggle toggle;


    /* TODO 
    GET TEXT IN INPUT FIELD 
    validate input filed
    set text as two arrays
    reverse one of the arrays
    mix the arrays in step for as long as the 

    upload to homepage
    */

    private void Start()
    {
        textInput.text = "1234";
        //textInput.text = "add numberseq here...";
    }

    //called when button pressed
    public void CalculateFoldIdentity()
    {
        //Debug.Log("CalculateFoldIdentity Called");
        //get text
        inputText = GetInputFieldText();



        //text ok, clear output
        clearOutputText();

        //cut up text in linebreaks
        string[] lines = inputText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

        for (int j = 0; j < lines.Length; j++)
        {
            //cut up string in two halfs and fold
            string s = lines[j];
            //validate string
            s = validateText(s);

            string foldedIdentity = "";
            int strLength = s.Length; //need length twice
            for (int i = 0; i < strLength; i++)
            {
                

                if (i == 0)
                {
                    addTextToOutput("\n" + "this is input: " + s);
                }
                if (toggle.isOn)
                {
                    addTextToOutput(s);
                }

                if (strLength >= 0)
                {
                    foldedIdentity += s.ToString()[1];
                }

                s = FoldSequence(s, strLength);
            }
            addTextToOutput("Folded identity: " + foldedIdentity);
        }
    }

    private string FoldSequence(string s, int l)
    {
        //string length
        int strLength = l;

        //mixed string
        string mixedString = "";
        char[] mixedCharArray = new char[strLength];

        //take string and divide in two substrings
        string firstPart = s.Substring(0, strLength / 2);
        string secondPart = s.Substring(strLength / 2, strLength / 2);

        //reverse second part
        secondPart = Reverse(secondPart);

        //Debug.Log(firstPart);
        //Debug.Log(secondPart);

        char[] firstPartCharArr = firstPart.ToCharArray();
        char[] secondPartCharArr = secondPart.ToCharArray();

        //Mix arrays into new string
        for (int i = 0; i < strLength / 2; i++)
        {
            mixedString += firstPartCharArr[i];
            mixedString += secondPartCharArr[i];
        }

        //addTextToOutput(mixedString);

        return mixedString;

        //Debug.Log(mixedString);
    }

    //save text to file
    public void copyToMemory(){
        Debug.Log("Button save pressed");
        textOutput.text.CopyToClipboard();
    }
    private string GetInputFieldText()
    {
        //Debug.Log(textInput.text);
        return (textInput.text);
    }

    private string validateText(string s)
    {
        if (s.Length % 2 == 0)
        {
            //do nothing
            //Debug.Log("length ok");
        }
        else
        {
            //Debug.Log("length not ok, trimming");
            addTextToOutput("Size not even, trimming end from: " + s);
            s = s.Remove(s.Length -1);
            addTextToOutput("->                            to: " + s);
        }
        return(s);
    }

    private void addTextToOutput(string s)
    {
        textOutput.text += s + "\n";
    }

    private void clearOutputText()
    {
        textOutput.text = "";
    }

    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
