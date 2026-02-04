using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Module4Challenge.Pages
{
    // PageModel class that controls the DadJokes page
    public class DadJokesModel : PageModel
    {
        // Array holding 12 dad jokes
        public string[] DadJokesArray = new string[]
        {
            "Why don't skeletons fight each other? They don't have the guts.",
            "I only know 25 letters of the alphabet. I don't know y.",
            "Why did the scarecrow win an award? Because he was outstanding in his field.",
            "What do you call fake spaghetti? An impasta.",
            "Why did the math book look sad? Because it had too many problems.",
            "I used to hate facial hair, but then it grew on me.",
            "Why can't eggs tell jokes? They would crack each other up.",
            "What do you call cheese that isn't yours? Nacho cheese.",
            "Why did the coffee file a police report? It got mugged.",
            "I would tell you a construction joke, but I'm still working on it.",
            "Why don't programmers like nature? Too many bugs.",
            "Why did the computer go to the doctor? It caught a virus."
        };

        // List storing jokes currently displayed
        public List<string> CurrentJokes { get; set; } = new List<string>();

        // Number of jokes shown at one time
        [BindProperty]
        public int JokesToShow { get; set; } = 2;

        // Random number generator
        private Random rnd = new Random();

        // Runs when page first loads
        public void OnGet()
        {
            CurrentJokes = GetRandomJokes(JokesToShow);
        }

        // Runs when button is clicked
        public void OnPost()
        {
            CurrentJokes = GetRandomJokes(JokesToShow);
        }

        // Method that selects random jokes without duplicates
        private List<string> GetRandomJokes(int count)
        {
            List<string> jokes = new List<string>();

            while (jokes.Count < count)
            {
                int index = rnd.Next(0, DadJokesArray.Length);
                string joke = DadJokesArray[index];

                if (!jokes.Contains(joke))
                {
                    jokes.Add(joke);
                }
            }

            return jokes;
        }
    }
}