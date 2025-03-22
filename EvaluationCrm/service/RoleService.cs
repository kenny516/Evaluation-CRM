using EvaluationCrm.Models.entity;
using EvaluationCrm.repository;

namespace EvaluationCrm.service;

public class RoleService
{
    private readonly RoleRepository _roleRepository;

    public RoleService(RoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public  List<Role> GetAllRoles()
    {
        return  _roleRepository.GetRoles();
    }
    
}