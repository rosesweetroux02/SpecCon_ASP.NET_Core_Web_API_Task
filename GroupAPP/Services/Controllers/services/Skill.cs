using GroupAPP.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



public class SkillService : Skill
{
    private readonly AppDbContext _context;

    public SkillService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Skill>> GetSkillsCreatedLastYearAsync()
    {
        var lastYear = DateTime.UtcNow.Year - 1;

        return await _context.Skills
            .Where(s => s.CreatedDate.Year == lastYear) // 
            .OrderBy(s => s.CorrectedSkillName)
            .ToListAsync();
    }
    // this is a create function 

    public async Task<Skill> CreateSkillAsync(Skill skill)
    {
        try
        {
            // Set system-controlled fields
            skill.SkillKey = Guid.NewGuid();
            skill.CreatedDate = DateTime.UtcNow;
            skill.RecordStatusId = 1; // Active

            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();

            return skill;
        }
        catch (DbUpdateException)
        {
            throw new ApplicationException("A database error occurred while creating the skill.");
        }
        catch (Exception)
        {
            throw new ApplicationException("An unexpected error occurred while creating the skill.");
        }
    }
}


namespace GroupAPP.Services.services
{
    public class Skill
    {


    }
}
