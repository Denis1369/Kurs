using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Controls.Primitives;

namespace Kurs.Model;

public partial class RacingResult
{
    public int IDracingResult { get; set; }

    public int? IDracer { get; set; }

    public int? IDrace { get; set; }

    public int StartPosition { get; set; }

    public string FinalPosition { get; set; } = null!;

    public virtual Positionscore FinalPositionNavigation { get; set; } = null!;

    public virtual Race? IDraceNavigation { get; set; }

    public virtual Racer? IDracerNavigation { get; set; }

    public static string GeneratRacingResult(int racer, int race, int start, string? final) 
    {

        using (var context = new Formula12025Context())
        {
            foreach (var item in context.RacingResults.ToList()) 
            {
                if (item.IDrace == race && item.IDracer == racer) 
                {
                    return "Этот гоншик уже добавлен";
                }
                if (item.IDrace == race && item.StartPosition == start)
                {
                    return "Это стартовое место уже занято";
                }
                if (final == "DSQ" || final == "Ret") 
                {
                    continue;
                }
                if (item.IDrace == race && item.FinalPosition == final) 
                {
                    return "Это финишное место уже занято";
                }

            }

            context.RacingResults.Add(new RacingResult
            {
                IDracer = racer,
                IDrace = race,
                StartPosition = start,
                FinalPosition = final,
            });
            context.SaveChanges();

            return "Гонщик успешно добавлен";
        }
    }
}
