//Title for spacename 

using System;

using System.Collections.Generic;
using System.Media;
using Programming;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Programming;

namespace Programming;




//class for programing
public class Programming
{

    // Main method
    static void Main(string[] args)
    {
        Logo logo = new Logo();
        logo.Display();
        SoundPlayer player = new System.Media.SoundPlayer("C:\\Users\\Student\\source\\repos\\ConsoleApp1\\ConsoleApp1\\Voice\\aisound.wav");
        player.PlaySync();

    }
}



