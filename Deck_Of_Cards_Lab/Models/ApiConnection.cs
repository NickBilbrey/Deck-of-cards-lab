namespace Deck_Of_Cards_Lab.Models
{
    public class ApiConnection
    {
        private static HttpClient _httpClient = null;

        public static HttpClient Client
        {
            get 
            {
                if (_httpClient == null)
                { 
                    _httpClient= new HttpClient();

                    _httpClient.BaseAddress = new Uri("https://deckofcardsapi.com/api/");
                }
                return _httpClient;
            }
        }
        // deck/new/
        public static async Task<CardDeck> MakeNewDeck()
        {
            var response = await Client.GetAsync("deck/new/");

            CardDeck cardDeck = await response.Content.ReadAsAsync<CardDeck>();

            return cardDeck;
        }

        // Draw cards
        public static async Task<Cards> DrawCards(CardDeck cardDeck)
        {
 
            var response = await Client.GetAsync($"deck/{cardDeck.deck_id}/draw/?count=5");

            Cards cards = await response.Content.ReadAsAsync<Cards>();

            return cards;
        
        }

        public static async Task<CardDeck> ShuffleCards(CardDeck cardDeck)
        {
            var response = await Client.GetAsync($"deck/{cardDeck.deck_id}/shuffle/?deck_count=1");

            cardDeck = await response.Content.ReadAsAsync<CardDeck>();

            return cardDeck;
        }

        // make a new view for new cards???
    }
}
