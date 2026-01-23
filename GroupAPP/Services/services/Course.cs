/*namespace GroupAPP.Services.services
{
    public class Course
    {
    }
}
*/

using GroupAPP.Domain.Entities;
using System;

//Create A list of courses that are approved and not assessments and have an nqflevel greater than 4
public class CourseService : Course
{
    private readonly AppDbContext _context;

    public CourseService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Course>> GetApprovedNonAssessmentCoursesWithNqfAboveFourAsync()
    {
        return await _context.Courses
            .Where(c =>
                c.IsApproved == true &&
                c.IsAssessment == false &&
                c.RecordStatusId == 1 &&
                c.NQFLevel != null &&
                int.TryParse(c.NQFLevel, out var nqf) && nqf > 4
            )
            .OrderBy(c => c.CourseName)
            .ToListAsync();
    }


    // a update function 

    public async Task<Course?> UpdateCourseAsync(int courseId, string courseName, string courseDescription, decimal coursePrice, byte[] rowVersion)
    {
        try
        {
            // Find the course
            var course = await _context.Courses
                .FirstOrDefaultAsync(c => c.CourseId == courseId && c.RecordStatusId == 1);

            if (course == null)
                return null; // Course not found

            // Update only the allowed fields
            course.CourseName = courseName;
            course.CourseDescription = courseDescription;
            course.CoursePrice = coursePrice;

            // Set RowVersion for concurrency check
            _context.Entry(course).OriginalValues["RowVersion"] = rowVersion;

            await _context.SaveChangesAsync();

            return course;
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new ApplicationException("The course was updated by another user. Please reload and try again.");
        }
        catch (DbUpdateException)
        {
            throw new ApplicationException("A database error occurred while updating the course.");
        }
        catch (Exception)
        {
            throw new ApplicationException("An unexpected error occurred while updating the course.");
        }
    }


}
