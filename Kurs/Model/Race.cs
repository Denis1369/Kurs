using System;
using System.Collections.Generic;

namespace Kurs.Model;

public partial class Race
{
    public int IDrace { get; set; }

    public int? IDtrack { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string? Note { get; set; }

    public virtual Track? IDtrackNavigation { get; set; }

    public virtual ICollection<RacingResult> RacingResults { get; set; } = new List<RacingResult>();

    public static string GeneratRace(int idTrack, DateTime? start, DateTime? end, string note) 
    {
        if (idTrack < 1)
            return "Выберете трассу";
        if (start == null)
            return "Выберете дату старта";
        if (end == null)
            return "Выберете дату конца";
        if (string.IsNullOrWhiteSpace(note))
            return "Напишите заметку";

        using (var context = new Formula12025Context()) 
        {
            context.Races.Add(new Race
            {
                IDtrack = idTrack,
                StartDate = DateOnly.FromDateTime((DateTime)start),
                EndDate = DateOnly.FromDateTime((DateTime)end),
                Note = note
            });
            context.SaveChanges();
            return "Гонка успешно создана";
        }
    }
}
