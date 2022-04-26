using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HaxorSim
{
  public class KeyWords : ScriptableObject
  {
    private List<string> actionWords = new List<string> { "run", "do", "attach", "create", "inject", "bypass", "do", "switch",
        "ruin", "destroy", "debug", "log", "trespass", "initialize", "create", "triangulate", "git", "vim", "post", "get", "delete", "echo"};

    private List<string> contextWords = new List<string> { "void", "hello world", "maliscious script", "lulz-sec-script",
        "script", "malware", "DDOS", "system defense", "defenses", "firewall", "database", "server", "frontend", "backend", "whosfault", "servers" };

    private List<string> compoundSymbols = new List<string> { "&&", "||", "!!", "!=", "==" };

    // Difficulty ranges from 1 to 4
    // 
    public string CreateCommand(int difficulty = 1, int numCommands = 1)
    {
      List<string> commands = new List<string>();

      // Full command string includes all commands, with variable number of context words.
      // Each separate command has a compound symbol between them. 

      var fullCommandString = "";

      // Create number of commands;
      for (int i = 0; i < numCommands; i++)
      {

        var actionWord = getRandomString(actionWords);

        var contextWord = "";

        // Create a longer command from adding more context words
        for (int j = 0; i < difficulty; i++)
        {
          // Add space if command has more than one context word.
          if (i > 1)
          {
            contextWord += " ";
          }

          contextWord += getRandomString(contextWords);
        }

        var fullCommand = actionWord + " " + contextWord;
        commands.Add(fullCommand);

      }



      for (int i = 0; i < commands.Count; i++)
      {
        if (i > 1)
        {
          fullCommandString += " ";
        }

        fullCommandString += commands[i];
      }

      return fullCommandString;

    }

    private string getRandomString(List<string> list)
    {
      var index = Random.Range(0, list.Count - 1);
      return list[index];
    }
  }
}

