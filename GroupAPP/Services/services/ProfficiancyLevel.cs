using GroupAPP.Domain.Entities;
using System;
using System.Text.RegularExpressions;

public class ProfficiancyLevelService : ProfficiancyLevel
{
    private readonly GroupAPP _context;

    public ProfficiancyLevelService(GroupAP context)
    {
        _context = context;
    }

    public async Task<List<ProfficiancyLevel>> GetAllActiveProfficiancyLevelsAsync()
    {
        return await _context.ProfficiancyLevels
            .Where(p => p.RecordStatusId == 1) // this is used for checking the active 
            .OrderBy(p => p.Description)
            .ToListAsync();
    }

    /*public async Task<bool> DeleteProfficiancyLevelAsync(int profficiancyLevelId)
    {
        var entity = await _context.ProfficiancyLevels
            .FirstOrDefaultAsync(p => p.ProfficiancyLevelId == profficiancyLevelId);

        if (entity == null)
            return false;

        // delete .
        entity.RecordStatusId = 0; // 0 = Deleted / Inactive

        _context.ProfficiancyLevels.Update(entity);
        await _context.SaveChangesAsync();

        return true;
    }*/

    public async Task<bool> DeleteProfficiancyLevelAsync(int profficiancyLevelId)
    {
        try
        {
            var entity = await _context.ProfficiancyLevels
                .FirstOrDefaultAsync(p => p.ProfficiancyLevelId == profficiancyLevelId);

            if (entity == null)
                return false;

            // Soft delete
            entity.RecordStatusId = 0; // Inactive / Deleted

            _context.ProfficiancyLevels.Update(entity);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            // RowVersion conflict or concurrent update
            throw new ApplicationException("The record was modified by another user. Please reload and try again.");
        }
        catch (DbUpdateException)
        {
            // Database constraint / update issues
            throw new ApplicationException("Unable to delete the proficiency level due to a database error.");
        }
        catch (Exception)
        {
            // Any unexpected error
            throw new ApplicationException("An unexpected error occurred while deleting the proficiency level.");
        }
    }
}




/*using GroupAPP.Domain.Entities;

public class ProfficiancyLevelService : IProfficiancyLevelService
{
    private readonly IProfficiancyLevelRepository _repository;

    public ProfficiancyLevelService(IProfficiancyLevelRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProfficiancyLevel>> GetAllActiveAsync()
    {
        return await _repository.GetAllActiveAsync();
    }
}*/

namespace GroupAPP.Services.services
{
    public class ProfficiancyLevel
    {
    

    
    }
}
