using Deck_Of_Cards_Lab.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Deck_Of_Cards_Lab.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            CardDeck cardDeck = await ApiConnection.MakeNewDeck();

            cardDeck = await ApiConnection.ShuffleCards(cardDeck);

            Cards cards = await ApiConnection.DrawCards(cardDeck);

            return View(cards);
        }

    }
}