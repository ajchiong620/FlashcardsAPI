using FlashcardsAPI.Models;

namespace FlashcardsAPI.Infrastructure.RepositoryInterface
{
    public interface IFlashcardsRepo
    {
        Task<IEnumerable<Flashcard>> GetAllFlashcards();
        Task<Flashcard> GetFlashcardById(Guid id);
        Task<Flashcard> AddFlashcard(Flashcard flashcard);
        Task UpdateFlashcard(Flashcard flashcard);
        Task DeleteFlashcard(Guid id);
    }
}
