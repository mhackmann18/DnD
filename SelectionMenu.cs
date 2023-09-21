/* GetSelections(): Writes a menu to the console that displays a required prompt and a list of options
 * for the user to choose from. Returns a string array of the selected option(s).
 * The current option is highlighted, and can be changed by using the up and down arrows.
 * A highlighted option is selected by pressing the enter key, after which an optional 
 * confirmation message will be shown if it was provided. If the numAllowedSelections 
 * argument is provided, the menu will show an updated list of options numAllowedSelections 
 * of times, with previously selected options removed. Therefore, the number of allowed selections
 * cannot exceed the number of elements in the options argument.
 * */
public class SelectionMenu
{
  List<string> options = new();
  string prompt;
  string confirmation;
  int numAllowedSelections;
  int startingHighlightedIndex;
  ConsoleColor highlightColor;
  int numRemainingSelections;

  public SelectionMenu(
    string[] options, 
    string prompt,
    string confirmation = "",
    int numAllowedSelections = 1, 
    int startingHighlightedIndex = 0, 
    ConsoleColor highlightColor = ConsoleColor.White) 
  {
    // There can not be more selections available than there are choices
    if(numAllowedSelections > options.Length)
    {
      throw new ArgumentException(
        "Parameter 'numAllowedSelections' cannot be greater than length of parameter 'options'"
        );
    }
    this.options.AddRange(options);
    this.prompt = prompt;
    this.confirmation = confirmation;
    this.numAllowedSelections = numAllowedSelections;
    this.startingHighlightedIndex = startingHighlightedIndex;
    this.highlightColor = highlightColor;
    this.numRemainingSelections = numAllowedSelections;
  }

  public string[] GetSelections()
  {
    string[] selections = new string[numAllowedSelections];
    int selectedIndex = startingHighlightedIndex;

    while(numRemainingSelections > 0){  
      selectedIndex = GetSelection(selectedIndex);

      // Optionally request confirmation for selected option
      if(confirmation != "")
      {
        char response = RequestConfirmation();
        if(response == 'n')
        {
          continue;
        }
      }

      selections[numAllowedSelections - numRemainingSelections] = options[selectedIndex];
      options.RemoveAt(selectedIndex);

      selectedIndex = startingHighlightedIndex;
      numRemainingSelections--;
    }

    Console.Clear();
    return selections;
  }

  private int GetSelection(int startingHighlightedIndex)
  {
    bool chosen = false;
    int highlightedIndex = startingHighlightedIndex;

    // Write menu to console until user selects an option
    while (!chosen)
    {
      Console.Clear();
      Console.CursorVisible = false;
      Console.WriteLine(GetPrompt());

      for(int i = 0; i < options.Count; i++)
      {
        if(i == highlightedIndex)
        {
          Console.BackgroundColor = highlightColor;
        }
        Console.Write($"{options[i]}");
        Console.ResetColor();
        Console.WriteLine();
      }
      string key = Console.ReadKey(true).Key.ToString();
      switch(key)
      {
        case "Enter":
          chosen = true;
          break;
        case "UpArrow":
        if(highlightedIndex != 0)
          highlightedIndex--;
          break;
        case "DownArrow":
          if(highlightedIndex != options.Count - 1)
          {
            highlightedIndex++;
          }
          break;
        default:
          break;
      }
    }

    Console.CursorVisible = true;
    return highlightedIndex;
  }

  // Writes the confirmation message to the console followed by " (Y/N): ", 
  // then awaits a "y" or "n" (case-insensitive) response, re-prompting until
  // either input is recieved. Returns single character response in lowercase.
  private char RequestConfirmation()
  {
    Console.Write($"\n{confirmation} (Y/N): ");
    string key = "";
    while(key != "y" && key != "n")
    {
      key = Console.ReadKey(true).Key.ToString().ToLower();
    }
    return key[0];
  }

  private string GetPrompt()
  {
    string prompt = this.prompt;
    if(numAllowedSelections > 1)
    {
      if(numRemainingSelections == 1)
      {
        return $"{prompt} (1 choice remaining):\n";
      }
      return $"{prompt} ({numRemainingSelections} choices remaining):\n";
    }
    return $"{prompt}:\n";
  }
}
