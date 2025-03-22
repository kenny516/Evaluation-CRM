
using EvaluationCrm.Data;
using EvaluationCrm.Models.entity;
using Microsoft.EntityFrameworkCore;

namespace EvaluationCrm.repository;

public class RoleRepository
{
    private readonly ApplicationDbContext _context;

    public RoleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Role> GetRoles()
    {
        return _context.Roles.ToList();
    }

    
    
}