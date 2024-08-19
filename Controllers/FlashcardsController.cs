using FlashcardsAPI.CoreServices.ServiceInterface;
using FlashcardsAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace FlashcardsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashcardsController : ControllerBase
    {
        private readonly IFlashcardsService _flashcardsService;
        public FlashcardsController(IFlashcardsService flashcardsService)
        {
            _flashcardsService = flashcardsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flashcard>>> GetFlashcards()
        {
            var flashcards = await _flashcardsService.GetAllFlashcards();
            return Ok(flashcards);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Flashcard>> GetFlashcardById(Guid id)
        {
            var flashcards = await _flashcardsService.GetFlashcardById(id);
            return Ok(flashcards);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFlashcard(Guid id)
        {
            await _flashcardsService.DeleteFlashcard(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Flashcard>> PostFlashcard(Flashcard flashcard)
        {
            var newFlashcard = await _flashcardsService.AddFlashcard(flashcard);
            return Ok(newFlashcard);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutFlashcard(Flashcard flashcard)
        {
            await _flashcardsService.UpdateFlashcard(flashcard);
            return NoContent();
        }
    }
}
