﻿using FirstDemo.Domain;
using FirstDemo.Domain.Entities;
using FirstDemo.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Application.Features.Training.Services;

public class CourseManagementService : ICourseManagementService
{
    private readonly IApplicationUnitOfWork _unitOfWork;
    public CourseManagementService(IApplicationUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task CreateCourseAsync(string title, string description, uint fees)
    {
        bool isDuplicateTitle = await _unitOfWork.CourseRepository.IsTitleDuplicateAsync(title);
        if (isDuplicateTitle)
            throw new DuplicateTitleException();

        Course course = new Course()
        {
            Title = title,
            Description = description,
            Fees = fees
        };

        _unitOfWork.CourseRepository.Add(course);
        await _unitOfWork.SaveAsync();
    }

    public async Task<(IList<Course> records, int total, int totalDisplay)> GetDataOfCoursesAsync(int pageIndex, int pageSize, string searchText, string sortBy)
    {
        return await _unitOfWork.CourseRepository.GetTableDataAsync(searchText, sortBy,
            pageIndex, pageSize);
    }

    public async Task RemoveCourseAsync(Guid id)
    {
        await _unitOfWork.CourseRepository.RemoveAsync(id);
        await _unitOfWork.SaveAsync();
    }
}
