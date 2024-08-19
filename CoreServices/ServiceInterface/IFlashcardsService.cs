using FlashcardsAPI.Models;

namespace FlashcardsAPI.CoreServices.ServiceInterface
{
    public interface IFlashcardsService
    {
        Task<IEnumerable<Flashcard>> GetAllFlashcards();
        Task<Flashcard> GetFlashcardById(Guid id);
        Task<Flashcard> AddFlashcard(Flashcard flashcard);
        Task UpdateFlashcard(Flashcard flashcard);
        Task DeleteFlashcard(Guid id);
    }
}
