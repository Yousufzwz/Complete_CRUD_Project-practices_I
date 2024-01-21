using FirstDemo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Application.Features.Training.Services;

public class CourseManagementService
{
	private readonly IApplicationUnitOfWork _unitOfWork;
	public CourseManagementService(IApplicationUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
}
