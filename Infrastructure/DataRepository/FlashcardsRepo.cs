using FlashcardsAPI.Data;
using FlashcardsAPI.Infrastructure.RepositoryInterface;
using FlashcardsAPI.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FlashcardsAPI.Infrastructure.DataRepository
{
    public class FlashcardsRepo : IFlashcardsRepo
    {
        private readonly FlashcardsContext _context;

        public FlashcardsRepo(FlashcardsContext context)
        {
            _context = context;
        }

        public async Task<Flashcard> AddFlashcard(Flashcard flashcard)
        {
            _context.Database.ExecuteSql($"EXECUTE dbo.InsertIntoFlashcardTable @question={flashcard.Question},@answer={flashcard.Answer},@stat={flashcard.Status}");
            await _context.SaveChangesAsync();
            return flashcard;
        }

        public async Task DeleteFlashcard(Guid id)
        {
            var flashcardToDelete = await _context.Flashcards.FindAsync(id);
            
            if (flashcardToDelete != null)
            {
                _context.Database.ExecuteSql($"EXECUTE dbo.DeleteFlashcard @id={id}");
                await _context.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<Flashcard>> GetAllFlashcards()
        {
            var flashcards = await _context.Flashcards.FromSql($"dbo.ViewFlashcards").ToListAsync();
            return flashcards;
        }

        public async Task<Flashcard> GetFlashcardById(Guid id)
        {
            var flashcard = await _context.Flashcards.FromSql($"dbo.ViewFlashcard @id={id}").ToListAsync();
            return flashcard[0];
            
        }

        public async Task UpdateFlashcard(Flashcard flashcard)
        {
            _context.Database.ExecuteSql($"EXECUTE dbo.UpdateFlashcard @id={flashcard.Qid},@question={flashcard.Question},@ans={flashcard.Answer},@stat={flashcard.Status}");
            await _context.SaveChangesAsync();
        }
    }
}
