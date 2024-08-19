using System;
using System.Collections.Generic;

namespace FlashcardsAPI.Models;

public partial class Flashcard
{
    public Guid Qid { get; set; }

    public string? Question { get; set; }

    public string? Answer { get; set; }

    public string? Status { get; set; }
}
