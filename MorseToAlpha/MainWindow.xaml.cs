using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MorseToAlpha
{
    public partial class MainWindow : Window
    {
        // define global objects
        LinkedList<Char> alphabetList = new LinkedList<Char>();  // lLinkedList to contain the alphabet
        ArrayList morseArraylist = new ArrayList();              // ArrayList to contain morse code
        
        public MainWindow()
        {
            InitializeComponent();

            // populate LinkedList with char objects 'A' to 'Z' (i.e. 65 to 90)
            alphabetList.AddFirst('A');
            for (Char i = 'B'; i <= 'Z'; i++)
            {
                alphabetList.AddLast(i);
            }

            // add an alphabetical ordered Array of morse code to an ArrayList 
            morseArraylist.AddRange( new String[] { "._"  ,     "_...",     "_._.",     "_.." ,     "."   ,     ".._.",     "__.",
                                                    "....",     ".."  ,     ".___",     "_._" ,     "._..",     "__"  ,     "_." ,
                                                    "___" ,     ".__.",     "__._",     "._." ,     "..." ,     "_"   ,     ".._",
                                                    "..._",     ".__" ,     "_.._",     "_.__",     "__.."      });
            // assign the ArrayList of morse code as the items source for the morse combobox
            morseComboBox.ItemsSource = morseArraylist;
        }

        // when alphabet label "loading finished" event occurs this is the subroutine that gets called
        private void AlphabetOutput_Loaded(object sender, RoutedEventArgs e)
        {
            alphabetOutput.Content = ConvertMorseToAlpha();
        }

        // when morse combobox "loading finished" event occurs this is the subroutine that gets called
        private void MorseComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            morseComboBox.SelectedItem = morseArraylist[0];
        }

        // when morse combobox "selected item changed" event occurs this is the subroutine that gets called
        private void MorseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            alphabetOutput.Content = ConvertMorseToAlpha();
        }

        // does a conversion and returns the Char value
        private String ConvertMorseToAlpha()
        {
            if ((bool)upperCheckBox.IsChecked)
                return alphabetList.ElementAt(morseArraylist.IndexOf(morseComboBox.SelectedItem)).ToString(); // to make it lower use --> .ToString().ToLower();
            else
                return alphabetList.ElementAt(morseArraylist.IndexOf(morseComboBox.SelectedItem)).ToString().ToLower();
        }
    }
}
