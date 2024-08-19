using FlashcardsAPI.CoreServices.ServiceInterface;
using FlashcardsAPI.Infrastructure.RepositoryInterface;
using FlashcardsAPI.Models;

namespace FlashcardsAPI.CoreServices.CoreData
{
    public class FlashcardsService : IFlashcardsService

    {
        private readonly IFlashcardsRepo _flashcardsRepo;
        public FlashcardsService(IFlashcardsRepo flashcardsRepo)
        {
            _flashcardsRepo = flashcardsRepo;
        }
        public async Task<Flashcard> AddFlashcard(Flashcard flashcard)
        {
            return await _flashcardsRepo.AddFlashcard(flashcard);
        }

        public async Task DeleteFlashcard(Guid id)
        {
            await _flashcardsRepo.DeleteFlashcard(id);
        }

        public async Task<IEnumerable<Flashcard>> GetAllFlashcards()
        {
            return await _flashcardsRepo.GetAllFlashcards();
        }

        public async Task<Flashcard> GetFlashcardById(Guid id)
        {
            return await _flashcardsRepo.GetFlashcardById(id);
        }

        public async Task UpdateFlashcard(Flashcard flashcard)
        {
            await _flashcardsRepo.UpdateFlashcard(flashcard);
        }
    }
}
