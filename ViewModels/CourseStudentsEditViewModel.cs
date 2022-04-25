using Microsoft.AspNetCore.Mvc.Rendering;
using RSWeb2022.Models;
using System.Collections.Generic;

namespace RSWeb2022.ViewModels
{
    public class CourseStudentsEditViewModel
    {
        public IList<Course> Courses { get; set; }
        public SelectList Title { get; set; }
        public string CourseTitle { get; set; }
        public string SearchString { get; set; }
    }
}
